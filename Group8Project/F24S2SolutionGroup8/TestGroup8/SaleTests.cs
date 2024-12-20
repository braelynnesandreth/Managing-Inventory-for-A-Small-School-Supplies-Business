using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGroup8;

namespace TestGroup8
{
    public class SaleTests
    {
        [Fact]
    public void CalculateTotal_ShouldReturnSumOfSubtotals()
    {
        // Arrange
        var product1 = new Product { Name = "Notebook" };
        var product2 = new Product { Name = "Pen" };
        var sale = new Sale();
        sale.SaleDetail.Add(new SaleDetail { Product = product1, Quantity = 2, UnitPrice = 5 });
        sale.SaleDetail.Add(new SaleDetail { Product = product2, Quantity = 3, UnitPrice = 2 });

        // Act
        var total = sale.CalculateTotal();

        // Assert
        Assert.Equal(16, total);
    }

    [Fact]
    public void SearchSalesByProductName_ShouldReturnMatchingSales()
    {
        // Arrange
        var product1 = new Product { Name = "Notebook" };
        var product2 = new Product { Name = "Pen" };
        var sale = new Sale();
        sale.SaleDetail.Add(new SaleDetail { Product = product1, Quantity = 2, UnitPrice = 5 });
        sale.SaleDetail.Add(new SaleDetail { Product = product2, Quantity = 3, UnitPrice = 2 });

        // Act
        var result = sale.SearchSalesByProductName("Note");

        // Assert
        Assert.Single(result);
        Assert.Equal(product1, result.First().Product);
    }
}
}
    