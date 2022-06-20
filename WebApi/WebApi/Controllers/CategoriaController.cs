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

    }
}
