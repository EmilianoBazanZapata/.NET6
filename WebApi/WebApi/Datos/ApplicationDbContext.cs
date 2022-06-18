using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options) 
        {

        }

        //Escribir los modelos
        //Cuando crear migraciones : 
        //1- cuando se crea una nueva clase
        //2-cuando agregue una nueva propiedad
        //3-cuando modifique un valor de campo en la clase
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
    }
}