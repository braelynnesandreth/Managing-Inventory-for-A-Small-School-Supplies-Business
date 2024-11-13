using Microsoft.AspNetCore.Identity;

namespace MvcGroup8.Data
{
    public class InitialDatabase
    {
        public static void SeedDatabase(IServiceProvider services)
        {
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();
            UserManager<AppUser> userManager = services.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole<int>> roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

            string adminRole = "Admin";
            string smallBusinessOwnerRole = "Small Business Owner";
            string saleRole = "Sale";
            string managerRole = "Manager";
            string staffRole = "Staff";
            string productRole = "Product";
            string supplierRole = "Supplier";

            // Insert roles into the database if they don't exist
            if (!database.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole<int>(adminRole)).Wait();
                roleManager.CreateAsync(new IdentityRole<int>(smallBusinessOwnerRole)).Wait();
                roleManager.CreateAsync(new IdentityRole<int>(saleRole)).Wait();
                roleManager.CreateAsync(new IdentityRole<int>(managerRole)).Wait();
                roleManager.CreateAsync(new IdentityRole<int>(staffRole)).Wait();
                roleManager.CreateAsync(new IdentityRole<int>(productRole)).Wait();
                roleManager.CreateAsync(new IdentityRole<int>(supplierRole)).Wait();
            }

            // Insert initial users if they don't exist
            if (!database.Users.Any())
            {
                CreateUserAndAssignRole(userManager, adminRole, new AppUser.AppUser("Samantha", "Olivio", "samanthaolivio@gmail.com", "SecurePassword123!"));
                CreateUserAndAssignRole(userManager, smallBusinessOwnerRole, new SmallBusinessOwner("Brooke", "Mesinere", "brookemesinere@gmail.com", "SecurePassword123!"));
                CreateUserAndAssignRole(userManager, managerRole, new Manager("Jordan", "Whitaker", "jordanwhitaker@gmail.com", "SecurePassword123!"));
                CreateUserAndAssignRole(userManager, staffRole, new Staff("Marcus", "Santiago", "marcussantiago@gmail.com", "SecurePassword123!"));
                CreateUserAndAssignRole(userManager, staffRole, new Staff("Sophie", "Henson", "sophiehenson@gmail.com", "SecurePassword123!"));
                CreateUserAndAssignRole(userManager, saleRole, new Sale("Liam", "Chen", "liamchen@gmail.com", "SecurePassword123!"));
                CreateUserAndAssignRole(userManager, saleRole, new Sale("Emma", "Caldwell", "emmacaldwell@gmail.com", "SecurePassword123!"));
                CreateUserAndAssignRole(userManager, productRole, new Product("Ethan", "Hughes", "ethanhughes@gmail.com", "SecurePassword123!"));
                CreateUserAndAssignRole(userManager, productRole, new Product("Mia", "Perez", "miaperez@gmail.com", "SecurePassword123!"));
                CreateUserAndAssignRole(userManager, supplierRole, new Supplier("Lily", "Brooks", "lilybrooks@gmail.com", "SecurePassword123!"));
                CreateUserAndAssignRole(userManager, supplierRole, new Supplier("William", "Scott", "williamscott@gmail.com", "SecurePassword123!"));
            }

            // Add any additional seeding logic here if needed
        }

        private static void CreateUserAndAssignRole(UserManager<AppUser> userManager, string role, AppUser user)
        {
            var result = userManager.CreateAsync(user).Result;
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, role).Wait();
            }
            else
            {
                throw new Exception($"Failed to create user {user.UserName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}






























