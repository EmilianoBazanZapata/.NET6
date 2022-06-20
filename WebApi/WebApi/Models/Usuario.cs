using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        [EmailAddress(ErrorMessage = "Ingrese un Email Correcto")]
        public string? Email { get; set; }

        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        public string? Direccion { get; set; }

        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        public int Edad { get; set; }

        [ForeignKey("DetalleUsuario")]
        public int DetalleUsuarioId { get; set; }
        public DetalleUsuario? DetalleUsuario { get; set; }

    }
}