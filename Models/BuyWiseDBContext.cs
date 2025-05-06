using Microsoft.EntityFrameworkCore;

namespace BuyWise.Models
{
    public class BuyWiseDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use SQLite database
            optionsBuilder.UseSqlServer("Data Source=EHAB;Initial Catalog=BuyWise;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
