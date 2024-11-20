using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGroup8
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public string Name { get; set; }

        public string ContactInfo { get; set; }

        public Product Product {  get; set; }

        public List<RestockOrder> RestocksTheOrder { get; set; }

        [NotMapped]
        public List<Product> Products { get; set; } 
        = new List<Product>();

        public Supplier ()
        {
            RestocksTheOrder = new List<RestockOrder> ();
        }

        public Supplier (Product product, string name, string contactInfo)
        {
            Product = product;
            Name = name;
            ContactInfo = contactInfo;
        }
    }
}