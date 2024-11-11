using DiscussionLibraryGroup8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Sale : Staff
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public int StaffID { get; set; }
        public Staff Staff { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
        public Sale() { }
        public Sale(DateTime saleDate, int staffID)
        {
            SaleDate = saleDate;
            StaffID = staffID;
        }
        public Sale(string firstName, string lastName, string email, string password)
            : base(firstName, lastName, email, password) { }
    }
}
