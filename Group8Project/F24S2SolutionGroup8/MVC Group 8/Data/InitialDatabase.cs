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

                        SmallBusinessOwner owner1 = new SmallBusinessOwner($"Owner1", $"Last1", $"owner1@test.com", "OwnerPass123!");
                        userManager.CreateAsync(owner1, "OwnerPass123!").Wait();
                        userManager.AddToRoleAsync(owner1, smallBusinessOwnerRole).Wait();

                        SmallBusinessOwner owner2 = new SmallBusinessOwner($"Owner2", $"Last2", $"owner2@test.com", "OwnerPass123!");
                        userManager.CreateAsync(owner2, "OwnerPass123!").Wait();
                        userManager.AddToRoleAsync(owner2, smallBusinessOwnerRole).Wait();

                        SmallBusinessOwner owner3 = new SmallBusinessOwner($"Owner3", $"Last3", $"owner3@test.com", "OwnerPass123!");
                        userManager.CreateAsync(owner3, "OwnerPass123!").Wait();
                        userManager.AddToRoleAsync(owner3, smallBusinessOwnerRole).Wait();

                        SmallBusinessOwner owner4 = new SmallBusinessOwner($"Owner4", $"Last4", $"owner4@test.com", "OwnerPass123!");
                        userManager.CreateAsync(owner4, "OwnerPass123!").Wait();
                        userManager.AddToRoleAsync(owner4, smallBusinessOwnerRole).Wait();

                        SmallBusinessOwner owner5 = new SmallBusinessOwner($"Owner5", $"Last5", $"owner5@test.com", "OwnerPass123!");
                        userManager.CreateAsync(owner5, "OwnerPass123!").Wait();
                        userManager.AddToRoleAsync(owner5, smallBusinessOwnerRole).Wait();
                    }
                }

                if (!database.Manager.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Manager manager = new Manager($"Manager{i}", $"Last{i}", $"manager{i}@test.com", "ManagerPass123!");
                        userManager.CreateAsync(manager, "ManagerPass123!").Wait();
                        userManager.AddToRoleAsync(manager, managerRole).Wait();

                        var manager1 = new Manager($"Manager1", $"Last1", $"manager1@test.com", "ManagerPass123!");
                        userManager.CreateAsync(manager1, "ManagerPass123!").Wait();
                        userManager.AddToRoleAsync(manager1, managerRole).Wait();

                        var manager2 = new Manager($"Manager2", $"Last2", $"manager2@test.com", "ManagerPass123!");
                        userManager.CreateAsync(manager2, "ManagerPass123!").Wait();
                        userManager.AddToRoleAsync(manager2, managerRole).Wait();

                        var manager3 = new Manager($"Manager3", $"Last3", $"manager3@test.com", "ManagerPass123!");
                        userManager.CreateAsync(manager3, "ManagerPass123!").Wait();
                        userManager.AddToRoleAsync(manager3, managerRole).Wait();

                        var manager4 = new Manager($"Manager4", $"Last4", $"manager4@test.com", "ManagerPass123!");
                        userManager.CreateAsync(manager4, "ManagerPass123!").Wait();
                        userManager.AddToRoleAsync(manager4, managerRole).Wait();
                    }
                }

                if (!database.Staff.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Staff staff = new Staff($"Staff{i}", $"Last{i}", $"staff{i}@test.com", "StaffPass123!");
                        userManager.CreateAsync(staff, "StaffPass123!").Wait();
                        userManager.AddToRoleAsync(staff, staffRole).Wait();

                        Staff staff1 = new Staff($"Staff1", $"Last1", $"staff1@test.com", "StaffPass123!");
                        userManager.CreateAsync(staff1, "StaffPass123!").Wait();
                        userManager.AddToRoleAsync(staff1, staffRole).Wait();

                        Staff staff2 = new Staff($"Staff2", $"Last2", $"staff2@test.com", "StaffPass123!");
                        userManager.CreateAsync(staff2, "StaffPass123!").Wait();
                        userManager.AddToRoleAsync(staff2, staffRole).Wait();

                        Staff staff3 = new Staff($"Staff3", $"Last3", $"staff3@test.com", "StaffPass123!");
                        userManager.CreateAsync(staff3, "StaffPass123!").Wait();
                        userManager.AddToRoleAsync(staff3, staffRole).Wait();

                        Staff staff4 = new Staff($"Staff4", $"Last4", $"staff4@test.com", "StaffPass123!");
                        userManager.CreateAsync(staff4, "StaffPass123!").Wait();
                        userManager.AddToRoleAsync(staff4, staffRole).Wait();
                    }
                }

                if (!database.Supplier.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Supplier supplier = new Supplier($"Supplier{i}", $"supplier{i}@example.com", new List<RestockOrder>());
                        database.Supplier.Add(supplier);

                        Supplier supplier6 = new Supplier($"Supplier6", $"supplier6@example.com", new List<RestockOrder>());
                        database.Supplier.Add(supplier6);

                        Supplier supplier7 = new Supplier($"Supplier7", $"supplier7@example.com", new List<RestockOrder>());
                        database.Supplier.Add(supplier7);

                        Supplier supplier8 = new Supplier($"Supplier8", $"supplier8@example.com", new List<RestockOrder>());
                        database.Supplier.Add(supplier8);

                        Supplier supplier9 = new Supplier($"Supplier9", $"supplier9@example.com", new List<RestockOrder>());
                        database.Supplier.Add(supplier9);
                    }
                    database.SaveChanges();
                }


                if (!database.Product.Any())
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Product product = new Product(
                            $"Product{i}",
                            $"Description for Product{i}"
                        );
                        database.Product.Add(product);
                        Product product6 = new Product(
                         $"Product6",
                         $"Description for Product6"
                            );
                        database.Product.Add(product6);

                        Product product7 = new Product(
                            $"Product7",
                            $"Description for Product7"
                        );
                        database.Product.Add(product7);

                        Product product8 = new Product(
                            $"Product8",
                            $"Description for Product8"
                        );
                        database.Product.Add(product8);

                        Product product9 = new Product(
                            $"Product9",
                            $"Description for Product9"
                        );
                        database.Product.Add(product9);
                    }
                    database.SaveChanges();
                }

                if (!database.Sale.Any())
                {

                    Staff sampleStaff1 = new Staff("Alice", "Smith", "alice@example.com", "SamplePass123!");
                    Staff sampleStaff2 = new Staff("Bob", "Johnson", "bob@example.com", "SamplePass123!");
                    Staff sampleStaff3 = new Staff("Charlie", "Brown", "charlie@example.com", "SamplePass123!");
                    Staff sampleStaff4 = new Staff("Diana", "White", "diana@example.com", "SamplePass123!");


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

                    List<SaleDetail> saleDetails3 = new List<SaleDetail>
                        {
                            new SaleDetail(4, 12.99m, database.Product.Skip(4).First()),
                            new SaleDetail(1, 6.49m, database.Product.Skip(5).First())
                        };

                    List<SaleDetail> saleDetails4 = new List<SaleDetail>
                    {
                        new SaleDetail(2, 9.99m, database.Product.Skip(6).First()),
                        new SaleDetail(3, 8.49m, database.Product.Skip(7).First())
                    };


                    Sale sale;
                    sale = new Sale(DateTime.Now.AddDays(-5), sampleStaff1, DateTime.Now.AddHours(-120), saleDetails1);
                    database.Sale.Add(sale);

                    sale = new Sale(DateTime.Now.AddDays(-4), sampleStaff2, DateTime.Now.AddHours(-96), saleDetails2);
                    database.Sale.Add(sale);

                    sale = new Sale(DateTime.Now.AddDays(-3), sampleStaff3, DateTime.Now.AddHours(-72), saleDetails3);
                    database.Sale.Add(sale);

                    sale = new Sale(DateTime.Now.AddDays(-2), sampleStaff4, DateTime.Now.AddHours(-48), saleDetails4);
                    database.Sale.Add(sale);

                    sale = new Sale(DateTime.Now.AddDays(-1), sampleStaff1, DateTime.Now.AddHours(-24), saleDetails1);
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


                    for (int i = 6; i <= 10; i++)
                    {
                        InventoryHistory inventoryHistory = new InventoryHistory(
                            DateTime.Now.AddDays(-i),
                            i * 15,
                            i % 2 == 0 ? "Restock" : "Sale",
                            database.Product.Skip(i - 1).First()
                        );

                        database.InventoryHistory.Add(inventoryHistory);
                    }


                    for (int i = 11; i <= 15; i++)
                    {
                        InventoryHistory inventoryHistory = new InventoryHistory(
                            DateTime.Now.AddDays(-i),
                            i * 20,
                            i % 2 == 0 ? "Sale" : "Restock",
                            database.Product.Skip(i - 1).First()
                        );

                        database.InventoryHistory.Add(inventoryHistory);
                    }


                    for (int i = 16; i <= 20; i++)
                    {
                        InventoryHistory inventoryHistory = new InventoryHistory(
                            DateTime.Now.AddDays(-i),
                            i * 5,
                            i % 2 == 0 ? "Sale" : "Restock",
                            database.Product.Skip(i - 1).First()
                        );

                        database.InventoryHistory.Add(inventoryHistory);
                    }


                    for (int i = 21; i <= 25; i++)
                    {
                        InventoryHistory inventoryHistory = new InventoryHistory(
                            DateTime.Now.AddDays(-i),
                            i * 8,
                            i % 2 == 0 ? "Restock" : "Sale",
                            database.Product.Skip(i - 1).First()
                        );

                        database.InventoryHistory.Add(inventoryHistory);
                    }


                    database.SaveChanges();



                 
                    if (!database.RestockOrder.Any())
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            RestockOrder restockOrder = new RestockOrder(
                                DateTime.Now.AddDays(-i),                                      
                                i % 2 == 0 ? RestockOrder.RestockOrderStatus.Completed : RestockOrder.RestockOrderStatus.Pending, 
                                database.Product.First(),                                       
                                database.Supplier.First(),                                     
                                new Manager("Manager", "Test", "manager@test.com", "ManagerPass123!") 
                            );

                            database.RestockOrder.Add(restockOrder);
                        }

                        
                        for (int i = 6; i <= 10; i++)
                        {
                            RestockOrder restockOrder = new RestockOrder(
                                DateTime.Now.AddDays(-i),                                     
                                i % 2 == 0 ? RestockOrder.RestockOrderStatus.Pending : RestockOrder.RestockOrderStatus.Completed, 
                                database.Product.Skip(i - 1).First(),                          
                                database.Supplier.Skip(i - 1).First(),                         
                                new Manager("Manager", "Test", "manager@test.com", "ManagerPass123!") 
                            );

                            database.RestockOrder.Add(restockOrder);
                        }

                        
                        for (int i = 11; i <= 15; i++)
                        {
                            RestockOrder restockOrder = new RestockOrder(
                                DateTime.Now.AddDays(-i),                                     
                                i % 2 == 0 ? RestockOrder.RestockOrderStatus.Completed : RestockOrder.RestockOrderStatus.Pending,
                                database.Product.Skip(i - 1).First(),                          
                                database.Supplier.Skip(i - 1).First(),                         
                                new Manager("Manager", "Test", "manager@test.com", "ManagerPass123!") 
                            );

                            database.RestockOrder.Add(restockOrder);
                        }

                       
                        for (int i = 16; i <= 20; i++)
                        {
                            RestockOrder restockOrder = new RestockOrder(
                                DateTime.Now.AddDays(-i),                                     
                                i % 2 == 0 ? RestockOrder.RestockOrderStatus.Pending : RestockOrder.RestockOrderStatus.Completed, 
                                database.Product.Skip(i - 1).First(),                         
                                database.Supplier.Skip(i - 1).First(),                        
                                new Manager("Manager", "Test", "manager@test.com", "ManagerPass123!") 
                            );

                            database.RestockOrder.Add(restockOrder);
                        }

                       
                        for (int i = 21; i <= 25; i++)
                        {
                            RestockOrder restockOrder = new RestockOrder(
                                DateTime.Now.AddDays(-i),                                      
                                i % 2 == 0 ? RestockOrder.RestockOrderStatus.Completed : RestockOrder.RestockOrderStatus.Pending, 
                                database.Product.Skip(i - 1).First(),                          
                                database.Supplier.Skip(i - 1).First(),                         
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
}

