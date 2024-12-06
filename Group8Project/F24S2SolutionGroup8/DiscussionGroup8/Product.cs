﻿using System;
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
        public string Supplier { get; set; }
        public ICollection<InventoryHistory> InventoryHistory { get; set; }

        public ICollection<SaleDetail> SaleDetail { get; set; }
        public ICollection<RestockOrder> RestockOrder {get; set;}

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
        
        public Product(string name, string description, int currentStock, int reorderPoint, int maxStock, string supplier)
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
        }

        // Restock inventory
        public void Restock(int quantity)
        {
            if (CurrentStock + quantity > MaxStock)
            {
                throw new InvalidOperationException("Cannot exceed maximum stock limit.");
            }

            CurrentStock += quantity;
        }
    }
}