using Microsoft.EntityFrameworkCore;

namespace AppG1
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> pOptions) : base(pOptions)
        {}

        // public DbSet<T> ClassName { get; set; }
    }
}