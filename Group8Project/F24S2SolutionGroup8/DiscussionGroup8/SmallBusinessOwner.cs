using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class SmallBusinessOwner : AppUser
    {
        public List<RestockOrder> ApprovedOrders { get; set; } = new List<RestockOrder>();

        public SmallBusinessOwner() { }
        public SmallBusinessOwner(string firstName, string lastName, string email, string password)
            : base(firstName, lastName, email, password)
        {


        }

    }
}
