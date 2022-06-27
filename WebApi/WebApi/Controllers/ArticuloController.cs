using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Datos;
using WebApi.Models;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ArticuloController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //opcion sin datos relacionados
            //var articulos = _contex.Articulos.ToList();

            //foreach (var articulo in articulos)
            //{
            //    //opcion con datos relacionados no es eficiente
            //    //articulo.Categoria = _contex.Categorias.FirstOrDefault(c => c.CategoriaId == articulo.CategoriaID);


            //    //carga explicita -> explicit load es mas eficiente
            //    _contex.Entry(articulo).Reference(c=>c.Categoria).Load();
            //}

            //opcion carga diligente -> Eager Loading
            var articulos = _context.Articulos.Include(c=>c.Categoria).ToList();

            return View(articulos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ArticuloCategoriaVm articuloCategorias = new ArticuloCategoriaVm();

            articuloCategorias.ListaDeCategorias = _context.Categorias.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.CategoriaId.ToString()
            });

            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Articulos.AddAsync(articulo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ArticuloCategoriaVm articuloCategorias = new ArticuloCategoriaVm();

            articuloCategorias.ListaDeCategorias = _context.Categorias.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.CategoriaId.ToString()
            });
            return View(articuloCategorias);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            ArticuloCategoriaVm articuloCategoriaVm = new ArticuloCategoriaVm();
            articuloCategoriaVm.ListaDeCategorias = _context.Categorias.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.CategoriaId.ToString()
            });

            articuloCategoriaVm.Articulo = _context.Articulos.FirstOrDefault(c => c.ArticuloId == id);

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
            if (articuloVm.Articulo.ArticuloId == 0)
            {
                return View(articuloVm);
            }
            _context.Articulos.Update(articuloVm.Articulo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var articulo = _context.Articulos.FirstOrDefault(a=>a.ArticuloId == id);
            _context.Articulos.Remove(articulo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
