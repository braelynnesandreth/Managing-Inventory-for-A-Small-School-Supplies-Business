using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

//Errors with the AspNetCore, causing problems on whole page

namespace LibraryGroup8
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AppUser() { }

        public AppUser(string FirstName, string LastName, string email, string Password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = email;
            this.Id = Email;

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            this.PasswordHash = passwordHasher.HashPassword(this, Password);
        }
    }
}
