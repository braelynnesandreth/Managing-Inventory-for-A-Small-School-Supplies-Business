using LibraryGroup8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Manager : AppUser
    {
        public Manager(string FirstName, string LastName, string Email, string Password) 
            : base (FirstName, LastName, Email, Password)
        { 
        }
    }
}
