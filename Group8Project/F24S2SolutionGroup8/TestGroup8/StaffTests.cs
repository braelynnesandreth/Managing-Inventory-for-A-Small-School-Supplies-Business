using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGroup8.LibraryGroup8;
using LibraryGroup8;

namespace TestGroup8
{
    public class StaffTests
    {
        [Fact]
        public void ProcessSale_ShouldAddSaleToStaff()
        {
            // Arrange
            var staff = new Staff();
            var sale = new Sale();

            // Act
            staff.ProcessSale(sale);

            // Assert
            Assert.Contains(sale, staff.Sales);
        }

        [Fact]
        public void UpdateInventory_ShouldChangeProductStock()
        {
            // Arrange
            var staff = new Staff();
            var product = new Product { CurrentStock = 50 };

            // Act
            staff.UpdateInventory(product, -10);

            // Assert
            Assert.Equal(40, product.CurrentStock);
        }
    }
}

