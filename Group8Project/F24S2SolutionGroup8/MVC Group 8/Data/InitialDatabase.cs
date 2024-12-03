using LibraryGroup8;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


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

           // UserManager<SmallBusinessOwner> userManager
              //  services.GetRequiredService<UserManager<SmallBusinessOwner>>();


            RoleManager<IdentityRole> roleManager =
                services.GetRequiredService<RoleManager<IdentityRole>>();

            //UserManager<Manager> userManager = services.GetRequiredService<UserManager<Manager>>();


            string smallBusinessOwnerRole = "Small Business Owner";
            string managerRole = "Manager";
            string staffRole = "Staff";
            string adminRole = "Admin";

            if (!database.Roles.Any())
            {
                IdentityRole role = new IdentityRole(smallBusinessOwnerRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(managerRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(staffRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(adminRole);
                roleManager.CreateAsync(role).Wait();
            }


            if (!database.Users.Any())
            {
                // Create an admin user if no users exist
                AppUser adminUser = new AppUser( "Admin", "User","admin.user1@example.com", "admin.user1");

                userManager.CreateAsync(adminUser).Wait();
                 userManager.AddToRoleAsync(adminUser, adminRole).Wait();
                
            }

            if (!database.Manager.Any())
            {
                Manager manager = new Manager("Marcus", "Santiago", "marcussantiago@example.com", "Dolphins123");
                userManager.CreateAsync(manager).Wait();
                userManager.AddToRoleAsync(manager, managerRole).Wait();
               

                manager = new Manager("Sophie", "Henson", "sophiehenson@example.com", "StarryNight5");
                userManager.CreateAsync(manager).Wait();
                userManager.AddToRoleAsync(manager, managerRole).Wait();
                

                manager = new Manager("Olivia", "Brown", "oliviabrown@example.com", "Sunshine12");
                userManager.CreateAsync(manager).Wait();
                userManager.AddToRoleAsync(manager, managerRole).Wait();
               

                manager = new Manager("James", "Taylor", "jamestaylor@example.com", "Clouds45");
                userManager.CreateAsync(manager).Wait();
                userManager.AddToRoleAsync(manager, managerRole).Wait();
                

                manager = new Manager("Liam", "Walker", "liamwalker@example.com", "RainyDay9");
                userManager.CreateAsync(manager).Wait();
                userManager.AddToRoleAsync(manager, managerRole).Wait();
              
            }


            // Create Small Business Owners and assign Managers
            if (!database.SmallBusinessOwner.Any())
            {
                var managersList = database.Manager.ToList();
                
                SmallBusinessOwner smallBusinessOwner = new SmallBusinessOwner { Firstname = "Jordan", Lastname = "Whitaker", Email = "jordanwhitaker@example.com", UserName = "jordanwhitaker@example.com", ManagerId = managersList[0].Id };
                userManager.CreateAsync(smallBusinessOwner).Wait();
                userManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                

                smallBusinessOwner = new SmallBusinessOwner { Firstname = "Brooke", Lastname = "Mesinere", Email = "brookemesinere@example.com", UserName = "brookemesinere@example.com", ManagerId = managersList[1].Id };
                userManager.CreateAsync(smallBusinessOwner).Wait();
                userManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                

                smallBusinessOwner = new SmallBusinessOwner { Firstname = "Emma", Lastname = "Johnson", Email = "emmajohnson@example.com", UserName = "emmajohnson@example.com", ManagerId = managersList[2].Id };
                userManager.CreateAsync(smallBusinessOwner).Wait();
                userManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                

                smallBusinessOwner = new SmallBusinessOwner { Firstname = "Ethan", Lastname = "Martinez", Email = "ethanmartinez@example.com", UserName = "ethanmartinez@example.com", ManagerId = managersList[3].Id };
                userManager.CreateAsync(smallBusinessOwner).Wait();
                userManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                

                smallBusinessOwner = new SmallBusinessOwner { Firstname = "Sophia", Lastname = "White", Email = "sophiawhite@example.com", UserName = "sophiawhite@example.com", ManagerId = managersList[4].Id };
                userManager.CreateAsync(smallBusinessOwner).Wait();
                userManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                
            }






            if (!database.Staff.Any())
            {
                //this is how it should be 
               Staff staff = new Staff { Firstname = "John", Lastname = "Doe", Email = "john.doe@example.com", UserName = "john.doe@example.com", ManagerId = 1 };
                userManager.CreateAsync(staff).Wait();
                userManager.AddToRoleAsync(staff, staffRole).Wait();

                
                //change this to look like that^??
                staff = new Staff { Firstname = "John", Lastname = "Doe", Email = "john.doe@example.com", UserName = "john.doe@example.com", ManagerId = 1 };
                //var result1 =
                userManager.CreateAsync(staff, "Password123!").Wait();
                //if (result1.Succeeded)
                //{
                    userManager.AddToRoleAsync(staff, "Staff").Wait();
                //}
                database.Staff.Add(staff);

                staff = new Staff { Firstname = "Jane", Lastname = "Smith", Email = "jane.smith@example.com", UserName = "jane.smith@example.com", ManagerId = 1 };
                //var result2 =
                userManager.CreateAsync(staff, "Password123!").Wait();
                //if (result2.Succeeded)
                //{
                    userManager.AddToRoleAsync(staff, "Staff").Wait();
                //}
                database.Staff.Add(staff);

                staff = new Staff { Firstname = "Mark", Lastname = "Johnson", Email = "mark.johnson@example.com", UserName = "mark.johnson@example.com", ManagerId = 2 };
                //var result3 = 
                    userManager.CreateAsync(staff, "Password123!").Wait();
                //if (result3.Succeeded)
                //{
                    userManager.AddToRoleAsync(staff, "Staff").Wait();
                //}
                database.Staff.Add(staff);

                staff = new Staff { Firstname = "Lucy", Lastname = "Williams", Email = "lucy.williams@example.com", UserName = "lucy.williams@example.com", ManagerId = 3 };
                //var result4 = 
                    userManager.CreateAsync(staff, "Password123!").Wait();
                //if (result4.Succeeded)
                //{
                    userManager.AddToRoleAsync(staff, "Staff").Wait();
                //}
                database.Staff.Add(staff);

                staff = new Staff { Firstname = "Mason", Lastname = "Brown", Email = "mason.brown@example.com", UserName = "mason.brown@example.com", ManagerId = 4 };
                //var result5 = 
                    userManager.CreateAsync(staff, "Password123!").Wait();
                //if (result5.Succeeded)
                //{
                    userManager.AddToRoleAsync(staff, "Staff").Wait();
                //}
                database.Staff.Add(staff);

                database.SaveChanges();
            }



            if (!database.Product.Any())
            {
                Product product = new Product { Name = "Pencil", Description = "Standard wooden pencil", CurrentStock = 100, ReorderPoint = 20, MaxStock = 200 };
                database.Product.Add(product);

                product = new Product { Name = "Notebook", Description = "Spiral notebook with 100 pages", CurrentStock = 150, ReorderPoint = 30, MaxStock = 300 };
                database.Product.Add(product);

                product = new Product { Name = "Pen", Description = "Ballpoint pen", CurrentStock = 200, ReorderPoint = 40, MaxStock = 500 };
                database.Product.Add(product);

                product = new Product { Name = "Eraser", Description = "Rubber eraser", CurrentStock = 75, ReorderPoint = 15, MaxStock = 150 };
                database.Product.Add(product);

                product = new Product { Name = "Ruler", Description = "Plastic ruler 30 cm", CurrentStock = 50, ReorderPoint = 10, MaxStock = 100 };
                database.Product.Add(product);

                database.SaveChanges();
            }


            if (!database.Supplier.Any())
            {

                Product product = new Product { Name = "Pencil", Description = "Standard wooden pencil", CurrentStock = 100, ReorderPoint = 20, MaxStock = 200 };
                database.Product.Add(product);
                database.SaveChanges();

                Supplier supplier = new Supplier { Name = "ABC Supplies", ContactInfo = "contact@abcsupplies.com", Product = product };
                database.Supplier.Add(supplier);


                //Product product = database.Product.First();
                //Supplier supplier = new Supplier(product, "Walmart", "walmart@gmail.com");
                //database.Supplier.Add(supplier1);
                //database.SaveChanges();

                product = new Product { Name = "Notebook", Description = "Spiral notebook with 100 pages", CurrentStock = 150, ReorderPoint = 30, MaxStock = 300 };
                database.Product.Add(product);
                database.SaveChanges();

                supplier = new Supplier { Name = "XYZ Corp", ContactInfo = "sales@xyzcorp.com", Product = product };
                database.Supplier.Add(supplier);



                database.SaveChanges();
            }



            if (!database.Sale.Any())
            {
                Sale sale = new Sale { SaleDate = DateTime.Now, SaleTime = TimeSpan.FromHours(9), StaffId = 1 };
                database.Sale.Add(sale);

                sale = new Sale { SaleDate = DateTime.Now.AddDays(-1), SaleTime = TimeSpan.FromHours(10), StaffId = 2 };
                database.Sale.Add(sale);

                sale = new Sale { SaleDate = DateTime.Now.AddDays(-2), SaleTime = TimeSpan.FromHours(11), StaffId = 3 };
                database.Sale.Add(sale);

                sale = new Sale { SaleDate = DateTime.Now.AddDays(-3), SaleTime = TimeSpan.FromHours(12), StaffId = 4 };
                database.Sale.Add(sale);

                sale = new Sale { SaleDate = DateTime.Now.AddDays(-4), SaleTime = TimeSpan.FromHours(13), StaffId = 5 };
                database.Sale.Add(sale);

                database.SaveChanges();
            }


            if (!database.SaleDetail.Any())
            {
                SaleDetail saleDetail = new SaleDetail { SaleId = 1, ProductId = 1, Quantity = 10, UnitPrice = 1.50m };
                database.SaleDetail.Add(saleDetail);

                saleDetail = new SaleDetail { SaleId = 1, ProductId = 2, Quantity = 5, UnitPrice = 2.00m };
                database.SaleDetail.Add(saleDetail);

                saleDetail = new SaleDetail { SaleId = 2, ProductId = 3, Quantity = 3, UnitPrice = 1.25m };
                database.SaleDetail.Add(saleDetail);

                saleDetail = new SaleDetail { SaleId = 3, ProductId = 4, Quantity = 7, UnitPrice = 0.75m };
                database.SaleDetail.Add(saleDetail);

                saleDetail = new SaleDetail { SaleId = 4, ProductId = 5, Quantity = 2, UnitPrice = 1.10m };
                database.SaleDetail.Add(saleDetail);

                database.SaveChanges();
            }


            if (!database.InventoryHistory.Any())
            {
                InventoryHistory inventoryHistory = new InventoryHistory { InventoryHistoryId = 1, Date = new DateTime(20204, 1, 1), QuantityChange = 10, Reason = "Found a better price" };
                database.InventoryHistory.Add(inventoryHistory);

                inventoryHistory = new InventoryHistory { InventoryHistoryId = 2, Date = new DateTime(2024, 4, 1), QuantityChange = 20, Reason = "Do not need it anympore" };
                database.InventoryHistory.Add(inventoryHistory);

                inventoryHistory = new InventoryHistory { InventoryHistoryId = 3, Date = new DateTime(2024, 5, 1), QuantityChange = 30, Reason = "Product broke in the delivery process" };
                database.InventoryHistory.Add(inventoryHistory);

                inventoryHistory = new InventoryHistory { InventoryHistoryId = 4, Date = new DateTime(2023, 6, 1), QuantityChange = 40, Reason = "Customer wanted the product in a different color" };
                database.InventoryHistory.Add(inventoryHistory);

                inventoryHistory = new InventoryHistory { InventoryHistoryId = 5, Date = new DateTime(2022, 4, 1), QuantityChange = 50, Reason = "The size did not fix, too small" };
                database.InventoryHistory.Add(inventoryHistory);

                database.SaveChanges();
            }

            if (!database.RestockOrder.Any())
            {
                List<Product> productList = new List<Product>();

                // Add products to the product list
                Product product = database.Product.Where(p => p.Name == "Pencil").First();
                productList.Add(product);

                product = database.Product.Where(p => p.Name == "Notebook").First();
                productList.Add(product);

                product = database.Product.Where(p => p.Name == "Pen").First();
                productList.Add(product);

                product = database.Product.Where(p => p.Name == "Eraser").First();
                productList.Add(product);

                product = database.Product.Where(p => p.Name == "Ruler").First();
                productList.Add(product);

                List<Supplier> supplierList = new List<Supplier>();

                // Add suppliers to the supplier list
                Supplier supplier = database.Supplier.Where(su => su.Name == "ABC Supplies").First();
                supplierList.Add(supplier);

                supplier = database.Supplier.Where(su => su.Name == "XYZ Corp").First();
                supplierList.Add(supplier);

                supplier = database.Supplier.Where(su => su.Name == "Global Suppliers").First();
                supplierList.Add(supplier);

                supplier = database.Supplier.Where(su => su.Name == "Best Products").First();
                supplierList.Add(supplier);

                supplier = database.Supplier.Where(su => su.Name == "Top Gear Suppliers").First();
                supplierList.Add(supplier);

                DateTime date = new DateTime(2024, 6, 5);

                // Now use the actual Product and Supplier objects from the lists
                RestockOrder restockOrder = new RestockOrder(supplierList[0], productList[0], date, "In Transit");
                database.RestockOrder.Add(restockOrder);
                database.SaveChanges();

                date = new DateTime(2024, 4, 7);

                restockOrder = new RestockOrder(supplierList[1], productList[1], date, "Delivered");
                database.RestockOrder.Add(restockOrder);
                database.SaveChanges();

                date = new DateTime(2024, 1, 2);

                restockOrder = new RestockOrder(supplierList[2], productList[2], date, "Ordered");
                database.RestockOrder.Add(restockOrder);
                database.SaveChanges();

                date = new DateTime(2023, 2, 1);

                restockOrder = new RestockOrder(supplierList[3], productList[3], date, "Delivered");
                database.RestockOrder.Add(restockOrder);
                database.SaveChanges();

                date = new DateTime(2022, 4, 9);

                restockOrder = new RestockOrder(supplierList[4], productList[4], date, "Ordered");
                database.RestockOrder.Add(restockOrder);
                database.SaveChanges();
            }
        }
    }
}




