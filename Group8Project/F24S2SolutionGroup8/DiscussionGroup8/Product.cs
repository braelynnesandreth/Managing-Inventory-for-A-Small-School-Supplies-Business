using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentStock { get; set; }
        public int ReorderPoint { get; set; }
        public int MaxStock { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }


        public List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
        public List<RestockOrder> RestockOrders { get; set; } = new List<RestockOrder>();
        public List<InventoryHistory> InventoryHistories { get; set; } = new List<InventoryHistory>();

        public Product() { }
        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public void UpdateStock(int quantityChange)
        {
            
            CurrentStock += quantityChange;
        }

        public bool CheckLowStock()
        {
            if (ReorderPoint < 0)
            {
                throw new InvalidOperationException("Reorder point cannot be negative.");
            }
            return CurrentStock <= ReorderPoint;
        }
    }
}





