using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SmallBusinessOwner : AppUser
    {
        public string ManagerId { get; set; } 
        public Manager Manager { get; set; }  

        public SmallBusinessOwner() { }

        public SmallBusinessOwner(string firstname, string lastname, string email, string password, string managerId)
            : base(firstname, lastname, email, password)
        {
            ManagerId = managerId;
        }
        // Added: ApproveRestock method signature and implementation
        public bool ApproveRestock(int restockOrderId)
        {
            // Locate the restock order
            var restockOrder = _context.RestockOrders.FirstOrDefault(r => r.OrderID == restockOrderId);
            if (restockOrder == null || restockOrder.Status == "Approved")
            {
                return false; // Cannot approve an invalid or already approved order
            }

            // Update status and save changes
            restockOrder.Status = "Approved";
            _context.SaveChanges();
            return true;
        }

        // Added: ViewSalesInsights method signature and implementation
        public List<Product> ViewSalesInsights(DateTime startDate, DateTime endDate)
        {
            // Retrieve sales data and calculate top-selling products
            var sales = _context.Sales
                .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                .GroupBy(s => s.ProductId)
                .Select(group => new
                {
                    ProductId = group.Key,
                    TotalSold = group.Sum(s => s.Quantity)
                })
                .OrderByDescending(p => p.TotalSold)
                .Take(3) // Get top 3 products
                .ToList();

            // Map sales data to product objects
            var topProducts = sales
                .Select(s => _context.Products.FirstOrDefault(p => p.ProductId == s.ProductId))
                .ToList();

            return topProducts;
        }

        // Added: NotifyLowInventory method signature
        public void NotifyLowInventory(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null && product.CurrentStock <= product.ReorderPoint)
            {
                // Send a notification to the owner (logic can be extended)
                Console.WriteLine($"Notification: Product '{product.Name}' is low in stock.");
            }
        }

        
        public void ManageBusiness() => throw new NotImplementedException();
    }
}