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
    }
}
