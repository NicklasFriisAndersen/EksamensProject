﻿using Microsoft.AspNetCore.Components.Web;
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

        builder.Services.AddSingleton(sp => new HttpClient
        {
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        });

       builder.Services.AddBlazoredLocalStorageAsSingleton();

        builder.Services.AddSingleton<IRegisterChildService, RegisterChildService>();
        builder.Services.AddSingleton<ILoginService, LoginService>();
        builder.Services.AddSingleton<IU18VolunteerService, U18VolunteerService>();
        builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddSingleton<IPeriodService, PeriodService>();
        builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddSingleton<IClipboardService, ClipboardService>();

        builder.Services
            .AddBlazorise(options =>
            {
                options.Immediate = true; 
            })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons(); 

        await builder.Build().RunAsync();
    }
}

