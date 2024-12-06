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
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Constructor
        public InventoryHistory() { }

        public InventoryHistory(DateTime date,
                                int quantityChange,
                                string reason,
                                int productId)
        {
            Date = date;
            QuantityChange = quantityChange;
            Reason = reason;
            ProductId = productId;
        }

        // Override ToString for better display
        public override string ToString()
        {
            return $"InventoryHistoryId: {InventoryHistoryId}, Date: {Date.ToShortDateString()}, QuantityChange: {QuantityChange}, Reason: {Reason}, ProductId: {ProductId}";
        }
    }
}
