using LibraryGroup8;

namespace TestGroup8
{
    public class SaleTest
    {
        [Fact]
        public void ShouldSearchSales()
        {
            //Arrange
            List<Sale> inputSales = CreateTestData();
            DateTime? inputDateSaleMade = null;
            TimeSpan? inputTimeSaleMade = null;
            List<Sale> outputSales = new List<Sale>();
            int expectedNumberOfSales = 3;

            //Act
            outputSales = Sale.SearchSales(inputSales, inputDateSaleMade, inputTimeSaleMade);

            //Assert
            Assert.Equal(expectedNumberOfSales, outputSales.Count);
        }

        public List<Sale> CreateTestData()
        {
            List<Sale> testSales = new List<Sale>();

            // October - 2, 11am  - 2

            Sale sale =
                new Sale
                {
                    SaleID = 1,
                    SaleDate = new DateTime(2024, 10, 29),
                    SaleTime = new TimeSpan(11, 30,10)
                };
                testSales.Add(sale);

            sale =
                new Sale
                {
                    SaleID = 2,
                    SaleDate = new DateTime(2024, 10, 30),
                    SaleTime = new TimeSpan(12, 45, 10)
                };
            testSales.Add(sale);

            sale =
                new Sale
                {
                    SaleID = 1,
                    SaleDate = new DateTime(2024, 11, 29),
                    SaleTime = new TimeSpan(11, 20, 10)
                };
            testSales.Add(sale);


            return testSales;
        }
    }
}
