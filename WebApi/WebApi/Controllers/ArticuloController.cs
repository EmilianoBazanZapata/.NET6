using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Datos;
using WebApi.Models;
using WebApi.Repository.Interfaces;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Articulo> _repository;
        private List<Expression<Func<Articulo, object>>> a;

        public ArticuloController(ApplicationDbContext context,
                                  IRepository<Articulo> repository)
        {
            _context = context;
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articulos = await _repository.GetQueryAsync<Articulo>(
                    predicate: a => a.SoftDelete == false,
                    include: a => a.Include(a => a.Categoria));

            return View(articulos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ArticuloCategoriaVm articuloCategorias = new ArticuloCategoriaVm();

            articuloCategorias.ListaDeCategorias = _context.Categorias.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
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
                Value = i.Id.ToString()
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
                Value = i.Id.ToString()
            });

            articuloCategoriaVm.Articulo = _context.Articulos.FirstOrDefault(c => c.Id == id);

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
            if (articuloVm.Articulo.Id == 0)
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
            var articulo = _context.Articulos.FirstOrDefault(a => a.Id == id);
            _context.Articulos.Remove(articulo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
