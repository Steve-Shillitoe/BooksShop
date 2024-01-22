using BooksShop;
using BooksShop.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BooksShop
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //To be able to inject an Interface with its implementation, 
            //we need to register it in this DI container
            builder.Services.AddScoped < ILoggingService, ConsoleLoggingService>();
            builder.Services.AddScoped<IBooksService, LocalBooksService>();
            await builder.Build().RunAsync();
        }
    }
}