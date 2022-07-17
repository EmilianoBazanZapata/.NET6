﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Datos;
using WebApi.Models;
using WebApi.Pagination;
using WebApi.Services;
using WebApi.ViewModels.Request;

namespace WebApi.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly ArticuloService _articuloService;

        public ArticuloController(ArticuloService articuloService, ApplicationDbContext context)
        {
            _articuloService = articuloService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber=1)
        {
            var articulosencontrados = await _articuloService.ListadoDeArticulos();
            var articulos = await PaginatedList<Articulo>.CreateAsync(articulosencontrados, pageNumber, 5);
            return View(articulos);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var articuloCategorias = await _articuloService.CrearArticulo();
            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                var result = await _articuloService.CrearArticulo(articulo);

                TempData["alerta"] = JsonConvert.SerializeObject(result);

                return RedirectToAction(nameof(Index));
            }
            return View(articulo);
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int id)
        {
            var result = await _articuloService.BorrarArticulo(id);
            TempData["alerta"] = JsonConvert.SerializeObject(result);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            var articuloCategoriaVm = await _articuloService.EditarArticulo(id);
            return View(articuloCategoriaVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ArticuloCategoriaViewModel articuloVm)
        {
            if (ModelState.IsValid)
            {
                var result = await _articuloService.EditarArticulo(articuloVm);
                TempData["alerta"] = JsonConvert.SerializeObject(result);
                return RedirectToAction(nameof(Index));
            }
            return View(articuloVm);
        }
    }
}