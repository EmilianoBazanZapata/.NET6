using Microsoft.EntityFrameworkCore;

namespace WebApi.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options) 
        {

        }

        //Escribir los modelos
    }
}