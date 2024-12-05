using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SmallBusinessOwner : AppUser
    {
        public string firstname  { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Manager Manager { get; set; }  

        public SmallBusinessOwner() { }

        public SmallBusinessOwner(string firstname, string lastname, string email, string password)
            : base(firstname, lastname, email, password)
        {
        }

        public void ManageBusiness() => throw new NotImplementedException();
    }
}