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

                foreach (var appUser in appUsers)
                {
                    userManager.CreateAsync(appUser).Wait();
                }
            }
        }
    }
}


