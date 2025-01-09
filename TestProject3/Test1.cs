using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1;
using WebApplication1.Models;

namespace TestProject3
{
    [TestClass]
    public sealed class Test1
    {
        private readonly HttpClient _client;
        private readonly AppDbContext _context;

        public Test1()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);
            _client = server.CreateClient();
            _context = server.Services.GetRequiredService<AppDbContext>();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // Seed the database before each test method
            var seeder = new Seeder(_context);
            seeder.Seed();
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            // Arrange
            var requestUri = "https://localhost/api/People?$expand=Children($expand=FavoriteToys)&$orderby=Id";

            // Act
            var response = await _client.GetAsync(requestUri);

            // Assert
            response.EnsureSuccessStatusCode();

            // Write the response content to the console
            var content = await response.Content.ReadAsStringAsync();

            // Format the JSON with indentation
            var formattedJson = JsonSerializer.Serialize(
                JsonSerializer.Deserialize<object>(content),
                new JsonSerializerOptions { WriteIndented = true }
            );

            Console.WriteLine("Response Content (Formatted JSON):");
            Console.WriteLine(formattedJson);
        }
    }
}
