using Microsoft.IdentityModel.SecurityTokenService;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Services
{
    public class CategoriaService
    {
        private readonly IRepository<Categoria> _repository;
        public CategoriaService(IRepository<Categoria> repository)
        {
            _repository = repository;

        }

        public async Task<IQueryable<Categoria>> ListadoDeCategorias()
        {
            var categorias = await _repository.GetQueryAsync<Categoria>(
                                                            predicate: a => a.SoftDelete == false);

            return categorias;
        }
        public async Task<Categoria> EditarCategoria(int id)
        {

            var categoria = await _repository.FindFirstAsync<Categoria>(c => c.Id == id);

            if (categoria == null)
                throw new BadRequestException($"La Categoria con el Id {id} no existe.");

            return categoria;
        }
        public async Task<Categoria> EditarCategoria(Categoria categoria)
        {
            await _repository.UpdateAsync(categoria);
            return categoria;
        }
        public async Task<Categoria> BorrarCategoria(int id)
        {
            var categoria = await _repository.FindFirstAsync<Categoria>(c => c.Id == id);

            if (categoria == null)
                throw new BadRequestException($"La Categoria con el Id {id} no existe.");

            categoria.SoftDelete = true;

            await _repository.UpdateAsync(categoria);

            return categoria;
        }
    }
}