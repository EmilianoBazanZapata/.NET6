using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repository.Interfaces;
using WebApi.ViewModels.Request;
using WebApi.ViewModels.Response;
using System.Net;
using SendGrid.Helpers.Errors.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Services
{
    public class ArticuloService
    {
        private readonly IRepository _repository;
        public ArticuloService(IRepository repository)
        {
            _repository = repository;

        }

        public async Task<IQueryable<Articulo>> ListadoDeArticulos(string nombre)
        {
            var articulos = await _repository.GetQueryAsync<Articulo>(
                                                            predicate: a => nombre != null ? a.Titulo.Contains(nombre) && a.SoftDelete == false : a.SoftDelete == false,
                                                            include: a => a.Include(a => a.Categoria));

            return articulos;
        }

        public async Task<ArticuloCategoriaViewModel> CrearArticulo()
        {
            ArticuloCategoriaViewModel articuloCategorias = new ArticuloCategoriaViewModel();

            var categorias = await _repository.GetQueryAsync<Categoria>();

            articuloCategorias.ListaDeCategorias = categorias.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre }).ToList();

            return articuloCategorias;
        }

        public async Task<GenericViewModelResponse> CrearArticulo(Articulo articulo)
        {
            try
            {
                await _repository.CreateAsync(articulo);

                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se creó el Articulo: {articulo.Titulo}, exitosamente."
                };
            }
            catch (WebException ex)
            {

                return new GenericViewModelResponse()
                {
                    Status = (int)((HttpWebResponse)ex.Response).StatusCode,
                    Titulo = "Ocurrio un Error",
                    Cuerpo = ex.Message.ToString()
                };
            }
        }

        public async Task<GenericViewModelResponse> BorrarArticulo(int id)
        {
            try
            {
                var articulo = await _repository.GetByIdAsync<Articulo>(id);

                if (articulo == null)

                    throw new NotFoundException($"El articulo con el Id {id} no existe.");

                if (articulo.SoftDelete == true)

                    throw new NotFoundException($"El articulo {articulo.Titulo} ya esta dado de baja.");

                articulo.SoftDelete = true;

                articulo.LastModified = DateTime.Now.Date;

                await _repository.UpdateAsync(articulo);

                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se Eliminó el Articulo: {articulo.Titulo}, exitosamente."
                };
            }
            catch (WebException ex)
            {

                return new GenericViewModelResponse()
                {
                    Status = (int)((HttpWebResponse)ex.Response).StatusCode,
                    Titulo = "Ocurrio un Error",
                    Cuerpo = ex.Message.ToString()
                };
            }
        }

        public async Task<ArticuloCategoriaViewModel> EditarArticulo(int? id)
        {

            var articulo = await _repository.GetByIdAsync<Articulo>(id.Value);

            if (articulo == null)
                throw new NotFoundException($"El articulo con el Id {id} no existe.");


            ArticuloCategoriaViewModel articuloCategoriaVm = new ArticuloCategoriaViewModel();

            var categorias = await _repository.GetQueryAsync<Categoria>();

            if (!categorias.Any())
                throw new NotFoundException($"No hay Categorias disponibles para actualizar el Articulo");

            articuloCategoriaVm.ListaDeCategorias = categorias.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre }).ToList();

            articuloCategoriaVm.Articulo = await _repository.FindFirstAsync<Articulo>(a => a.Id == id);

            return articuloCategoriaVm;
        }

        public async Task<GenericViewModelResponse> EditarArticulo(ArticuloCategoriaViewModel articuloVm)
        {

            try
            {
                if (articuloVm.Articulo.Id == 0)
                    throw new BadRequestException($"No se puede actualizar un articulo con Id 0");

                await _repository.UpdateAsync(articuloVm.Articulo);

                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se Actualizó el Articulo: {articuloVm.Articulo.Titulo}, exitosamente."
                };

            }
            catch (WebException ex)
            {

                return new GenericViewModelResponse()
                {
                    Status = (int)((HttpWebResponse)ex.Response).StatusCode,
                    Titulo = "Ocurrio un Error",
                    Cuerpo = ex.Message.ToString()
                };
            }
        }

        public async Task<ArticuloEtiquetaViewModel> AdministrarEtiquetas(int id)
        {
            ArticuloEtiquetaViewModel articuloEtiquetas = new ArticuloEtiquetaViewModel
            {
                ListaArticuloEtiquetas = await _repository.GetQueryAsync<ArticuloEtiqueta>(predicate: ae => ae.ArticuloId == id,
                                                                                           include: e => e.Include(e => e.Etiqueta)
                                                                                                          .Include(e => e.Articulo)),

                ArticuloEtiqueta = new ArticuloEtiqueta()
                {
                    ArticuloId = id
                },
                Articulo = await _repository.FindFirstAsync<Articulo>(a => a.Id == id)
            };

            List<int> listaTemporalEtiquetasArticulo = articuloEtiquetas.ListaArticuloEtiquetas.Select(e => e.EtiquetaID).ToList();
            //Obtener todas las etiquetas cuyos id's no estén en la listaTemporalEtiquetasArticulo
            //Crear un NOT IN usando LINQ
            var listaTemporal = await _repository.GetQueryAsync<Etiqueta>(predicate: e => !listaTemporalEtiquetasArticulo.Contains(e.Id));

            //Crear lista de etiquetas para el dropdown
            articuloEtiquetas.ListaEtiquetas = listaTemporal.Select(i => new SelectListItem
            {
                Text = i.Titulo,
                Value = i.Id.ToString()
            });

            return articuloEtiquetas;
        }

        public async Task<GenericViewModelResponse> AdministrarEtiquetas(ArticuloEtiquetaViewModel articuloEtiquetaViewModel)
        {
            try
            {
                await _repository.CreateAsync(articuloEtiquetaViewModel.ArticuloEtiqueta);
                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se Agregó la etiqueta al Articulo: {articuloEtiquetaViewModel.ArticuloEtiqueta}, exitosamente."
                };
            }
            catch (WebException ex)
            {

                return new GenericViewModelResponse()
                {
                    Status = (int)((HttpWebResponse)ex.Response).StatusCode,
                    Titulo = "Ocurrio un Error",
                    Cuerpo = ex.Message.ToString()
                };
            }
        }

        public async Task<GenericViewModelResponse> EliminarEtiquetas(int idEtiqueta, ArticuloEtiquetaViewModel articuloEtiquetas)
        {
            var articuloEtiqueta = await _repository.FindFirstAsync<ArticuloEtiqueta>(ae => ae.EtiquetaID == idEtiqueta && ae.ArticuloId == articuloEtiquetas.Articulo.Id);

            if (articuloEtiqueta == null)
                throw new NotFoundException($"No se encontró la etiqueta con el id: {idEtiqueta}");

            try
            {
                await _repository.DeleteAsync(articuloEtiqueta);

                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se Eliminó la Etiqueta exitosamente."
                };
            }
            catch (WebException ex)
            {

                return new GenericViewModelResponse()
                {
                    Status = (int)((HttpWebResponse)ex.Response).StatusCode,
                    Titulo = "Ocurrio un Error",
                    Cuerpo = ex.Message.ToString()
                };
            }
        }
    }
}
