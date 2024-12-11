using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Sale
    {
        public int SaleID { get; set; }
        public DateTime SaleDate { get; set; }
        public TimeSpan SaleTime { get; set; }


        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; }
       

        public Sale()
        {
            SaleDetails = new List<SaleDetail>();
        }

        public Sale(DateTime saleDate, TimeSpan saleTime, int staffId)
        {
            SaleDate = saleDate;
            SaleTime = saleTime;
            StaffId = staffId;
            SaleDetails = new List<SaleDetail>();
        }

        // Method to calculate the total amount for the sale
        public decimal CalculateTotal()
        {
            return SaleDetails.Sum(sd => sd.Quantity * sd.UnitPrice);
        }

    }
}


