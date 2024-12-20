using LibraryGroup8;
using LibraryGroup8.LibraryGroup8;
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
                AppUser adminUser = new AppUser("Admin", "User", "admin.user1@example.com", "admin.user1");

                userManager.CreateAsync(adminUser).Wait();
                userManager.AddToRoleAsync(adminUser, adminRole).Wait();

                if (!database.SmallBusinessOwner.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        SmallBusinessOwner owner = new SmallBusinessOwner($"Owner{i}", $"Last{i}", $"owner{i}@test.com", "OwnerPass123!");
                        userManager.CreateAsync(owner, "OwnerPass123!").Wait();
                        userManager.AddToRoleAsync(owner, smallBusinessOwnerRole).Wait();
                    }
                }

                // Seed Manager (5 rows)
                if (!database.Manager.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Manager manager = new Manager($"Manager{i}", $"Last{i}", $"manager{i}@test.com", "ManagerPass123!");
                        userManager.CreateAsync(manager, "ManagerPass123!").Wait();
                        userManager.AddToRoleAsync(manager, managerRole).Wait();
                    }
                }

                // Seed Staff (5 rows)
                if (!database.Staff.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Staff staff = new Staff($"Staff{i}", $"Last{i}", $"staff{i}@test.com", "StaffPass123!");
                        userManager.CreateAsync(staff, "StaffPass123!").Wait();
                        userManager.AddToRoleAsync(staff, staffRole).Wait();
                    }
                }

                // Seed Suppliers (5 rows)
                if (!database.Supplier.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Supplier supplier = new Supplier($"Supplier{i}", $"supplier{i}@example.com", new List<RestockOrder>());
                        database.Supplier.Add(supplier);
                    }
                    database.SaveChanges();
                }

                // Seed Products (5 rows) with the correct constructor
                if (!database.Product.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Product product = new Product(
                            $"Product{i}",
                            $"Description for Product{i}"
                        );
                        database.Product.Add(product);
                    }
                    database.SaveChanges();
                }

                // Seed Sales (5 rows) with the correct constructor for SaleDetail
                if (!database.Sale.Any())
                {
                    Staff sampleStaff = new Staff("John", "Doe", "john@example.com", "SamplePass123!");

                    // SaleDetail example setup
                    List<SaleDetail> saleDetails1 = new List<SaleDetail>
            {
                new SaleDetail(2, 10.99m, database.Product.First()),
                new SaleDetail(1, 5.49m, database.Product.Skip(1).First())
            };

                    List<SaleDetail> saleDetails2 = new List<SaleDetail>
            {
                new SaleDetail(3, 15.99m, database.Product.Skip(2).First()),
                new SaleDetail(2, 7.49m, database.Product.Skip(3).First())
            };

                    // Add 5 rows of Sale data
                    Sale sale;
                    sale = new Sale(DateTime.Now.AddDays(-5), sampleStaff, DateTime.Now.AddHours(-120), saleDetails1);
                    database.Sale.Add(sale);

                    sale = new Sale(DateTime.Now.AddDays(-4), sampleStaff, DateTime.Now.AddHours(-96), saleDetails2);
                    database.Sale.Add(sale);

                    sale = new Sale(DateTime.Now.AddDays(-3), sampleStaff, DateTime.Now.AddHours(-72), saleDetails1);
                    database.Sale.Add(sale);

                    sale = new Sale(DateTime.Now.AddDays(-2), sampleStaff, DateTime.Now.AddHours(-48), saleDetails2);
                    database.Sale.Add(sale);

                    sale = new Sale(DateTime.Now.AddDays(-1), sampleStaff, DateTime.Now.AddHours(-24), saleDetails1);
                    database.Sale.Add(sale);

                    database.SaveChanges();
                }

                // Seed Inventory History (5 rows)
                if (!database.InventoryHistory.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        InventoryHistory inventoryHistory = new InventoryHistory(
                            DateTime.Now.AddDays(-i),
                            i * 10,
                            i % 2 == 0 ? "Restock" : "Sale",
                            database.Product.First()
                        );
                        database.InventoryHistory.Add(inventoryHistory);
                    }
                    database.SaveChanges();
                }

                // Seed Restock Orders (5 rows)
                if (!database.RestockOrder.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        RestockOrder restockOrder = new RestockOrder(
                            DateTime.Now.AddDays(-i),
                            i % 2 == 0 ? "Completed" : "Pending",
                            database.Product.First(),
                            database.Supplier.First(),
                            new Manager("Manager", "Test", "manager@test.com", "ManagerPass123!")
                        );
                        database.RestockOrder.Add(restockOrder);
                    }
                    database.SaveChanges();
                }
            }
        }
    }
}

