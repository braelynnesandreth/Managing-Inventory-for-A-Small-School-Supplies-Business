using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentStock { get; set; }
        public int ReorderPoint { get; set; }
        public int MaxStock { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public InventoryHistory InventoryHistory { get; set; }

        public ICollection<SaleDetail> SaleDetail { get; set; }
        public ICollection<RestockOrder> RestockOrder {get; set;}

       

        public Product() 
        {
            SaleDetail = new List<SaleDetail>();
            RestockOrder = new List<RestockOrder>();
            
        }
        
        public Product(int productId, string name, string description, int currentStock, int reorderPoint, int maxStock)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            CurrentStock = currentStock;
            ReorderPoint = reorderPoint;
            MaxStock = maxStock;
            SaleDetail = new List<SaleDetail>();
            RestockOrder= new List<RestockOrder>();
        }
    }
}