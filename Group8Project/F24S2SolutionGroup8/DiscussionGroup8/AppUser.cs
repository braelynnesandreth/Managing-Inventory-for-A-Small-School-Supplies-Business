using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace LibraryGroup8
{
    public class AppUser : IdentityUser

    {
       public string Firstname { get; set; }
        public string Lastname { get; set; }
        public AppUser() { }

        public AppUser(string firstname, string lastname,string email, string password)
        {

            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            UserName = email;

            var passwordHasher = new PasswordHasher<AppUser>();
            PasswordHash = passwordHasher.HashPassword(this, password);
        }

       
    }
}