using Microsoft.EntityFrameworkCore;
using AppPeople.Models;

namespace AppPeopleEF.Models
{
    public class DataContext : DbContext
    {

        public DbSet<Person> People { get; set; }

        public DataContext(DbContextOptions<DataContext> pOption) 
        : base(pOption)
        {}

    }
}