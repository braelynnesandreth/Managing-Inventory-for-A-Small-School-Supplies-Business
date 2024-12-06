using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SmallBusinessOwner : AppUser
    {
        public List<RestockOrder> RestockOrders { get; set; }
        public List<Sale> Sales { get; set; }
        public List<Product> Products { get; set; }

        public SmallBusinessOwner()
        {
            RestockOrders = new List<RestockOrder>();
            Sales = new List<Sale>();
            Products = new List<Product>();
        }
        public SmallBusinessOwner(string firstname, string lastname, string email, string password)
           : base(firstname, lastname, email, password)
        {
            RestockOrders = new List<RestockOrder>();
            Sales = new List<Sale>();
            Products = new List<Product>();
        }
        // Approve Restock Order
        public bool ApproveRestock(int restockOrderId)
        {
            
            var restockOrder = RestockOrders.FirstOrDefault(r => r.RestockOrderId == restockOrderId);

           
            if (restockOrder == null || restockOrder.Status == "Approved")
            {
                return false; // Can't approve an invalid or already approved order
            }

            // Update the status to "Approved"
            restockOrder.Status = "Approved";
            return true; 
        }

        
        public List<Product> ViewSalesInsights(DateTime startDate, DateTime endDate)
        {
           
            var topProducts = Sales
                .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate) 
                .SelectMany(s => s.SaleDetails) 
                .GroupBy(sd => sd.ProductId) 
                .Select(group => new
                {
                    ProductId = group.Key,
                    TotalSold = group.Sum(sd => sd.Quantity) 
                })
                .OrderByDescending(p => p.TotalSold) 
                .Take(3) // Get the top 3 products
                .Join(Products, sales => sales.ProductId, product => product.ProductId, (sales, product) => product) // Join to get the actual product data
                .ToList();

            return topProducts;
        }

        // Notify when product inventory is low
        public void NotifyLowInventory(int productId)
        {
            // Find the product by its ID
            var product = Products.FirstOrDefault(p => p.ProductId == productId);

            // Check if the product exists and its current stock is less than or equal to the reorder point
            if (product != null && product.CurrentStock <= product.ReorderPoint)
            {
                
                Console.WriteLine($"Notification: Product '{product.Name}' is low in stock.");
            }
        }

        
        public void ManageBusiness()
        {
            
            throw new NotImplementedException();
        }
    }
}
