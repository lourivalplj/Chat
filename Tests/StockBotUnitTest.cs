using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using StockBot;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class StockBotUnitTest
    {
        [Fact]
        public async Task GetStock_Ok()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            using (var client = server.CreateClient())
            {
                var code = "appl.us";
                var response = await client.GetAsync($"api/StockBot/GetStock?stock_code={code}");
                response.EnsureSuccessStatusCode();
                Xunit.Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task GetStock_NotSuccess()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            using (var client = server.CreateClient())
            {
                var code = string.Empty;
                var response = await client.GetAsync($"api/StockBot/GetStock?stock_code={code}");
                var notSuccess = !response.IsSuccessStatusCode;
                Assert.True(notSuccess);
            }
        }
    }
}