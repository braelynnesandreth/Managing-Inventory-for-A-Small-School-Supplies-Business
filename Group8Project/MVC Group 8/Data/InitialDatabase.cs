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
                // Create Managers
                var managers = new List<Manager>
            {
                new Manager("Marcus", "Santiago", "marcussantiago@example.com", "Dolphins123"),
                new Manager("Sophie", "Henson", "sophiehenson@example.com", "StarryNight5"),
                new Manager("Olivia", "Brown", "oliviabrown@example.com", "Sunshine12"),
                new Manager("James", "Taylor", "jamestaylor@example.com", "Clouds45"),
                new Manager("Liam", "Walker", "liamwalker@example.com", "RainyDay9")
                };

                foreach (var manager in managers)
                {
                    userManager.CreateAsync(manager).Wait();
                    userManager.AddToRoleAsync(manager, managerRole).Wait();
                }

                // Create Small Business Owners and assign Managers
                var smallBusinessOwners = new List<SmallBusinessOwner>
                 {
                 new SmallBusinessOwner { Firstname = "Jordan", Lastname = "Whitaker", Email = "jordanwhitaker@example.com", UserName = "jordanwhitaker@example.com", Manager = managers[0] },
                 new SmallBusinessOwner { Firstname = "Brooke", Lastname = "Mesinere", Email = "brookemesinere@example.com", UserName = "brookemesinere@example.com", Manager = managers[1] },
                 new SmallBusinessOwner { Firstname = "Emma", Lastname = "Johnson", Email = "emmajohnson@example.com", UserName = "emmajohnson@example.com", Manager = managers[2] },
                 new SmallBusinessOwner { Firstname = "Ethan", Lastname = "Martinez", Email = "ethanmartinez@example.com", UserName = "ethanmartinez@example.com", Manager = managers[3] },
                 new SmallBusinessOwner { Firstname = "Sophia", Lastname = "White", Email = "sophiawhite@example.com", UserName = "sophiawhite@example.com", Manager = managers[4] }
                 };

                foreach (var smallBusinessOwner in smallBusinessOwners)
                {
                    smallBusinessOwnerUserManager.CreateAsync(smallBusinessOwner).Wait();
                    smallBusinessOwnerUserManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                }

                // Create AppUsers
                var appUsers = new List<AppUser>
                 {
                 new AppUser { Firstname = "Lucas", Lastname = "Scott", Email = "lucasscott@example.com", UserName = "lucasscott@example.com", PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Password1") },
                 new AppUser { Firstname = "Mia", Lastname = "Clark", Email = "miaclark@example.com", UserName = "miaclark@example.com", PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Password2") },
                 new AppUser { Firstname = "Noah", Lastname = "Harris", Email = "noahharris@example.com", UserName = "noahharris@example.com", PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Password3") },
                 new AppUser { Firstname = "Ava", Lastname = "Hall", Email = "avahall@example.com", UserName = "avahall@example.com", PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Password4") },
                 new AppUser { Firstname = "Isabella", Lastname = "Lewis", Email = "isabellalewis@example.com", UserName = "isabellalewis@example.com", PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Password5") }
                };

                // Assigning managers and staff members to a small business owner
                var managerForSmallBusinessOwner = database.Manager.FirstOrDefault(m => m.UserName == "Marcus");
                smallBusinessOwner.Manager = managerForSmallBusinessOwner;
                smallBusinessOwnerUserManager.UpdateAsync(smallBusinessOwner).Wait();

                foreach (var appUser in appUsers)
                {
                    userManager.CreateAsync(appUser).Wait();
                }
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
                
                Product product1 = new Product { Name = "Pencil", Description = "Standard wooden pencil", CurrentStock = 100, ReorderPoint = 20, MaxStock = 200 };
                database.Product.Add(product1);
                database.SaveChanges();  

                Supplier supplier1 = new Supplier { Name = "ABC Supplies", ContactInfo = "contact@abcsupplies.com", Product = product1 };
                database.Supplier.Add(supplier1);

                Product product2 = new Product { Name = "Notebook", Description = "Spiral notebook with 100 pages", CurrentStock = 150, ReorderPoint = 30, MaxStock = 300 };
                database.Product.Add(product2);
                database.SaveChanges();  

                Supplier supplier2 = new Supplier { Name = "XYZ Corp", ContactInfo = "sales@xyzcorp.com", Product = product2 };
                database.Supplier.Add(supplier2);

               

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


            if (!database.InventoryHistory.Any())
            {
                InventoryHistory inventoryHistory1 = new InventoryHistory { InventoryHistoryId = 1, Date = new DateTime(20204,1, 1), QuantityChange = 10, Reason = "Found a better price" };
                database.InventoryHistory.Add(inventoryHistory1);

                InventoryHistory inventoryHistory2 = new InventoryHistory { InventoryHistoryId = 2, Date = new DateTime(2024,4, 1), QuantityChange = 20, Reason = "Do not need it anympore" };
                database.InventoryHistory.Add(inventoryHistory2);

                InventoryHistory inventoryHistory3 = new InventoryHistory { InventoryHistoryId = 3, Date = new DateTime(2024,5,1), QuantityChange = 30, Reason = "Product broke in the delivery process" };
                database.InventoryHistory.Add(inventoryHistory3);

                InventoryHistory inventoryHistory4 = new InventoryHistory { InventoryHistoryId = 4, Date = new DateTime(2023,6,1), QuantityChange = 40, Reason = "Customer wanted the product in a different color" };
                database.InventoryHistory.Add(inventoryHistory4);

                InventoryHistory inventoryHistory5 = new InventoryHistory { InventoryHistoryId = 5, Date = new DateTime(2022,4, 1), QuantityChange = 50, Reason = "The size did not fix, too small" };
                database.InventoryHistory.Add(inventoryHistory5);

                database.SaveChanges();
            }


            if (!database.RestockOrder.Any())
            {
                List<Product> productList = new List<Product>();

                Product product =
                    database.Product
                    .Where(p => p.Name == "Pencil")
                    .First();
                productList.Add(product);

                product =
                    database.Product
                    .Where(p => p.Name == "Notebook")
                    .First();
                productList.Add(product);

                product =
                    database.Product
                    .Where(p => p.Name == "Pen")
                    .First();
                productList.Add(product);

                product =
                    database.Product
                    .Where(p => p.Name == "Eraser")
                    .First();
                productList.Add(product);

                product =
                    database.Product
                    .Where(p => p.Name == "Ruler")
                    .First();
                productList.Add(product);

                List<Supplier> supplierList = new List<Supplier>();

                Supplier supplier =
                    database.Supplier
                    .Where(su => su.Name == "ABC Supplies")
                    .First();
                supplierList.Add(supplier);

                supplier =
                    database.Supplier
                    .Where(su => su.Name == "XYZ Corp")
                    .First();
                supplierList.Add(supplier);

                supplier =
                    database.Supplier
                    .Where(su => su.Name == "Global Suppliers")
                    .First();
                supplierList.Add(supplier);

                supplier =
                    database.Supplier
                    .Where(su => su.Name == "Best Products")
                    .First();
                supplierList.Add(supplier);

                supplier =
                    database.Supplier
                    .Where(su => su.Name == "Top Gear Suppliers")
                    .First();
                supplierList.Add(supplier);

                DateTime date1 = new DateTime(2024, 6, 5);


                //Tried to use productList[0], supplierList[0] etc. and got errors
                RestockOrder restockOrder = new RestockOrder("Pencil", "ABC Supplies", date1, "In Transit");
                database.RestockOrder.Add(restockOrder);
                database.SaveChanges();

                DateTime date2 = new DateTime(2024, 4, 7);
                
                restockOrder = new RestockOrder("Notebook", "XYZ Corp", date2, "Delivered");
                database.RestockOrder.Add(restockOrder);
                database.SaveChanges();

                DateTime date3 = new DateTime(2024, 1, 2);

                restockOrder = new RestockOrder("Pen", "Global Suppliers", date3, "Ordered");
                database.RestockOrder.Add(restockOrder);
                database.SaveChanges();

                DateTime date4 = new DateTime(2023, 2, 1);

                restockOrder = new RestockOrder("Eraser", "Best Products", date4, "Delivered");
                database.RestockOrder.Add(restockOrder);
                database.SaveChanges();

                DateTime date5 = new DateTime(2022, 4, 9);

                restockOrder = new RestockOrder("Ruler", "Top Gear Suppliers", date5, "Ordered");
                database.RestockOrder.Add(restockOrder);
                database.SaveChanges();
            }
        }
    }
}




