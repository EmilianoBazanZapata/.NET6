using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApi.Datos;
using WebApi.Models;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly ApplicationDbContext _contex;
        public ArticuloController(ApplicationDbContext context)
        {
            _contex = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var articulos = _contex.Articulos.ToList();
            return View(articulos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ArticuloCategoriaVm articuloCategorias = new ArticuloCategoriaVm();

            articuloCategorias.ListaDeCategorias = _contex.Categorias.Select(i => new SelectListItem
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
                _contex.Articulos.AddAsync(articulo);
                _contex.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ArticuloCategoriaVm articuloCategorias = new ArticuloCategoriaVm();

            articuloCategorias.ListaDeCategorias = _contex.Categorias.Select(i => new SelectListItem
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
            articuloCategoriaVm.ListaDeCategorias = _contex.Categorias.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.CategoriaId.ToString()
            });

            articuloCategoriaVm.Articulo = _contex.Articulos.FirstOrDefault(c => c.ArticuloId == id);

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
            _contex.Articulos.Update(articuloVm.Articulo);
            _contex.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var articulo = _contex.Articulos.FirstOrDefault(a=>a.ArticuloId == id);
            _contex.Articulos.Remove(articulo);
            _contex.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
