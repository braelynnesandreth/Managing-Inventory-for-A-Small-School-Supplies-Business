using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Staff : AppUser
    {
        public int ManagerId { get; set; }  
        public ICollection<Sale> Sales { get; set; }  
        public Manager Manager { get; set; }

        public bool processSale()
        {
            throw new System.NotImplementedException();
        }

        public InventoryHistory updateInventory()
        {
            throw new System.NotImplementedException();
        }

        public Staff()
        {
            Sales = new List<Sale>();  
        }

        public Staff(string firstname, string lastname, string email, string password, int managerId)
            : base(firstname, lastname, email, password)
        {
            ManagerId = ManagerId;
            Sales = new List<Sale>();  
        }

        public Staff(string firstname, string lastname, string email, string password) :
            base(firstname, lastname, email, password)
        {
            Sales = new List<Sale>();
        }
    }
}