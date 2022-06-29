using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Datos;
using WebApi.Models;

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

        [HttpGet]
        public IActionResult Detalle(int? Id)
        {
            if (Id == null)
            {
                return View();
            }
            var detalleUsuario = _context.Usuarios.Include(u => u.DetalleUsuario).FirstOrDefault(u => u.Id == Id);

            if (detalleUsuario is null)
            {
                return NotFound();
            }
            return View(detalleUsuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarDetalle(Usuario usuario)
        {

            if (usuario.DetalleUsuarioId != null)
            {
                //creamos el detalle 
                _context.DetalleUsuarios.Add(usuario.DetalleUsuario);
                _context.SaveChanges();

                //actualizamos la relacion
                var usuarioActual = _context.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);

                usuarioActual.DetalleUsuarioId = usuario.DetalleUsuarioId;
                _context.SaveChanges();
            }
            else
            {
                var detalleUsuario = usuario.DetalleUsuario;
                _context.DetalleUsuarios.Add(detalleUsuario);
                _context.SaveChanges();

                //actualizamos la relacion
                var usuarioActual = _context.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);

                usuarioActual.DetalleUsuarioId = detalleUsuario.DetalleUsuarioId;
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
