using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class PizzaTests
    {
        [Fact]
        private void Test_PizzaExists()
        {
            //arrange
            var pizza = new Pizza();

            //act
            var actual = pizza;

            //assert
            Assert.IsType<Pizza>(actual);
            Assert.NotNull(actual);
        }
    }
}
