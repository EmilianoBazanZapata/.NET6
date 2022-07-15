using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class EtiquetaController : Controller
    {
        private readonly EtiquetaService _etiquetaService;
        public EtiquetaController(EtiquetaService etiquetaService)
        {
            _etiquetaService = etiquetaService;
        }
        public async Task<IActionResult> Index()
        {
            var etiquetas = await _etiquetaService.LitadoDeEtiquetas();
            return View(etiquetas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                await _etiquetaService.CrearEtiqueta(etiqueta);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var etiqueta = await _etiquetaService.EditarEtiqueta(id);
            return View(etiqueta);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                await _etiquetaService.EditarEtiqueta(etiqueta);
                return RedirectToAction(nameof(Index));
            }
            return View(etiqueta);
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int id)
        {
            await _etiquetaService.BorrarEtiqueta(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
