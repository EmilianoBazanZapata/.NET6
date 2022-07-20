using Microsoft.AspNetCore.Mvc.Rendering;
using WebApi.Models;

namespace WebApi.ViewModels.Response
{
    public class ArticuloEtiquetaViewModel
    {
        public ArticuloEtiqueta ArticuloEtiqueta { get; set; }
        public Articulo Articulo { get; set; }
        public IEnumerable<ArticuloEtiqueta> ListaArticuloEtiquetas { get; set; }
        public IEnumerable<SelectListItem> ListaEtiquetas { get; set; }
    }
}
