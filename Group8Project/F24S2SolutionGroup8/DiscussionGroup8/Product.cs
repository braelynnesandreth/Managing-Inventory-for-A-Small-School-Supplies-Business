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
        public Supplier Supplier { get; set; }
        

        public List<InventoryHistory> InventoryHistory { get; set; }

        public List<SaleDetail> SaleDetail { get; set; }
        public List<RestockOrder> RestockOrder {get; set;}

        public void Updatestock()
        {
            throw new System.NotImplementedException();
        }

        public bool Checklowstock()
        {
            throw new System.NotImplementedException();
        }

        public Product() 
        {
            SaleDetail = new List<SaleDetail>();
            RestockOrder = new List<RestockOrder>();
            InventoryHistory = new List<InventoryHistory>();
            
        }
        
        public Product(string name, string description, int currentStock, int reorderPoint, int maxStock, Supplier supplier)
        {
            Name = name;
            Description = description;
            CurrentStock = currentStock;
            ReorderPoint = reorderPoint;
            MaxStock = maxStock;
            Supplier = supplier;
            SaleDetail = new List<SaleDetail>();
            RestockOrder= new List<RestockOrder>();
            InventoryHistory = new List<InventoryHistory>();
        }
        // Add a sale and adjust stock
        public void AddSale(int quantity)
        {
            if (quantity > CurrentStock)
            {
                throw new InvalidOperationException("Insufficient stock to complete the sale.");
            }

            CurrentStock -= quantity;
            InventoryHistory.Add(new InventoryHistory(DateTime.Now, -quantity, "Sale", this)); 
        
        }

        // Restock inventory
        public void Restock(int quantity)
        {
            if (CurrentStock + quantity > MaxStock)
            {
                throw new InvalidOperationException("Cannot exceed maximum stock limit.");
            }

            CurrentStock += quantity;
            InventoryHistory.Add(new InventoryHistory(DateTime.Now, quantity, "Restock", this)); // Record restock history
        }
    

    }
}