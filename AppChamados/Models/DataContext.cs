using Microsoft.EntityFrameworkCore;

namespace AppChamados.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> pOptions) : base(pOptions)
        {

        }

        public DbSet<Chamados> Chamado { get; set; }
       
    }
}