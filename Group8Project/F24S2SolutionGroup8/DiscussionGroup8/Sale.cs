using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using LibraryGroup8.LibraryGroup8;

namespace LibraryGroup8
{
    
        public class Sale
        {
            [Key]

            public int SaleId { get; set; }
            public DateTime Date { get; set; }
            public Staff Staff { get; set; }
            public DateTime SaleDateTime { get; set; }

            public List<SaleDetail> SaleDetail { get; set; } = new List<SaleDetail>();

            public Sale() { }
            public Sale(DateTime date, Staff staff, DateTime saleDateTime, List<SaleDetail> saleDetail)
            {

                Date = date;
                Staff = staff;
                SaleDateTime = saleDateTime;
                SaleDetail = saleDetail;
            }
        }
    }


