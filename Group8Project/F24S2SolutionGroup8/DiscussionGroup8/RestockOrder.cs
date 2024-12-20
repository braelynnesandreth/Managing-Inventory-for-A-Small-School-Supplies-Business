using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{

    public class RestockOrder
    {
        [Key]
        public int RestockOrderId { get; set; }
        public DateTime Date { get; set; }
        public RestockOrderStatus Status { get; set; }

        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
        public Manager Manager { get; set; }

        public RestockOrder() { }
        public RestockOrder(DateTime date, RestockOrderStatus status, Product product, Supplier supplier, Manager manager)
        {
            Date = date;
            Status = status;
            Product = product;
            Supplier = supplier;
            Manager = manager;
        }

        public void Approve()
        {
            if (Status == RestockOrderStatus.Pending)
            {
                Status = RestockOrderStatus.Approved;
            }
            else
            {
                throw new InvalidOperationException("Cannot approve an order that is already approved or cancelled.");
            }
        }

        public void Cancel()
        {
            if (Status == RestockOrderStatus.Pending)
            {
                Status = RestockOrderStatus.Cancelled;
            }
            else
            {
                throw new InvalidOperationException("Cannot cancel an order that is already cancelled or approved.");
            }
        }
        public enum RestockOrderStatus
        {
            Pending,
            Approved,
            Cancelled,
            Completed
        }

    }
}