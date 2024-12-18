using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
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

