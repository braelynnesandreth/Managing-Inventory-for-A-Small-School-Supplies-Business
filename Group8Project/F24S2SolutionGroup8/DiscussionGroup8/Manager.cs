using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryGroup8;

namespace LibraryGroup8
{
    public class Manager : AppUser
    {
        public List<RestockOrder> RestockOrder { get; set; } = new List<RestockOrder>();
        public Manager() { } //empty
        public Manager(string firstName, string lastName, string email, string password)
            : base(firstName, lastName, email, password)
        {


        }
    }
}

