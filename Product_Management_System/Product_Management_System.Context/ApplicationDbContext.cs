using Microsoft.EntityFrameworkCore;
using Product_Management_System.Models;
using Product_Management_System.Models.Models;

namespace Product_Management_System.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
      
         public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

       

    }
}
