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

        // Constructor
        public SaleDetail() { }

        public SaleDetail(int saleId, int productId, int quantity, decimal unitPrice)
        {
            SaleId = saleId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        // Method to calculate the subtotal for this SaleDetail
        public decimal CalculateSubtotal()
        {
            return Quantity * UnitPrice;
        }

        
        public override string ToString()
        {
            return $"SaleDetailId: {SaleDetailId}, SaleId: {SaleId}, ProductId: {ProductId}, Quantity: {Quantity}, UnitPrice: {UnitPrice:C}, Subtotal: {CalculateSubtotal():C}";
        }
    }
}

