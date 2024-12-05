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
                
                SmallBusinessOwner smallBusinessOwner = new SmallBusinessOwner ("Jordan", "Whitaker", "jordanwhitaker@example.com", "jordanwhitaker@example.com" );
                userManager.CreateAsync(smallBusinessOwner).Wait();
                userManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                

                smallBusinessOwner = new SmallBusinessOwner ( "Brooke", "Mesinere", "brookemesinere@example.com","brookemesinere@example.com");
                userManager.CreateAsync(smallBusinessOwner).Wait();
                userManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                

                smallBusinessOwner = new SmallBusinessOwner ( "Emma", "Johnson",  "emmajohnson@example.com", "emmajohnson@example.com" );
                userManager.CreateAsync(smallBusinessOwner).Wait();
                userManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                

                smallBusinessOwner = new SmallBusinessOwner ("Ethan", "Martinez", "ethanmartinez@example.com","ethanmartinez@example.com" );
                userManager.CreateAsync(smallBusinessOwner).Wait();
                userManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                

                smallBusinessOwner = new SmallBusinessOwner ("Sophia", "White", "sophiawhite@example.com", "sophiawhite@example.com" );
                userManager.CreateAsync(smallBusinessOwner).Wait();
                userManager.AddToRoleAsync(smallBusinessOwner, smallBusinessOwnerRole).Wait();
                
            }
            

            if (!database.Staff.Any())
            {
                
               Staff staff = new Staff ("John", "Doe", "john.doe@example.com", "john.doe@example.com", "Password123!");
                userManager.CreateAsync(staff).Wait();
                userManager.AddToRoleAsync(staff, staffRole).Wait();

                staff = new Staff ( "Jane",  "Smith", "jane.smith@example.com", "jane.smith@example.com", "Password123!" );
                userManager.CreateAsync(staff).Wait();
                userManager.AddToRoleAsync(staff, staffRole).Wait();

                staff = new Staff("Mark", "Johnson", "mark.smith@example.com", "mark.smith@example.com", "Password123!");
                userManager.CreateAsync(staff).Wait();
                userManager.AddToRoleAsync(staff, staffRole).Wait();

                staff = new Staff("Lucy", "Williams", "lucy.smith@example.com", "lucy.smith@example.com", "Password123!");
                userManager.CreateAsync(staff).Wait();
                userManager.AddToRoleAsync(staff, staffRole).Wait();

                staff = new Staff("Mason", "Brown", "mason.smith@example.com", "mason.smith@example.com", "Password123!");
                userManager.CreateAsync(staff).Wait();
                userManager.AddToRoleAsync(staff, staffRole).Wait();



                database.SaveChanges();
            }


            if (!database.Sale.Any())
            {
                Sale sale = new Sale { SaleDate = DateTime.Now, SaleTime = TimeSpan.FromHours(9), };
                database.Sale.Add(sale);

                sale = new Sale { SaleDate = DateTime.Now.AddDays(-1), SaleTime = TimeSpan.FromHours(10) };
                database.Sale.Add(sale);

                sale = new Sale { SaleDate = DateTime.Now.AddDays(-2), SaleTime = TimeSpan.FromHours(11) };
                database.Sale.Add(sale);

                sale = new Sale { SaleDate = DateTime.Now.AddDays(-3), SaleTime = TimeSpan.FromHours(12) };
                database.Sale.Add(sale);

                sale = new Sale { SaleDate = DateTime.Now.AddDays(-4), SaleTime = TimeSpan.FromHours(13) };
                database.Sale.Add(sale);

                database.SaveChanges();
            }



            if (!database.Product.Any())
            {
                Supplier supplier = database.Supplier.FirstOrDefault();

                Product product = new Product("Pencil", "Standard wooden pencil", 100, 20, 200, "ABC Supplies");
                database.Product.Add(product);
                database.SaveChanges();

                product = new Product ("Notebook", "Spiral notebook with 100 pages", 150, 30, 300, "Walmart");
                database.Product.Add(product);
                database.SaveChanges();

                product = new Product ("Pen","Ballpoint pen",200,40, 500, "Walmart");
                database.Product.Add(product);
                database.SaveChanges();

                product = new Product ("Eraser", "Rubber eraser", 75, 15, 150, "XYZ Corp" );
                database.Product.Add(product);
                database.SaveChanges();

                product = new Product ("Ruler", "Plastic ruler 30 cm", 50, 10, 100, "XYZ Corp");
                database.Product.Add(product);
                database.SaveChanges();

                database.SaveChanges();
            }


            if (!database.SaleDetail.Any())
            {
                SaleDetail saleDetail = new SaleDetail ( 10,  1.50m );
                database.SaleDetail.Add(saleDetail);

                saleDetail = new SaleDetail ( 5, 2.00m );
                database.SaleDetail.Add(saleDetail);

                saleDetail = new SaleDetail ( 3, 1.25m );
                database.SaleDetail.Add(saleDetail);

                saleDetail = new SaleDetail (7, 0.75m );
                database.SaleDetail.Add(saleDetail);

                saleDetail = new SaleDetail ( 2, 1.10m );
                database.SaleDetail.Add(saleDetail);

                database.SaveChanges();
            }


            if (!database.InventoryHistory.Any())
            {
                InventoryHistory inventoryHistory = new InventoryHistory ( new DateTime(20204, 1, 1), 10, "Found a better price" );
                database.InventoryHistory.Add(inventoryHistory);

                inventoryHistory = new InventoryHistory ( new DateTime(2024, 4, 1), 20, "Do not need it anympore" );
                database.InventoryHistory.Add(inventoryHistory);

                inventoryHistory = new InventoryHistory ( new DateTime(2024, 5, 1), 30,  "Product broke in the delivery process" );
                database.InventoryHistory.Add(inventoryHistory);

                inventoryHistory = new InventoryHistory (new DateTime(2023, 6, 1), 40, "Customer wanted the product in a different color" );
                database.InventoryHistory.Add(inventoryHistory);

                inventoryHistory = new InventoryHistory ( new DateTime(2022, 4, 1), 50, "The size did not fix, too small" );
                database.InventoryHistory.Add(inventoryHistory);

                database.SaveChanges();
            }


            if (!database.Supplier.Any())
            {
                Supplier supplier = new Supplier("Pencil", "ABC Supplies", "contact@abcsupplies.com");
                database.Supplier.Add(supplier);
                database.SaveChanges();

                supplier = new Supplier("Eraser", "XYZ Corp", "sales@xyzcorp.com");
                database.Supplier.Add(supplier);
                database.SaveChanges();

                supplier = new Supplier("Notebook", "Walmart", "walmart@gmail.com");
                database.Supplier.Add(supplier);
                database.SaveChanges();

                supplier = new Supplier("Pen", "Walmart", "walmart@gmail.com");
                database.Supplier.Add(supplier);
                database.SaveChanges();


                supplier = new Supplier("Ruler", "XYZ Corp", "sales@xyzcorp.com");
                database.Supplier.Add(supplier);
                database.SaveChanges();

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




