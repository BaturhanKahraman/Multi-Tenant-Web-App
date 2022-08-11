using Microsoft.EntityFrameworkCore;

namespace MultiTenantWebApp.Data;

public class ProductDatabaseContext:DbContext
{
    public ProductDatabaseContext(DbContextOptions<ProductDatabaseContext> opt):base(opt)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    
    
}