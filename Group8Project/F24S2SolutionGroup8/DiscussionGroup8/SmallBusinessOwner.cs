using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SmallBusinessOwner : AppUser
    {
        public string ManagerId { get; set; } 
        public Manager Manager { get; set; }  

        public SmallBusinessOwner() { }

        public SmallBusinessOwner(string firstname, string lastname, string email, string password, string managerId)
            : base(firstname, lastname, email, password)
        {
            ManagerId = managerId;
        }

        public void ManageBusiness() => throw new NotImplementedException();
    }
}