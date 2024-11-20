using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }
       public int SaleId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public Sale Sale { get; set; }
        
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal calculateSubtotal()
        {
            throw new System.NotImplementedException();
        }

        public SaleDetail() { }

        public SaleDetail(Product product, Sale sale, int Quantity, decimal UnitPrice)
        {
            Product = product;
            Sale = sale;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;





        }
    }
}
