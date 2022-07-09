using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Datos;
using WebApi.Models;
using WebApi.Repository.Interfaces;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly IRepository<Articulo> _repository;

        public ArticuloController(IRepository<Articulo> repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articulos = await _repository.GetQueryAsync<Articulo>(
                    predicate: a => a.SoftDelete == false,
                    include: a => a.Include(a => a.Categoria));

            return View(articulos);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            ArticuloCategoriaVm articuloCategorias = new ArticuloCategoriaVm();

            var categorias = await _repository.GetQueryAsync<Categoria>();

            articuloCategorias.ListaDeCategorias = categorias.Select(c=> new SelectListItem { Value=c.Id.ToString(), Text = c.Nombre }).ToList();

            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Articulo articulo)
        {
            await _repository.CreateAsync(articulo);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int id)
        {
            var articulo = await _repository.FindFirstAsync<Articulo>(a => a.Id == id);
            articulo.SoftDelete = true;
            articulo.LastModified = DateTime.Now.Date;
            await _repository.UpdateAsync(articulo);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            ArticuloCategoriaVm articuloCategoriaVm = new ArticuloCategoriaVm();
            var categorias = await _repository.GetQueryAsync<Categoria>();

            articuloCategoriaVm.ListaDeCategorias = categorias.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nombre }).ToList();

            articuloCategoriaVm.Articulo = await _repository.FindFirstAsync<Articulo>(a => a.Id == id);

            if (articuloCategoriaVm == null)
            {
                return NotFound();
            }

            return View(articuloCategoriaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ArticuloCategoriaVm articuloVm)
        {
            if (articuloVm.Articulo.Id == 0)
            {
                return View(articuloVm);
            }
            _repository.UpdateAsync(articuloVm.Articulo);
            return RedirectToAction(nameof(Index));
        }
    }
}
