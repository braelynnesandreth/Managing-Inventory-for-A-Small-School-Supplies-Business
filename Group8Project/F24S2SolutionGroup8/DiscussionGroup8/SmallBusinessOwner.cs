using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SmallBusinessOwner : AppUser
    {
        public string ManagerId { get; set; }
        public Manager Manager { get; set; }

        public void ApproveRestock(RestockOrder order) { }
        public void ViewSalesInsights(List<Sale> sales) { }

    }
}

