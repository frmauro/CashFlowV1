using CashFlow.Application.Moviment;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

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
        public async Task GetAsyncTest_Success()
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync("/CashFlow/");
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


        [Test]
        public async Task AddAsyncTest_Success()
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.PostAsJsonAsync("/CashFlow/", new MovementDto {
                    MovementValue = 200,
                    MovementType = "1",
                    PersonName = $"TestName_{DateTime.Now.Millisecond}",
                    PersonType = "1",
            }) ;
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            
        }



    }
}