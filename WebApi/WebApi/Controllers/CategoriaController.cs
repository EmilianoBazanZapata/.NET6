using Microsoft.AspNetCore.Mvc;
using WebApi.Datos;
using WebApi.Models;
using WebApi.Repository.Interfaces;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class CategoriaController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly CategoriaService _categoriaService;
        public readonly IRepository<Categoria> _repository;

        //accedemos al DbContext
        public CategoriaController(ApplicationDbContext context,
                                   CategoriaService categoriaService,
                                   IRepository<Categoria> repository)
        {
            _context = context;
            _categoriaService = categoriaService;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listaDeCategorias = await _categoriaService.ListadoDeCategorias();
            return View(listaDeCategorias);
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
                await _repository.CreateAsync(categoria);
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
                await _categoriaService.EditarCategoria(categoria);
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
