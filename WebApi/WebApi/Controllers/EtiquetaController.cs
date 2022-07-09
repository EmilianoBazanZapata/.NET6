using Microsoft.AspNetCore.Mvc;
using WebApi.Datos;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EtiquetaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EtiquetaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        { 
            var etiquetas = _context.Etiquetas.ToList();
            return View(etiquetas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                _context.Etiquetas?.AddAsync(etiqueta);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var etiqueta = _context.Etiquetas.FirstOrDefault(c => c.EtiquetaID == id);
            return View(etiqueta);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                _context.Etiquetas.Update(etiqueta);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(etiqueta);
        }

        [HttpGet]
        public IActionResult Borrar(int? Id)
        {
            var etiqueta = _context.Etiquetas.FirstOrDefault(c => c.EtiquetaID == Id);
            _context.Etiquetas.Remove(etiqueta);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
