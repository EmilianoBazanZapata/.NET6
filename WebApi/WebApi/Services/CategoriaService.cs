using Microsoft.IdentityModel.SecurityTokenService;
using System.Net;
using WebApi.Models;
using WebApi.Repository.Interfaces;
using WebApi.ViewModels.Response;

namespace WebApi.Services
{
    public class CategoriaService
    {
        private readonly IRepository _repository;
        public CategoriaService(IRepository repository)
        {
            _repository = repository;

        }

        public async Task<IQueryable<Categoria>> ListadoDeCategorias()
        {
            var categorias = await _repository.GetQueryAsync<Categoria>(
                                                            predicate: a => a.SoftDelete == false);

            return categorias;
        }

        public async Task<GenericViewModelResponse> AgregarCategoria(Categoria categoria)
        {
            try
            {
                await _repository.CreateAsync(categoria);


                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se creo la Categoria: {categoria.Nombre}, exitosamente."
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

        public async Task<Categoria> EditarCategoria(int id)
        {
            var categoria = await _repository.FindFirstAsync<Categoria>(c => c.Id == id);

            if (categoria == null)
                throw new BadRequestException($"La Categoria con el Id {id} no existe.");

            return categoria;
        }

        public async Task<GenericViewModelResponse> EditarCategoria(Categoria categoria)
        {
            try
            {
                await _repository.UpdateAsync(categoria);

                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se Actualizó la Categoria: {categoria.Nombre}, exitosamente."
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
        public async Task<GenericViewModelResponse> BorrarCategoria(int id)
        {
            try
            {
                var categoria = await _repository.FindFirstAsync<Categoria>(c => c.Id == id);

                if (categoria == null)
                    throw new BadRequestException($"La Categoria con el Id {id} no existe.");

                categoria.SoftDelete = true;

                await _repository.UpdateAsync(categoria);

                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se Eliminó la Categoria: {categoria.Nombre}, exitosamente."
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