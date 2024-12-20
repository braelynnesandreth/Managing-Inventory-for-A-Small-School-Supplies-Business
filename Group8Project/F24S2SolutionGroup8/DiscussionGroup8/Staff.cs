using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    namespace LibraryGroup8
    {
        public class Staff : AppUser
        {
           
                public List<Sale> Sales { get; set; } = new List<Sale>();

                public Staff() { }
                public Staff(string firstName, string lastName, string email, string password)
                    : base(firstName, lastName, email, password)
                {
                }

                public void ProcessSale(Sale sale)
                {
                    Sales.Add(sale);
                }

                public void UpdateInventory(Product product, int quantityChange)
                {
                    product.UpdateStock(quantityChange);
                }
            }
        }
    }



