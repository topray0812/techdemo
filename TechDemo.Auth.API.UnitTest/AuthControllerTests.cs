using TechDemo.Auth.API.Services;
using TechDemo.Auth.API.ViewModels;
using Xunit;
using System.Threading.Tasks;

namespace TechDemo.Auth.API.UnitTest
{
    public class AuthControllerTests
    {
        [Fact]
        public async Task TestLoginAsync()
        {
            // Arrange
            var dbContext = DbContextMocker.GetAuthDbContext();
            var userService = new UserService(dbContext);

            var request = new UserViewModel
            {
                Username = "techdemo",
                Password = "12345"
            };

            // Act
            var user = await userService.Authenticate(request);
            
            dbContext.Dispose();

            // Assert
            Assert.NotNull(user);
        }

    }
}
