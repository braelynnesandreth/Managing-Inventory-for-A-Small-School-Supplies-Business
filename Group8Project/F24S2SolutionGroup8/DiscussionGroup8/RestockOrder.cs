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

        public void approve()
        {
            throw new System.NotImplementedException();
        }

        public void cancel()
        {
            throw new System.NotImplementedException();
        }

        public RestockOrder() { }
        public RestockOrder(Product product)
        {
            Product = product;
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
