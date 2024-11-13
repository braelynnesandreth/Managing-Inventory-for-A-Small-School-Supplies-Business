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

            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.UserName = email;
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            this.PasswordHash = passwordHasher.HashPassword(this, password);


        }
    }

}