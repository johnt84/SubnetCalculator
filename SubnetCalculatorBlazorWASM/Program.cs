using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SubnetCalculatorEngine.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SubnetCalculatorBlazorWASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<SubnetCalculatorInput>();
            builder.Services.AddScoped<SubnetCalculatorEngine.Services.SubnetCalculatorEngine>();

            await builder.Build().RunAsync();
        }
    }
}
