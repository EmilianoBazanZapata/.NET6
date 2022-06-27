using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Datos;
using WebApi.Models;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.Include(u => u.DetalleUsuario).ToList();
            return View(usuarios);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios?.AddAsync(usuario);
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

            var usuario = _context.Usuarios.FirstOrDefault(c => c.Id == id);
            return View(usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Borrar(int? Id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(c => c.Id == Id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
