using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Etiqueta
    {
        [Key]
        public int Etiqueta_ID { get; set; }
        public string? Titulo { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha  { get; set; }

        //para relacion muchos a muchos
        public ICollection<ArticuloEtiqueta>? ArticuloEtiqueta { get; set; }
    }
}