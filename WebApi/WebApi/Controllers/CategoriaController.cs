using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //consulta inicial
            //List<Categoria> listaDeCategorias = _context.Categorias?.ToList();

            //consulta fiñltrando por fecha
            //DateTime fechaComparacion = new DateTime(2021,11,05);
            //List<Categoria> listaDeCategorias = _context.Categorias?.Where(f=>f.FechaCreacion >= fechaComparacion).OrderBy(f=>f.FechaCreacion).ToList();

            //return View(listaDeCategorias);

            //selecciona uno en particular
            //var categorias = _context.Categorias.Where(n=>n.Nombre == "Test 5").Select(n=>n).ToList();
            //agrupa activos y los que estan inactivos
            //var listaDeCategorias = _context.Categorias
            //                                .GroupBy(c => new {c.Activo})
            //                                .Select(c=> new { c.Key, Count = c.Count()}).ToList();

            //paginando 
            //List<Categoria> listaDeCategorias = _context.Categorias?.Take(5).ToList();

            //consulta sql
            //List<Categoria> listaDeCategorias = _context.Categorias?.FromSqlRaw("SELECT * FROM CATEGORIAS").ToList();

            //interpolacion de string 
            var id = 123;

            var categoria = _context.Categorias.FromSqlRaw("SELECT * FROM CATEGORIAS WHERE CATEGORIAID = {0} OR NOMBRE = {1}",id,"Categoria1");


            return View(categoria);
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
            List<Categoria> listaDeCategorias = new List<Categoria>();
            for (int i = 0; i < 2; i++)
            {
                listaDeCategorias.Add(new Categoria
                {
                    Nombre = Guid.NewGuid().ToString()
                });
                //_context.Categorias.AddAsync(new Categoria 
                //{ 
                //    Nombre = Guid.NewGuid().ToString() 
                //});
            }
            _context.AddRangeAsync(listaDeCategorias);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CrearMultipleOpcion5()
        {
            List<Categoria> listaDeCategorias = new List<Categoria>();
            for (int i = 0; i < 5; i++)
            {
                listaDeCategorias.Add(new Categoria
                {
                    Nombre = Guid.NewGuid().ToString()
                });
                //_context.Categorias.AddAsync(new Categoria 
                //{ 
                //    Nombre = Guid.NewGuid().ToString() 
                //});
            }
            _context.AddRangeAsync(listaDeCategorias);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult VistaCrearMultipleCategoria() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearMultipleOpcionFormulario() 
        {
            string categoriaForm = Request.Form["Nombre"];
            var listaCategorias = from val 
                                  in categoriaForm.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries) 
                                  select (val);

            List<Categoria> categorias = new List<Categoria>();

            foreach (var categoria in listaCategorias)
            {
                categorias.Add(new Categoria 
                {
                    Nombre = categoria
                });
            }
            _context.Categorias.AddRangeAsync(categorias);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int? id) 
        {
            if (id == null) 
            {
                return View();
            }

            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
            return View(categoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid) 
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Borrar(int? Id) 
        {
            var Categoria = _context.Categorias.FirstOrDefault(c=>c.CategoriaId == Id);
            _context.Categorias.Remove(Categoria);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult BorrarMultiple2()
        {
            IEnumerable<Categoria> categorias = _context.Categorias.OrderByDescending(c => c.CategoriaId).Take(2); 
            _context.Categorias.RemoveRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult BorrarMultiple5()
        {
            IEnumerable<Categoria> categorias = _context.Categorias.OrderByDescending(c => c.CategoriaId).Take(5);
            _context.Categorias.RemoveRange(categorias);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
