using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Manager : AppUser
    {
        public ICollection<Staff> StaffMembers { get; set; } 

        public Manager()
        {
            StaffMembers = new List<Staff>();
        }

        public Manager(string firstname, string lastname, string email, string password)
           : base(firstname, lastname, email, password)
        {
            StaffMembers = new List<Staff>();
        }
        public InventoryHistory ReviewInventoryHistory() => throw new System.NotImplementedException();
        public RestockOrder AnalyzeRestockingTrends() => throw new System.NotImplementedException();
    }
}