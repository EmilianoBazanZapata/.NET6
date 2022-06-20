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
            List<Categoria> listaDeCategorias = _context.Categorias?.ToList();


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
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult CrearMultipleOpcion2()
        {
            List<Categoria> listaDeCategoria = new List<Categoria>();
            for (int i = 0; i < 2; i++)
            {
                listaDeCategoria.Add(new Categoria
                {
                    Nombre = Guid.NewGuid().ToString()
                });
                //_context.Categorias.AddAsync(new Categoria 
                //{ 
                //    Nombre = Guid.NewGuid().ToString() 
                //});
            }
            _context.AddRangeAsync(listaDeCategoria);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CrearMultipleOpcion5()
        {
            List<Categoria> listaDeCategoria = new List<Categoria>();
            for (int i = 0; i < 5; i++)
            {
                listaDeCategoria.Add(new Categoria
                {
                    Nombre = Guid.NewGuid().ToString()
                });
                //_context.Categorias.AddAsync(new Categoria 
                //{ 
                //    Nombre = Guid.NewGuid().ToString() 
                //});
            }
            _context.AddRangeAsync(listaDeCategoria);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
