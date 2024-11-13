using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Manager : AppUser
    {
        public SmallBusinessOwner SmallBusinessOwner { get; set; }
        public Manager(string firstame, string lastname, string email, string password)
            : base(firstame, lastname, email, password)
        {

        }
    }
}