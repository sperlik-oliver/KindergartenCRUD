using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class KinderGartenContext : DbContext
    {
        public DbSet<Child> Children { get; set; }
        
        public DbSet<Toy> Toys { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Kindergarten.db");
        }
    }
}