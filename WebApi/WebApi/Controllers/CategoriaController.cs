using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Datos;
using WebApi.Models;
using WebApi.Pagination;
using WebApi.Repository.Interfaces;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class CategoriaController : Controller
    {
        public readonly CategoriaService _categoriaService;

        //accedemos al DbContext
        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber=1)
        {
            var listaDeCategorias = await _categoriaService.ListadoDeCategorias();
            var categorias = await PaginatedList<Categoria>.CreateAsync(listaDeCategorias, pageNumber, 5);
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoriaService.AgregarCategoria(categoria);
                TempData["alerta"] = JsonConvert.SerializeObject(result);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var categoria = await _categoriaService.EditarCategoria(id);
            return View(categoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoriaService.EditarCategoria(categoria);
                TempData["alerta"] = JsonConvert.SerializeObject(result);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int Id)
        {
            await _categoriaService.BorrarCategoria(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
