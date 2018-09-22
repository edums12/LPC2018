using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppChamados.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> pOptions) : base(pOptions)
        {

        }

        public DbSet<Chamados> Chamado { get; set; }

        public DbSet<Solicitante> Solicitante { get; set; }

        public DbSet<Situacoes> Situacoes { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chamados>()
                .HasOne(c => c.solicitante)
                .WithMany(s => s.chamados)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chamados>()
                .HasOne(c => c.situacao)
                .WithMany(s => s.chamados);
        }

    }
}