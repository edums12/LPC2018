using Associados.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Associados.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Associado> Associados { get; set; }
        
        public DbSet<Dependente> Dependentes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dependente>()
                .HasOne(d => d.associado)
                .WithMany(a => a.dependentes);

            // modelBuilder.Entity<HistoryRow>().Property(p => p.MigrationId).HasColumnName("MigrationId");
        }
    }
}