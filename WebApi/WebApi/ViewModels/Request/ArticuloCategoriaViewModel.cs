using Microsoft.AspNetCore.Mvc.Rendering;
using WebApi.Models;

namespace WebApi.ViewModels.Request
{
    public class ArticuloCategoriaViewModel
    {
        public Articulo Articulo { get; set; }
        public IEnumerable<SelectListItem> ListaDeCategorias { get; set; }
    }
}
