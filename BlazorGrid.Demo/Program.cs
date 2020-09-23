using BlazorGrid.Abstractions;
using BlazorGrid.Config.Styles;
using BlazorGrid.Demo.Providers;
using BlazorGrid.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorGrid.Demo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazorGrid<CustomProvider>(o =>
            {
                o.Styles = new BootstrapStyles();
            });

            await builder.Build().RunAsync();
        }
    }
}
