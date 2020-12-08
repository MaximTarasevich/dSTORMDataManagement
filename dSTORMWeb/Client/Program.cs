using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.LocalStorage;
using Syncfusion.Blazor;
using dSTORMWeb.Client.Services;

namespace dSTORMWeb.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MDAxQDMxMzgyZTMxMmUzME5UakgwSnMyWTF6WFFtNVh5dm9hZ0tYV0k3RFowNUsvbWtpdXFvUFYyaEk9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");


            builder.Services.AddScoped<HTTPService>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });




            await builder.Build().RunAsync();
        }
    }
}