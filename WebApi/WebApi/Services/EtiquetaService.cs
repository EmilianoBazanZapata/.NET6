using Microsoft.IdentityModel.SecurityTokenService;
using System.Net;
using WebApi.Models;
using WebApi.Repository.Interfaces;
using WebApi.ViewModels.Response;

namespace WebApi.Services
{
    public class EtiquetaService
    {
        private readonly IRepository _repository;
        public EtiquetaService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<Etiqueta>> LitadoDeEtiquetas() 
        {
            var etiquetas = await _repository.GetQueryAsync<Etiqueta>(
                                                predicate: a => a.SoftDelete == false);

            return etiquetas;
        }
        public async Task<GenericViewModelResponse> CrearEtiqueta(Etiqueta etiqueta)
        {
            try
            {
                await _repository.CreateAsync(etiqueta);

                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se creó la Etiqueta: {etiqueta.Titulo}, exitosamente."
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

        public async Task<Etiqueta> EditarEtiqueta(int id)
        {
            var etiqueta = await _repository.GetByIdAsync<Etiqueta>(id);

            if(etiqueta == null)
                throw new BadRequestException($"La Etiqueta con el Id {id} no existe.");

            return etiqueta;
        }

        public async Task<GenericViewModelResponse> EditarEtiqueta(Etiqueta etiqueta)
        {
            try
            {
                await _repository.UpdateAsync(etiqueta);

                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se Actualizó la Etiqueta: {etiqueta.Titulo}, exitosamente."
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
        public async Task<GenericViewModelResponse> BorrarEtiqueta(int id)
        {
            try
            {
                var etiqueta = await _repository.GetByIdAsync<Etiqueta>(id);

                if (etiqueta == null)

                    throw new BadRequestException($"La Etiqueta con el Id {id} no existe.");

                if (etiqueta.SoftDelete == true)

                    throw new BadRequestException($"La Etiqueta {etiqueta.Titulo} ya esta dado de baja.");

                etiqueta.SoftDelete = true;

                etiqueta.LastModified = DateTime.Now.Date;

                await _repository.UpdateAsync(etiqueta);

                return new GenericViewModelResponse()
                {
                    Status = 200,
                    Titulo = "Felicitaciones",
                    Cuerpo = $"Se Elimino la Etiqueta: {etiqueta.Titulo}, exitosamente."
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
