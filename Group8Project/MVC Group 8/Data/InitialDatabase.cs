using LibraryGroup8;
using Microsoft.AspNetCore.Identity;
using static System.Formats.Asn1.AsnWriter;

namespace MVC_Group_8.Data
{
    public class InitialDatabase
    {
        public static void SeedDatabase(IServiceProvider services)
        {
            ApplicationDbContext database =
                services.GetRequiredService<ApplicationDbContext>();

            UserManager<AppUser> userManager =
                services.GetRequiredService<UserManager<AppUser>>();

            UserManager<SmallBusinessOwner> smallBusinessOwnerUserManager =
                services.GetRequiredService<UserManager<SmallBusinessOwner>>();


            RoleManager<IdentityRole> roleManager =
                services.GetRequiredService<RoleManager<IdentityRole>>();



            string smallBusinessOwnerRole = "Small Business Owner";
            string managerRole = "Manager";
            string staffRole = "Staff";

            if (!database.Roles.Any())
            {
                IdentityRole role = new IdentityRole(smallBusinessOwnerRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(managerRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(staffRole);
                roleManager.CreateAsync(role).Wait();



            }


            if (!database.Users.Any())
            {

                // Create Small Business Owners
                SmallBusinessOwner smallBusinessOwner = new SmallBusinessOwner("Brooke", "Mesinere", "brookemesinere@example.com", "Rainforest45");
                smallBusinessOwnerUserManager.CreateAsync(smallBusinessOwner).Wait();
                smallBusinessOwnerUserManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();

                smallBusinessOwner = new SmallBusinessOwner("Jordan", "Whitaker", "jordanwhitaker@example.com", "Rainbows34");
                smallBusinessOwnerUserManager.CreateAsync(smallBusinessOwner).Wait();
                smallBusinessOwnerUserManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();

                // Create Managers
                Manager manager = new Manager("Marcus", "Santiago", "marcussantiago@example.com", "Dolphins123");
                userManager.CreateAsync(manager).Wait();
                userManager.AddToRoleAsync(manager, managerRole).Wait();

                manager = new Manager("Sophie", "Henson", "sophiehenson@example.com", "StarryNight5");
                userManager.CreateAsync(manager).Wait();
                userManager.AddToRoleAsync(manager, managerRole).Wait();

                // Create Staff Members
                Staff staff = new Staff("Liam", "Chen", "liamchen@example.com", "Football123");
                userManager.CreateAsync(staff).Wait();
                userManager.AddToRoleAsync(staff, staffRole).Wait();

                staff = new Staff("Emma", "Caldwell", "emmacaldwell@example.com", "Butterflies45");
                userManager.CreateAsync(staff).Wait();
                userManager.AddToRoleAsync(staff, staffRole).Wait();


                // Assigning managers and staff members to a small business owner
                var managerForSmallBusinessOwner = database.Manager.FirstOrDefault(m => m.UserName == "Marcus");
                smallBusinessOwner.Manager = managerForSmallBusinessOwner;
                smallBusinessOwnerUserManager.UpdateAsync(smallBusinessOwner).Wait();

                // Set staff for the manager
                var staffForManager = database.Staff.FirstOrDefault(s => s.UserName == "Liam");
                manager.StaffMembers.Add(staffForManager);
                userManager.UpdateAsync(manager).Wait();
            }
            if (!database.Staff.Any())
            {
                Staff staff1 = new Staff { Firstname = "John", Lastname = "Doe", Email = "john.doe@example.com", UserName = "john.doe@example.com", ManagerId = 1 };
                var result1 = userManager.CreateAsync(staff1, "Password123!").Result;
                if (result1.Succeeded)
                {
                    userManager.AddToRoleAsync(staff1, "Staff").Wait();
                }
                database.Staff.Add(staff1);

                Staff staff2 = new Staff { Firstname = "Jane", Lastname = "Smith", Email = "jane.smith@example.com", UserName = "jane.smith@example.com", ManagerId = 1 };
                var result2 = userManager.CreateAsync(staff2, "Password123!").Result;
                if (result2.Succeeded)
                {
                    userManager.AddToRoleAsync(staff2, "Staff").Wait();
                }
                database.Staff.Add(staff2);

                Staff staff3 = new Staff { Firstname = "Mark", Lastname = "Johnson", Email = "mark.johnson@example.com", UserName = "mark.johnson@example.com", ManagerId = 2 };
                var result3 = userManager.CreateAsync(staff3, "Password123!").Result;
                if (result3.Succeeded)
                {
                    userManager.AddToRoleAsync(staff3, "Staff").Wait();
                }
                database.Staff.Add(staff3);

                Staff staff4 = new Staff { Firstname = "Lucy", Lastname = "Williams", Email = "lucy.williams@example.com", UserName = "lucy.williams@example.com", ManagerId = 3 };
                var result4 = userManager.CreateAsync(staff4, "Password123!").Result;
                if (result4.Succeeded)
                {
                    userManager.AddToRoleAsync(staff4, "Staff").Wait();
                }
                database.Staff.Add(staff4);

                Staff staff5 = new Staff { Firstname = "Mason", Lastname = "Brown", Email = "mason.brown@example.com", UserName = "mason.brown@example.com", ManagerId = 4 };
                var result5 = userManager.CreateAsync(staff5, "Password123!").Result;
                if (result5.Succeeded)
                {
                    userManager.AddToRoleAsync(staff5, "Staff").Wait();
                }
                database.Staff.Add(staff5);

                database.SaveChanges();
            }

           
            if (!database.Supplier.Any())
            {
                Supplier supplier1 = new Supplier { Name = "ABC Supplies", ContactInfo = "contact@abcsupplies.com" };
                database.Supplier.Add(supplier1);

                Supplier supplier2 = new Supplier { Name = "XYZ Corp", ContactInfo = "sales@xyzcorp.com" };
                database.Supplier.Add(supplier2);

                Supplier supplier3 = new Supplier { Name = "Global Suppliers", ContactInfo = "info@globalsuppliers.com" };
                database.Supplier.Add(supplier3);

                Supplier supplier4 = new Supplier { Name = "Best Products", ContactInfo = "support@bestproducts.com" };
                database.Supplier.Add(supplier4);

                Supplier supplier5 = new Supplier { Name = "Top Gear Suppliers", ContactInfo = "service@topgear.com" };
                database.Supplier.Add(supplier5);

                database.SaveChanges();
            }

            
            if (!database.Product.Any())
            {
                Product product1 = new Product { Name = "Pencil", Description = "Standard wooden pencil", CurrentStock = 100, ReorderPoint = 20, MaxStock = 200 };
                database.Product.Add(product1);

                Product product2 = new Product { Name = "Notebook", Description = "Spiral notebook with 100 pages", CurrentStock = 150, ReorderPoint = 30, MaxStock = 300 };
                database.Product.Add(product2);

                Product product3 = new Product { Name = "Pen", Description = "Ballpoint pen", CurrentStock = 200, ReorderPoint = 40, MaxStock = 500 };
                database.Product.Add(product3);

                Product product4 = new Product { Name = "Eraser", Description = "Rubber eraser", CurrentStock = 75, ReorderPoint = 15, MaxStock = 150 };
                database.Product.Add(product4);

                Product product5 = new Product { Name = "Ruler", Description = "Plastic ruler 30 cm", CurrentStock = 50, ReorderPoint = 10, MaxStock = 100 };
                database.Product.Add(product5);

                database.SaveChanges();
            }

            
            if (!database.Sale.Any())
            {
                Sale sale1 = new Sale { SaleDate = DateTime.Now, SaleTime = TimeSpan.FromHours(9), StaffId = 1 };
                database.Sale.Add(sale1);

                Sale sale2 = new Sale { SaleDate = DateTime.Now.AddDays(-1), SaleTime = TimeSpan.FromHours(10), StaffId = 2 };
                database.Sale.Add(sale2);

                Sale sale3 = new Sale { SaleDate = DateTime.Now.AddDays(-2), SaleTime = TimeSpan.FromHours(11), StaffId = 3 };
                database.Sale.Add(sale3);

                Sale sale4 = new Sale { SaleDate = DateTime.Now.AddDays(-3), SaleTime = TimeSpan.FromHours(12), StaffId = 4 };
                database.Sale.Add(sale4);

                Sale sale5 = new Sale { SaleDate = DateTime.Now.AddDays(-4), SaleTime = TimeSpan.FromHours(13), StaffId = 5 };
                database.Sale.Add(sale5);

                database.SaveChanges();
            }

            
            if (!database.SaleDetail.Any())
            {
                SaleDetail saleDetail1 = new SaleDetail { SaleId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1.50m };
                database.SaleDetail.Add(saleDetail1);

                SaleDetail saleDetail2 = new SaleDetail { SaleId = 1, ProductId = 2, Quantity = 5, UnitPrice = 2.00m };
                database.SaleDetail.Add(saleDetail2);

                SaleDetail saleDetail3 = new SaleDetail { SaleId = 2, ProductId = 3, Quantity = 3, UnitPrice = 1.25m };
                database.SaleDetail.Add(saleDetail3);

                SaleDetail saleDetail4 = new SaleDetail { SaleId = 3, ProductId = 4, Quantity = 7, UnitPrice = 0.75m };
                database.SaleDetail.Add(saleDetail4);

                SaleDetail saleDetail5 = new SaleDetail { SaleId = 4, ProductId = 5, Quantity = 2, UnitPrice = 1.10m };
                database.SaleDetail.Add(saleDetail5);

                database.SaveChanges();
            }
        }
    }
}




