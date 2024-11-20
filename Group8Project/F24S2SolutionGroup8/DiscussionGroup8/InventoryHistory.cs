using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class InventoryHistory
    {
        public int InventoryHistoryId { get; set; }

        public DateTime Date { get; set; }

        public int QuantityChange { get; set; }
        public string Reason { get; set; }
        public int ProductId {get; set;}
        public Product Product { get; set; }

        public InventoryHistory() { }
        public InventoryHistory(int inventoryHistoryId, DateTime date, int QuantityChange, string Reason)
        {
            InventoryHistoryId = inventoryHistoryId;
            Date = date;
            this.QuantityChange = QuantityChange;
            this.Reason = Reason;
            this.ProductId = ProductId;


            

            
        }
    }
}