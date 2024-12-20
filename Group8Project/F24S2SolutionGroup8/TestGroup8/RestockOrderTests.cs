using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryGroup8;
using static LibraryGroup8.RestockOrder;

namespace TestGroup8
{
    public class RestockOrderTests
    {
        [Fact]
        public void Approve_ShouldChangeStatusToApproved()
        {
            // Arrange
            var order = new RestockOrder { Status = RestockOrderStatus.Pending };

            // Act
            order.Approve();

            // Assert
            Assert.Equal(RestockOrderStatus.Approved, order.Status);
        }

        [Fact]
        public void Approve_ShouldThrowException_WhenOrderIsAlreadyCancelled()
        {
            // Arrange
            var order = new RestockOrder { Status = RestockOrderStatus.Cancelled };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => order.Approve());
        }


        [Fact]
        public void Cancel_ShouldChangeStatusToCancelled()
        {
            // Arrange
            var order = new RestockOrder { Status = RestockOrderStatus.Pending };

            // Act
            order.Cancel();

            // Assert
            Assert.Equal(RestockOrderStatus.Cancelled, order.Status);
        }
        [Fact]
        public void Cancel_ShouldThrowException_WhenOrderIsAlreadyApproved()
        {
            // Arrange
            var order = new RestockOrder { Status = RestockOrderStatus.Approved };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => order.Cancel());
        }
    }
}

