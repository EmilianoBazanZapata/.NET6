using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Escribir los modelos
        //Cuando crear migraciones : 
        //1- cuando se crea una nueva clase
        //2-cuando agregue una nueva propiedad
        //3-cuando modifique un valor de campo en la clase
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<DetalleUsuario> DetalleUsuarios { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloEtiqueta>()
                        .HasKey(ae => new { ae.EtiquetaID, ae.ArticuloId });

            //Siembra de Datos
            var categoria = new Categoria()
            {
                Id = 123,
                Nombre = "Categoria Generada en el DbContext",
                FechaCreacion = DateTime.Now.Date,
                Activo = true
            };

            modelBuilder.Entity<Categoria>().HasData(new Categoria[] { categoria });
            base.OnModelCreating(modelBuilder);

        }
    }
}