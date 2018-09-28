using AppG1.Models;
using Microsoft.EntityFrameworkCore;

namespace AppG1
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> pOptions) : base(pOptions)
        {}

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Consulta> Consulta { get; set; }

        public DbSet<Convenio> Convenio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.convenio)
                .WithMany(c => c.pacientes);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.paciente)
                .WithMany(p => p.consultas);
        }
    }
}   