using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Etiqueta
    {
        public int EtiquetaID { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un Titulo")]
        [MaxLength(20)]
        public string? Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha  { get; set; }

        //para relacion muchos a muchos
        public ICollection<ArticuloEtiqueta>? ArticuloEtiqueta { get; set; }
    }
}