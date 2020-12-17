using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class StoreTests
    {
        [Fact]
        private void Test_StoreExists()
        {
            //arrange
            var store = new Store();

            //act
            var actual = store;

            //assert
            Assert.IsType<Store>(actual);
            Assert.NotNull(actual);
        }
    }
}
