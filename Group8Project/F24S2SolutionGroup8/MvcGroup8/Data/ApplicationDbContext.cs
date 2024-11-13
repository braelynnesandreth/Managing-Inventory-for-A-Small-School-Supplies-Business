using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MvcGroup8.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //To migrate a new class to the database, need to add aproperty

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Manager> Manager { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<RestockOrder> RestockOrders { get; set; }

        public DbSet<Sale> Sale { get; set; }

        public DbSet<SaleDetail> SaleDetail { get; set; }

        public DbSet<SmallBusinessOwner> SmallBusinessOwner { get; set; }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<Supplier> Supplier { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
 
}


