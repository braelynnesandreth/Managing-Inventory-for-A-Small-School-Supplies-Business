using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LibraryGroup8
{
    public class Sale
    {
     
        public DateTime SaleDate { get; set; }
        public TimeSpan SaleTime { get; set; }
        public string Staff { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; }

        public decimal calculateTotal()
        {
            throw new System.NotImplementedException();
        }

        public Sale() 
        { 
            SaleDetails = new List<SaleDetail>();
        }
        public Sale( DateTime saleDate, TimeSpan saleTime, string staff)
        {
            
            SaleDate = saleDate;
            SaleTime = saleTime;
            SaleDetails = new List<SaleDetail>();
            Staff = staff;
        }

        
    }
}