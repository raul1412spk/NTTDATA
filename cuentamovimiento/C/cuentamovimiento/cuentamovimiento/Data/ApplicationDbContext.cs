    using Microsoft.EntityFrameworkCore;
    using cuentamovimiento.Entities;
    using global::cuentamovimiento.Entities;
namespace cuentamovimiento.Data
{

    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Cuenta> Cuentas { get; set; }
            public DbSet<Movimiento> Movimientos { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configuraciones adicionales de modelo si las hay
            }
        }
    }


