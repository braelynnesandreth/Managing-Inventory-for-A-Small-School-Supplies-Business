using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGroup8
{
   
  
        public class Supplier
        {
            [Key]
            public int SupplierId { get; set; }
            public string Name { get; set; }
            public string ContactInfo { get; set; }

            public List<RestockOrder> RestockOrders { get; set; } = new List<RestockOrder>();
            public Supplier() { }
            public Supplier(string name, string contactInfo, List<RestockOrder> restockOrders)
            {
                Name = name;
                ContactInfo = contactInfo;
                RestockOrders = restockOrders;

            }

        }
    }


