// Tried to perform a unit test, but ran into many errors, will plan to meet with you next week

/*
using LibraryGroup8;

namespace TestGroup8
{
    public class SupplierTest
    {
        [Fact]
        public void ShouldFindCurrentSupplierOfProduct()
        {
            //Arrange
            string expectedSupplierId = "Sup1";
            Supplier actualSupplier = null;

            List<Product> testProducts = CreateTestData();

            // Action
            actualSupplier = testProducts[0].FindCurrentSupplierOfProduct();

            //Assert
            Assert.Equal(expectedSupplierId, actualSupplier.SupplierID);
        }

        public List<Product> CreateTestData()
        {
            List<Product> testProducts = new List<Product>();

            Product testProduct = new Product { ProductId = 01 };
            testProducts.Add(testProduct);
            testProduct = new Product { ProductId = 02 };
            testProducts.Add(testProduct);

            List<Supplier> testSuppliers = new List<Supplier>();

            Supplier testSupplier = new Supplier { SupplierID = 11 };
            testSuppliers.Add(testSupplier);
            testSupplier = new Supplier { SupplierID = 22 };
            testSuppliers.Add(testSupplier);

            // 11 supplies 01 12/5/24
            DateTime Date = DateTime.Now;
            RestockOrder restockOrder = new RestockOrder(testProducts[0], testSuppliers[0], Date, "En Route");
            
            testProducts[0].SuppliersOfProduct.Add(restockOrder);
            testSuppliers[0].RestocksTheOrder.Add(restockOrder);
        }
    }
}
*/