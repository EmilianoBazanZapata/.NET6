using Microsoft.AspNetCore.Mvc.Rendering;
using WebApi.Models;

namespace WebApi.ViewModels
{
    public class ArticuloCategoriaVm
    {
        public Articulo Articulo { get; set; }
        public IEnumerable<SelectListItem> ListaDeCategorias { get; set; }
    }
}
