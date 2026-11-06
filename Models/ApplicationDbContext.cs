using Microsoft.EntityFrameworkCore;

namespace CatalogoProductos.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
