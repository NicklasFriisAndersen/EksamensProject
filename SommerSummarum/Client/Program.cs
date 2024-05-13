using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using SommerSummarum;
using Blazorise;
using Blazorise.Bootstrap; 
using Blazorise.Icons.FontAwesome;
using SommerSummarum.Services;



namespace SommerSummarum;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7016/") });

        builder.Services.AddSingleton(sp => new HttpClient
        {
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        });

        builder.Services.AddBlazoredLocalStorage();

        builder.Services.AddSingleton<IRegisterChildService, RegisterChildService>();
        builder.Services.AddSingleton<ILoginService, LoginService>();


        builder.Services
            .AddBlazorise(options =>
            {
                options.Immediate = true; // Optional, change based on your needs
            })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons(); // Optional, change based on your needs

        await builder.Build().RunAsync();
    }
}

