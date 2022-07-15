using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repository.Interfaces;
using Microsoft.IdentityModel.SecurityTokenService;
using WebApi.ViewModels.Request;
using WebApi.ViewModels.Response;
using System.Net;

namespace WebApi.Services
{
    public class ArticuloService
    {
        private readonly IRepository _repository;
        public ArticuloService(IRepository repository)
        {
            _repository = repository;

        }

        public async Task<IQueryable<Articulo>> ListadoDeArticulos()
        {
            var articulos = await _repository.GetQueryAsync<Articulo>(
                                                            predicate: a => a.SoftDelete == false,
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
                    Cuerpo = $"Se creo el Articulo: {articulo.Titulo}, exitosamente."
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

                    throw new BadRequestException($"El articulo con el Id {id} no existe.");

                if (articulo.SoftDelete == true)

                    throw new BadRequestException($"El articulo {articulo.Titulo} ya esta dado de baja.");

                articulo.SoftDelete = true;

                articulo.LastModified = DateTime.Now.Date;

                await _repository.UpdateAsync(articulo);

                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se creo el Articulo: {articulo.Titulo}, exitosamente."
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
                throw new BadRequestException($"El articulo con el Id {id} no existe.");


            ArticuloCategoriaViewModel articuloCategoriaVm = new ArticuloCategoriaViewModel();

            var categorias = await _repository.GetQueryAsync<Categoria>();

            if (!categorias.Any())
                throw new BadRequestException($"No hay Categorias disponibles para actualizar el Articulo");

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
    }
}
