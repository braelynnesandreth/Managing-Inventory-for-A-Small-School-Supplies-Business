using LibraryGroup8;
using System;
using Xunit;

namespace TestGroup8
{
    public class ProductTest
    {
        [Fact]
        public void ShouldReduceStockWhenSaleIsMade()
        {
            // Arrange
            var product = CreateTestProduct();
            int initialStock = product.CurrentStock;
            int saleQuantity = 5;
            int expectedStock = initialStock - saleQuantity;

            // Act
            product.AddSale(saleQuantity);

            // Assert
            Assert.Equal(expectedStock, product.CurrentStock);
            Assert.Contains(product.InventoryHistory,
                h => h.QuantityChange == -saleQuantity && h.Reason == "Sale" && h.Product == product);
        }

        [Fact]
        public void ShouldThrowExceptionWhenSaleExceedsStock()
        {
            // Arrange
            var product = CreateTestProduct();
            int saleQuantity = product.CurrentStock + 1; // Exceed stock

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.AddSale(saleQuantity));
        }

        [Fact]
        public void ShouldIncreaseStockWhenRestocked()
        {
            // Arrange
            var product = CreateTestProduct();
            int initialStock = product.CurrentStock;
            int restockQuantity = 10;
            int expectedStock = initialStock + restockQuantity;

            // Act
            product.Restock(restockQuantity);

            // Assert
            Assert.Equal(expectedStock, product.CurrentStock);
            Assert.Contains(product.InventoryHistory,
                h => h.QuantityChange == restockQuantity && h.Reason == "Restock" && h.Product == product);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRestockExceedsMaxStock()
        {
            // Arrange
            var product = CreateTestProduct();
            int restockQuantity = product.MaxStock - product.CurrentStock + 1; // Exceed max stock

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.Restock(restockQuantity));
        }

        [Fact]
        public void ShouldInitializeProductWithDefaultValues()
        {
            // Arrange
            var product = new Product();

            // Act & Assert
            Assert.NotNull(product.SaleDetail);
            Assert.NotNull(product.RestockOrder);
            Assert.NotNull(product.InventoryHistory);
        }

        // Helper method to create a test product
        private Product CreateTestProduct()
        {
            var supplier = new Supplier
            {
                Name = "Test Supplier",
                ContactInfo = "contact@testsupplier.com"
            };

            return new Product("Test Product", "Test Description", 50, 10, 100, supplier);
        }
    }
}


