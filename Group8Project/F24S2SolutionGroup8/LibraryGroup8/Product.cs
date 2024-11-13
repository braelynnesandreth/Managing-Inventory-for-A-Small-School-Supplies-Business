using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryGroup8;


namespace LibraryGroup8
{
        public class Product : Sale
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal UnitPrice { get; set; }
            public int CurrentStock { get; set; }
            public int ReorderPoint { get; set; }
            public int MaxStock { get; set; }

            public int SupplierID { get; set; }
            public Supplier Supplier { get; set; }

            public ICollection<InventoryHistory> InventoryHistoryProduct { get; set; } = new List<InventoryHistory>();
            public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
            public ICollection<RestockOrder> RestockOrdersProduct { get; set; } = new List<RestockOrder>();

            public Product() { }

            public Product(string name, string description, decimal unitPrice, int currentStock, int reorderPoint, int maxStock, int supplierID)
            {
                Name = name;
                Description = description;
                UnitPrice = unitPrice;
                CurrentStock = currentStock;
                ReorderPoint = reorderPoint;
                MaxStock = maxStock;
                SupplierID = supplierID;
            }

            public Product(string firstName, string lastName, string email, string password)
                : base(firstName, lastName, email, password) { }
        }
    }
