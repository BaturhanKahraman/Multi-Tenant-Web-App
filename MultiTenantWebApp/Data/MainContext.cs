using Microsoft.EntityFrameworkCore;

namespace MultiTenantWebApp.Data
{
    public class MainContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=.\Data\main.db;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
