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

        public string Name { get; set; }

        public string ContactInfo { get; set; }

        public List<Product> Product {  get; set; }

        
        public List<RestockOrder> RestocksTheOrder { get; set; }




        public Supplier()
        {
            RestocksTheOrder = new List<RestockOrder>();
           
        }

        public Supplier(string product, string name, string contactInfo)
        {
            Product = new List<Product>();
            Name = name;
            ContactInfo = contactInfo;
            RestocksTheOrder = new List<RestockOrder>();
            
        }
    }
}