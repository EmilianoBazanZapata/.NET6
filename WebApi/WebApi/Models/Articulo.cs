using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Articulo
    {
        public int ArticuloId { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un Titulo")]
        [MaxLength(20)]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "La Descripcion no debe superar los 500 Caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [Range(0.1, 0.5)]
        public double Calificacion { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }


        //relacion 
        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
        public Categoria? Categoria { get; set; }

        //para relacion muchos a muchos
        public ICollection<ArticuloEtiqueta>? ArticuloEtiqueta { get; set; }
    }
}
