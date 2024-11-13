using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public string Name { get; set; }

        public string ContactInfo { get; set; }

        public ICollection<Product> Product {  get; set; }
        public ICollection<RestockOrder> RestockOrder { get; set; }
        public Supplier() 
        {
            Product = new List<Product>();
            RestockOrder = new List<RestockOrder>();
        }

        public Supplier (int supplierId, string name, string contactInfo)
        {
            SupplierId = supplierId;
            Name = name;
            ContactInfo = contactInfo;
            Product = new List<Product>();
            RestockOrder = new List<RestockOrder>();
        }
    }
}