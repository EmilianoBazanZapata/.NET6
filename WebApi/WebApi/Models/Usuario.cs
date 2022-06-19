using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        //[RegularExpression(@"^[\w-\._\%]+@(?:[\w-]+\.)+[\w]{2,6}$",ErrorMessage = "Ingrese un Email Correcto")]
        [EmailAddress(ErrorMessage = "Ingrese un Email Correcto")]
        public string? Email { get; set; }
        [Display(Name = "Dirección del Usuario")]
        public string? Direccion { get; set; }
        [NotMapped]
        public int Edad { get; set; }

        [ForeignKey("DetalleUsuario")]
        public int DetalleUsuarioId { get; set; }
        public DetalleUsuario? DetalleUsuario { get; set; }

    }
}
