using Microsoft.AspNetCore.Mvc;
using WebApi.Datos;

namespace WebApi.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _contex;
        public UsuarioController(ApplicationDbContext context)
        {
            _contex = context;
        }
        public IActionResult Index()
        {
            var usuarios = _contex.Usuarios.ToList();
            return View(usuarios);
        }
    }
}
