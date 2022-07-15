using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repository.Interfaces;

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
    }
}
