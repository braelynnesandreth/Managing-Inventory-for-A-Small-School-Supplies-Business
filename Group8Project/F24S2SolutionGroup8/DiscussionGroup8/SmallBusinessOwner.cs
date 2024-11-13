using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SmallBusinessOwner : AppUser
    {
        public string ManagerID { get; set; } 
        public Manager Manager { get; set; }  

        public SmallBusinessOwner() { }

        public SmallBusinessOwner(string firstname, string lastname, string email, string password)
           : base(firstname, lastname, email, password)
        {
           
        }
    }
}

