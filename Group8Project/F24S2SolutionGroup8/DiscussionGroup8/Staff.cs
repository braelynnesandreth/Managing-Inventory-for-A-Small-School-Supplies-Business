using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Staff : AppUser
    {
        public string firstname {  get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }

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

        public Staff(string firstname, string lastname, string email, string username, string password) :
            base(firstname, lastname, email, password)
        {
            Sales = new List<Sale>();
        }
    }
}