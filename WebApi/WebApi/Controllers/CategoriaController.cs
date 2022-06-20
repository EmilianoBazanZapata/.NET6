using Microsoft.AspNetCore.Mvc;
using WebApi.Datos;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CategoriaController : Controller
    {
        public readonly ApplicationDbContext _context;

        //accedemos al DbContext
        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Categoria>? listaDeCategorias = _context.Categorias?.ToList();   


            return View(listaDeCategorias);
        }

        [HttpGet]
        public IActionResult Crear() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria) 
        {
            if (ModelState.IsValid) 
            {
                _context.Categorias?.AddAsync(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
