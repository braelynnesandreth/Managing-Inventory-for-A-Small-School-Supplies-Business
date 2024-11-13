using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SmallBusinessOwner : AppUser

    {
        public Manager Manager {  get; set; }
        public SmallBusinessOwner(string firstame, string lastname, string email, string password)
            : base(firstame, lastname, email, password)
            { 
           
        }
    }
}