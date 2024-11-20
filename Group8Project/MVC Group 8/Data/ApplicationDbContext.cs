using LibraryGroup8;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MVC_Group_8.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<SmallBusinessOwner> SmallBusinessOwner { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleDetail> SaleDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<InventoryHistory> InventoryHistory { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<RestockOrder> RestockOrder { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }
    }
}


