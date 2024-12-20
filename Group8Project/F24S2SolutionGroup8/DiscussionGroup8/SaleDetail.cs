using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SaleDetail
    {
        [Key]
        public int SaleDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Product Product { get; set; }

        public SaleDetail() { }

        public SaleDetail(int Quantity, decimal UnitPrice, Product Product)

        {
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.Product = Product;
        }
    }
}

