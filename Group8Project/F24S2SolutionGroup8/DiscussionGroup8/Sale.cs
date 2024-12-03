﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LibraryGroup8
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public TimeSpan SaleTime { get; set; }
        
        
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public ICollection<SaleDetail> SaleDetails { get; set; }

        public decimal calculateTotal()
        {
            throw new System.NotImplementedException();
        }

        public Sale() 
        { 
            SaleDetails = new List<SaleDetail>();
        }
        public Sale( DateTime saleDate, TimeSpan saleTime)
        {
            
            SaleDate = saleDate;
            SaleTime = saleTime;
            SaleDetails = new List<SaleDetail>();
        }

        
    }
}