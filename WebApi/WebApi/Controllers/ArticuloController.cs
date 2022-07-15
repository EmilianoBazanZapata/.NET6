using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;
using WebApi.ViewModels.Request;

namespace WebApi.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly ArticuloService _articuloService;

        public ArticuloController(ArticuloService articuloService)
        {
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
                await _articuloService.CrearArticulo(articulo);
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
        public async Task<IActionResult> Editar(ArticuloCategoriaViewModel articuloVm)
        {
            if (ModelState.IsValid)
            {
                await _articuloService.EditarArticulo(articuloVm);
                return RedirectToAction(nameof(Index));
            }
            return View(articuloVm);
        }
    }
}