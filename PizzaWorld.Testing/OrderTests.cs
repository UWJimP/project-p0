using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class OrderTests
    {
        [Fact]
        private void Test_OrderExists()
        {
            //arrange
            var order = new Order();

            //act
            var actual = order;

            //assert
            Assert.IsType<Order>(actual);
            Assert.NotNull(actual);
        }
    }
}
