using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Buying.IntegrationTests
{
    public class InstructionsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public InstructionsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetActiveInstruction_WhenCalled_ReturnsActiveInstruction()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/instruction/active");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            Assert.NotNull(responseBody);
        }

        [Fact]
        public async Task Cancel_WhenCalled_ReturnsNoContent()
        {
            var client = _factory.CreateClient();

            var response = await client.DeleteAsync("/instruction/cancel");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}