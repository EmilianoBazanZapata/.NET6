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
        public DbSet<Categoria> Categorias { get; set; }

    }
}