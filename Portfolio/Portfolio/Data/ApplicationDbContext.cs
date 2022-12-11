using Microsoft.EntityFrameworkCore;
using Portofolio.Entities;

namespace Portofolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PortfolioDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Company>? Companies { get; set; }

    }
}
