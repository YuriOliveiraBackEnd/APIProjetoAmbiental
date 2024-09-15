using APIAmbiental.Models;
using APIAmbiental.Services;
using Moq;
using Xunit;

namespace AuthControllerTests
{
    public class AuthControllerTests
    {
        private readonly AuthService _authService;

        public AuthControllerTests()
        {
            _authService = new AuthService();
        }

        [Fact]
        public void Authenticate_ValidUser_ReturnsUserModel()
        {
            // Arrange
            var username = "Yuri";
            var password = "pass123";

            // Act
            var result = _authService.Authenticate(username, password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(username, result.Username);
        }

        [Fact]
        public void Authenticate_InvalidUser_ReturnsNull()
        {
            // Arrange
            var username = "InvalidUser";
            var password = "pass123";

            // Act
            var result = _authService.Authenticate(username, password);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Authenticate_EmptyUsernameOrPassword_ReturnsNull()
        {
            // Arrange
            var username = "";
            var password = "pass123";

            // Act
            var result = _authService.Authenticate(username, password);

            // Assert
            Assert.Null(result);
        }

    }
}
