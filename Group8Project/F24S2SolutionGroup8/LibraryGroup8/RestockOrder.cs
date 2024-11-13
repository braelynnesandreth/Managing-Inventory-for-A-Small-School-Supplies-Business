using LibraryGroup8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class RestockOrder
    {
        public int RestockOrderID { get; set; }
        public int SupplierID { get; set; }
        public Supplier supplier { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        

        public RestockOrder() { }

        public RestockOrder(int productId, int supplierId, DateTime orderDate, string status)
        {
            ProductID = productId;
            SupplierID = supplierId;
            OrderDate = orderDate;
            Status = status;
        }
    }
}