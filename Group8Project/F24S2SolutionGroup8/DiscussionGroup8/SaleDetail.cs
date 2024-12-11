using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }
        public Product Product { get; set; }
        public Sale Sale { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Constructor
        public SaleDetail() { }

        public SaleDetail(Sale sale, Product product, int quantity, decimal unitPrice)
        {
            Sale = sale;
            Product = product;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        // Method to calculate the subtotal for this SaleDetail
        public decimal CalculateSubtotal()
        {
            return Quantity * UnitPrice;
        }

        
      
    }
}

