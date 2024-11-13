using LibraryGroup8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Supplier : Product
    {
         public int SupplierID { get; set; }
        public string ContactInfo { get; set; } 
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<RestockOrder> RestockOrders { get; set; } = new List<RestockOrder>(); 
        public Supplier() { }
        public Supplier(string firstName, string lastName, string email, string password)
            : base(firstName, lastName, email, password) { } public Supplier(string firstName, string lastName, string email, string password, string contactInfo) 
            
            : base(firstName, lastName, email, password) { ContactInfo = contactInfo; 
        }
    }
    }