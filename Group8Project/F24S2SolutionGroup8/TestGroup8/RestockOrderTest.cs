using LibraryGroup8;

namespace TestGroup8

{
    public class RestockOrderTest
    {

        [Fact]
        public void ShouldApproveRestockOrderAndChangeStatus()
        {
            // AAA Pattern

            // Arrange (Set up)
            string expectedStatus = "Approved";
            RestockOrder restockOrder = CreateTestRestockOrder();

            // Action
            bool result = restockOrder.approve();  

            // Assert
            Assert.True(result);  
            Assert.Equal(expectedStatus, restockOrder.Status);  
        }


        public RestockOrder CreateTestRestockOrder()
        {
            // Create a Supplier instance for the test
            var supplier = new Supplier
            {
                Name = "Test Supplier",
                ContactInfo = "contact@testsupplier.com"
            };

            // Create a Product instance for the test using the Supplier object
            var product = new Product("Test Product", "Test Description", 50, 10, 200, supplier);

            // Create a RestockOrder instance with the product, supplier, and initial status
            var restockOrder = new RestockOrder(supplier, product, DateTime.Now, "Pending")
            {
                RestockOrderId = 1 // Set a test RestockOrderId
            };

            return restockOrder;
        }
    }
}


















