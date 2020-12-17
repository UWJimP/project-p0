using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class UserTests
    {
        [Fact]
        private void Test_UserExists()
        {
            //arrange
            var user = new User();

            //act
            var actual = user;

            //assert
            Assert.IsType<User>(actual);
            Assert.NotNull(actual);
        }
    }
}
