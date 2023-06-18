using CashFlow.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CashFlow.Infrastructure.Database
{
    public class MovementContext : DbContext
    {
        public DbSet<Movement> Movements { get; set; }

        public MovementContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovementContext).Assembly);
        }

        public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<MovementContext>
        {
            public MovementContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<MovementContext>()
                    .UseSqlServer("Server=.;Initial Catalog=MovementDb;Integrated Security=true");

                return new MovementContext(optionsBuilder.Options);
            }
        }
    }
}
