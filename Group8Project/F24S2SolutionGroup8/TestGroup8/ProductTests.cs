using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGroup8;

namespace TestGroup8
{
    public class ProductTests
    {

        [Fact]
        public void UpdateStock_ShouldIncreaseStock_WhenPositiveValueProvided()
        {
            // Arrange
            var product = new Product { CurrentStock = 10 };

            // Act
            product.UpdateStock(20);

            // Assert
            Assert.Equal(30, product.CurrentStock);
        }

        [Fact]
        public void CheckLowStock_ShouldReturnTrue_WhenStockIsBelowReorderPoint()
        {
            // Arrange
            var product = new Product { CurrentStock = 5, ReorderPoint = 10 };

            // Act
            bool isLowStock = product.CheckLowStock();

            // Assert
            Assert.True(isLowStock);
        }
    }
}
    