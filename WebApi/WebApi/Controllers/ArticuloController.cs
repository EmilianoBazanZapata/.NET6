using Microsoft.AspNetCore.Mvc;
using WebApi.Datos;

namespace WebApi.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly ApplicationDbContext _contex;
        public ArticuloController(ApplicationDbContext context)
        {
            _contex = context;
        }
        public IActionResult Index()
        {
            var articulos = _contex.Articulos.ToList();
            return View(articulos);
        }
    }
}
