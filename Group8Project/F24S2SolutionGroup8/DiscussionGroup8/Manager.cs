using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Manager : AppUser
    {
        public List<Staff> StaffMembers { get; set; }
        public List<Product> Products { get; set; }
        public List<InventoryHistory> InventoryHistories { get; set; }

        public Manager()
        {
            StaffMembers = new List<Staff>();
            Products = new List<Product>();
            InventoryHistories = new List<InventoryHistory>();
        }

        public Manager(string firstname, string lastname, string email, string password)
      : base(firstname, lastname, email, password)
        {
            StaffMembers = new List<Staff>();
            Products = new List<Product>();
            InventoryHistories = new List<InventoryHistory>();
        }

        public IEnumerable<InventoryHistory> ReviewInventoryHistory(int productId) =>
        InventoryHistories.Where(h => h.Product.ProductId == productId).ToList();

        public IEnumerable<RestockOrder> AnalyzeRestockingTrends(int productId, DateTime startDate, DateTime endDate)
        {
            return Products
            .FirstOrDefault(p => p.ProductId == productId)?.RestockOrder
            .Where(r => r.Date >= startDate && r.Date <= endDate)
            .ToList();

        }
    }
}












