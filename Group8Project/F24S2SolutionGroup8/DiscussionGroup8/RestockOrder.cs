using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class RestockOrder
    {
        [Key]
        public int RestockOrderId { get; set; }
        public Supplier Supplier { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        // Constructor
        public RestockOrder() { }

        
        public RestockOrder(Supplier supplier, Product product, DateTime date, string status)
        {
            Supplier = supplier;
            Product = product;
            Date = date;
            Status = status;
        }

        
        public bool approve()
        {
            
            if (Status != "Pending")
            {
                return false;  
            }

            Status = "Approved";
            return true;  
        }

        public void cancel()
        {
            
            Status = "Cancelled";
        }
    }
}
