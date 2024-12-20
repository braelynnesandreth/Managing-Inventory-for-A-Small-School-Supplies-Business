using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class InventoryHistory
    {
        [Key]
        public int InventoryHistoryId { get; set; }
        public DateTime Date { get; set; }
        public int QuantityChange { get; set; }
        public string Reason { get; set; }
        public Product Product { get; set; }

        public InventoryHistory() { }

        public InventoryHistory(DateTime date, int quantityChange, string reason, Product productF)
        {
            Date = date;
            QuantityChange = quantityChange;
            Reason = reason;
            Product = productF;
        }
    }

}

