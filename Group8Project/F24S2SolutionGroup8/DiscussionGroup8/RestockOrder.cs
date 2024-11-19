using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGroup8
{
    public class RestockOrder
    {
        public int OrderID { get; set; }
        [Required]
        public Supplier Supplier { get; set; }
        [Required]
        public Product Product { get; set; }

        public DateTime Date { get; set; }
        public string Status { get; set; }
        public RestockOrder() 
        { 
        }
        public RestockOrder(Supplier supplier, Product product, DateTime Date, string Status)
        {
            Supplier = supplier;
            Product = product;
            this.Date = Date;
            this.Status = Status;
        }
    }
}
