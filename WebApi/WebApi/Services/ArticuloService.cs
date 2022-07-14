using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repository.Interfaces;
using WebApi.ViewModels;
using Microsoft.IdentityModel.SecurityTokenService;

namespace WebApi.Services
{
    public class ArticuloService
    {
        private readonly IRepository<Articulo> _repository;
        public ArticuloService(IRepository<Articulo> repository)
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

        public async Task<ArticuloCategoriaVm> CrearArticulo()
        {
            ArticuloCategoriaVm articuloCategorias = new ArticuloCategoriaVm();

            var categorias = await _repository.GetQueryAsync<Categoria>();

            articuloCategorias.ListaDeCategorias = categorias.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre }).ToList();

            return articuloCategorias;
        }
        public async Task<IActionResult> BorrarArticulo(int id)
        {
            var articulo = await _repository.GetByIdAsync<Articulo>(id);

            if (articulo == null)

                throw new BadRequestException($"El articulo con el Id {id} no existe.");

            if (articulo.SoftDelete == true)

                throw new BadRequestException($"El articulo {articulo.Titulo} ya esta dado de baja.");

            articulo.SoftDelete = true;

            articulo.LastModified = DateTime.Now.Date;

            await _repository.UpdateAsync(articulo);

            return new BadRequestObjectResult(new
            {
                message = $"El articulo {articulo.Titulo} ya se elimino."
            });
        }

        public async Task<ArticuloCategoriaVm> EditarArticulo(int? id)
        {
            var articulo = await _repository.GetByIdAsync<Articulo>(id.Value);

            if (articulo == null)

                throw new BadRequestException($"El articulo con el Id {id} no existe.");


            ArticuloCategoriaVm articuloCategoriaVm = new ArticuloCategoriaVm();

            var categorias = await _repository.GetQueryAsync<Categoria>();

            articuloCategoriaVm.ListaDeCategorias = categorias.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre }).ToList();

            articuloCategoriaVm.Articulo = await _repository.FindFirstAsync<Articulo>(a => a.Id == id);

            return articuloCategoriaVm;
        }
    }
}
