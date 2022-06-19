using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Tbl_Articulo")]
    public class Articulo
    {
        [Key]
        public int Articulo_Id { get; set; }
        [Column("TituloArticulo")]
        [Required(ErrorMessage = "Es necesario ingresar un Titulo")]
        [MaxLength(20)]
        public string? Titulo { get; set; }
        [StringLength(500, ErrorMessage = "La Descripcion no debe superar los 500 Caracteres")]
        public string? Descripcion { get; set; }
        [Range(0.1, 0.5)]
        public double Calificacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }


        //relacion 
        [ForeignKey("Categoria")]
        public int Categoria_ID { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
