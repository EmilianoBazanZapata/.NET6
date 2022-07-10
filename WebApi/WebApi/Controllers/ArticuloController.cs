using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repository.Interfaces;
using WebApi.Services;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly IRepository<Articulo> _repository;
        private readonly ArticuloService _articuloService;

        public ArticuloController(IRepository<Articulo> repository,
                                  ArticuloService articuloService)
        {
            _repository = repository;
            _articuloService = articuloService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articulos = await _articuloService.ListadoDeArticulos();
            return View(articulos);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var articuloCategorias = await _articuloService.CrearArticulo();
            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Articulo articulo)
        {
            if (ModelState.IsValid) 
            {
                await _repository.CreateAsync(articulo);
                return RedirectToAction(nameof(Index));
            }
            return View(articulo); 
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int id)
        {
            await _articuloService.BorrarArticulo(id);  
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            var articuloCategoriaVm = await _articuloService.EditarArticulo(id);
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
