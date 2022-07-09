using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class DetalleUsuario
    {
        public int DetalleUsuarioId { get; set; }

        [MaxLength(100)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        public string Cedula { get; set; }

        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        public string Deporte { get; set; }

        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        public string Mascota { get; set; }

        public Usuario Usuario { get; set; }
    }
}
