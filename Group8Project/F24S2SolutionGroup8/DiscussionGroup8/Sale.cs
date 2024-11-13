using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public TimeSpan SaleTime { get; set; }
        public Product Product { get; set; }
        
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; }
        public Sale() 
        { 
            SaleDetails = new List<SaleDetail>();
        }
        public Sale(int saleId, DateTime saleDate, TimeSpan saleTime)
        {
            SaleId = saleId;
            SaleDate = saleDate;
            SaleTime = saleTime;
            SaleDetails = new List<SaleDetail>();
        }

        
    }
}