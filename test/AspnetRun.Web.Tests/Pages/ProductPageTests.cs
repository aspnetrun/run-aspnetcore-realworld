using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspnetRun.Web.Tests.Pages
{
    public class ProductPageTests : IClassFixture<CustomWebApplicationFactory>
    {
        public HttpClient Client { get; }

        public ProductPageTests(CustomWebApplicationFactory factory)
        {
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task Product_Page_Test()
        {
            // Arrange & Act
            var response = await Client.GetAsync("/Product");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("Samsung", stringResponse);
        }
    }
}
