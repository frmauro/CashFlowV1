using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CashFlowIntegrationTest
{
    public class MovementTest
    {
        private WebApplicationFactory<Program> _factory;
        [SetUp]
        public void Setup()
        {
            var factory = new WebApplicationFactory<Program>();
            _factory = factory;
        }

        [Test]
        public async Task GetAsyncTest()
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync("/CashFlow/");
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Pass();
        }
    }
}