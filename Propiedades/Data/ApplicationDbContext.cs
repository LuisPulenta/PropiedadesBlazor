using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Propiedades.Modelos;

namespace Propiedades.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Agregar modelos
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<ImagenPropiedad> ImagenesPropiedad { get; set; }
    }
}
