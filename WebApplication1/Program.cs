using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                // Use Startup.cs to configure services and middleware
                webBuilder.UseStartup<Startup>();
            });

            var app = builder.Build();

            app.Run();
        }
    }
}
