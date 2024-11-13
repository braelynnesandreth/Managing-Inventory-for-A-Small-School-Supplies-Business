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
        }
    }
}
    

