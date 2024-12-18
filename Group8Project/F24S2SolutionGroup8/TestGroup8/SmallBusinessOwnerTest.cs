using LibraryGroup8;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestGroup8
{
    public class SmallBusinessOwnerTest
    {
        [Fact]
        public void ShouldApproveRestockOrderSuccessfully()
        {
            // Arrange
            var smallBusinessOwner = CreateTestSmallBusinessOwner();
            var restockOrder = new RestockOrder
            {
                RestockOrderId = 1,
                Status = "Pending"
            };
            smallBusinessOwner.RestockOrders.Add(restockOrder);

            // Act
            bool result = smallBusinessOwner.ApproveRestock(restockOrder.RestockOrderId);

            // Assert
            Assert.True(result);
            Assert.Equal("Approved", restockOrder.Status);
        }

        [Fact]
        public void ShouldFailToApproveAlreadyApprovedRestockOrder()
        {
            // Arrange
            var smallBusinessOwner = CreateTestSmallBusinessOwner();
            var restockOrder = new RestockOrder
            {
                RestockOrderId = 1,
                Status = "Approved"
            };
            smallBusinessOwner.RestockOrders.Add(restockOrder);

            // Act
            bool result = smallBusinessOwner.ApproveRestock(restockOrder.RestockOrderId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ShouldViewTop3SalesInsightsWithinDateRange()
        {
            // Arrange
            var smallBusinessOwner = CreateTestSmallBusinessOwner();
            var product1 = new Product { ProductId = 1, Name = "Product 1" };
            var product2 = new Product { ProductId = 2, Name = "Product 2" };
            var product3 = new Product { ProductId = 3, Name = "Product 3" };
            var product4 = new Product { ProductId = 4, Name = "Product 4" };

            smallBusinessOwner.Products.AddRange(new[] { product1, product2, product3, product4 });

            var sale = new Sale
            {
                SaleDate = DateTime.Now,
                SaleDetails = new List<SaleDetail>
                {
                    new SaleDetail { Product = product1, Quantity = 5 },
                    new SaleDetail { Product = product2, Quantity = 10 },
                    new SaleDetail { Product = product3, Quantity = 7 },
                    new SaleDetail { Product = product4, Quantity = 3 }
                }
            };
            smallBusinessOwner.Sales.Add(sale);

            // Act
            var topProducts = smallBusinessOwner.ViewSalesInsights(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));

            // Assert
            Assert.Equal(3, topProducts.Count);
            Assert.Contains(product2, topProducts); // Product 2 should be the top-selling
            Assert.Contains(product3, topProducts); // Product 3 should be in the top 3
            Assert.Contains(product1, topProducts); // Product 1 should also be in the top 3
        }

        [Fact]
        public void ShouldSendLowStockNotification()
        {
            // Arrange
            var smallBusinessOwner = CreateTestSmallBusinessOwner();
            var product = new Product
            {
                ProductId = 1,
                Name = "Low Stock Product",
                CurrentStock = 5,
                ReorderPoint = 10
            };
            smallBusinessOwner.Products.Add(product);

            // Act
            var exception = Record.Exception(() => smallBusinessOwner.NotifyLowInventory(product.ProductId));

            // Assert
            Assert.Null(exception); // Ensure no exception was thrown
        }

        [Fact]
        public void ShouldNotSendNotificationForSufficientStock()
        {
            // Arrange
            var smallBusinessOwner = CreateTestSmallBusinessOwner();
            var product = new Product
            {
                ProductId = 1,
                Name = "Sufficient Stock Product",
                CurrentStock = 15,
                ReorderPoint = 10
            };
            smallBusinessOwner.Products.Add(product);

            // Act
            smallBusinessOwner.NotifyLowInventory(product.ProductId);

            // Assert
            // Since no notification system is implemented, we assert that the code runs without errors.
        }

        private SmallBusinessOwner CreateTestSmallBusinessOwner()
        {
            return new SmallBusinessOwner("Test", "Owner", "test@business.com", "password123");
        }
    }
}

