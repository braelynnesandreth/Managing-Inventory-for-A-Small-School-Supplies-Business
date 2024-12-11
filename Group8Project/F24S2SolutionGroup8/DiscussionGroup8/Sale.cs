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

        public static List<Sale> SearchSales
            (List<Sale> inputSales,
            DateTime? inputDateSaleMade,
            TimeSpan? inputTimeSaleMade)
        {
            List<Sale> searchResult = inputSales;

            //Filter based on input criteria
            if (inputDateSaleMade != null)
            {
                searchResult = searchResult.Where(s => s.SaleDate == inputDateSaleMade).ToList();
            }

            if (inputTimeSaleMade != null)
            {
                searchResult = searchResult.Where(s => s.SaleTime == inputTimeSaleMade).ToList();
            }

            return searchResult;
        }

        // Method to calculate the total amount for the sale
        public decimal CalculateTotal()
        {
            return SaleDetails.Sum(sd => sd.Quantity * sd.UnitPrice);
        }

    }
}


