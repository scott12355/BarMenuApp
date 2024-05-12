using System;
using System.Threading.Tasks;
using BarMenuApp.Services;

namespace BarMenuApp.Tests
{
   
    public class MenuTests
    {
        [Fact]
        public async Task TestApiEndpointUriConstruction_WithEmptyRestUrl()
        {
            // Arrange
            RestDrinkMenuService service = new RestDrinkMenuService();
            Constants.RestUrl = string.Empty;

            // Act
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            // Assert
            Assert.ThrowsException<UriFormatException>(() => new Uri(Constants.RestUrl));
        }

        [Fact]
        public async Task TestApiEndpointUriConstruction_WithValidRestUrl()
        {
            // Arrange
            RestDrinkMenuService service = new RestDrinkMenuService();
            Constants.RestUrl = "https://api.example.com/drinks";

            // Act
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            // Assert
            Assert.AreEqual("https://api.example.com/drinks", uri.ToString());
        }

        [Fact]
        public async Task TestApiEndpointUriConstruction_WithRestUrlWithParameters()
        {
            // Arrange
            RestDrinkMenuService service = new RestDrinkMenuService();
            Constants.RestUrl = "https://api.example.com/drinks/{0}";

            // Act
            Uri uri = new Uri(string.Format(Constants.RestUrl, "123"));

            // Assert
            Assert.AreEqual("https://api.example.com/drinks/123", uri.ToString());
        }

        [Fact]
        public async Task TestApiEndpointUriConstruction_WithRestUrlWithSpecialCharacters()
        {
            // Arrange
            RestDrinkMenuService service = new RestDrinkMenuService();
            Constants.RestUrl = "https://api.example.com/drinks/{0}";

            // Act
            Uri uri = new Uri(string.Format(Constants.RestUrl, "test/123"));

            // Assert
            Assert.Equal("https://api.example.com/drinks/test/123", uri.ToString());
        }

        [Fact]
        public async Task TestApiEndpointUriConstruction_WithRestUrlWithSpaces()
        {
            // Arrange
            RestDrinkMenuService service = new RestDrinkMenuService();
            Constants.RestUrl = "https://api.example.com/drinks/{0}";

            // Act
            Uri uri = new Uri(string.Format(Constants.RestUrl, "test 123"));

            // Assert
            Assert.AreEqual("https://api.example.com/drinks/test%20123", uri.ToString());
        }
    }
}