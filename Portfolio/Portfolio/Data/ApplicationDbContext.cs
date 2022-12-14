using Microsoft.EntityFrameworkCore;
using Portfolio.Entities;

namespace Portfolio.Data
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyCollaborator>()
                .HasKey(cc => new { cc.CompanyId, cc.CollaboratorId });

            modelBuilder.Entity<CompanyCollaborator>()
                .HasOne(cc => cc.Company)
                .WithMany(c => c.CompanyCollaborators)
                .HasForeignKey(cc => cc.CompanyId);

            modelBuilder.Entity<CompanyCollaborator>()
                .HasOne(cc => cc.Collaborator)
                .WithMany(c => c.CompanyCollaborators)
                .HasForeignKey(cc => cc.CollaboratorId);
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Collaborator>? Collaborators { get; set; }
        public DbSet<CompanyCollaborator>? CompanyCollaborators { get; set; }
        public DbSet<Section>? Sections { get; set; }

    }
}
