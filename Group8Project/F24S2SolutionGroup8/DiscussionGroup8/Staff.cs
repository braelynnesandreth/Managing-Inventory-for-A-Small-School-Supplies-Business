using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGroup8
{
    public class Staff : AppUser
    {
        public ICollection<Sale> Sales { get; set; }
        public Manager Manager { get; set; }

        
        public Staff() : base() 
        {
            Sales = new List<Sale>(); 
        }

       
        public Staff(string firstName, string lastName, string email, string userName, string password)
            : base(firstName, lastName, email, password)
        {
            Sales = new List<Sale>(); 
            this.UserName = userName; 
        }

        
        public bool ProcessSale(Sale sale)
        {
            if (sale != null)
            {
                Sales.Add(sale); 
                return true;
            }
            return false;
        }
        public void UpdateInventoryAfterRestock(int productId, int quantityReceived, List<Product> products)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                product.CurrentStock += quantityReceived;
            }
        }
    }
}