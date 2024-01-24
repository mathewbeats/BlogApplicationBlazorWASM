using Blazored.LocalStorage;
using ClienteBlogBlazorWASM;
using ClienteBlogBlazorWASM.Services;
using ClienteBlogBlazorWASM.Services.IServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;
using Microsoft.JSInterop;
using Syncfusion.Blazor;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//agregar los servicios

builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped<TMDBClient>();

builder.Services.AddScoped<IServicioAutenticacion, ServicioAutenticacion>();


Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHFqVVhkW1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF9jTXxTdkBnX35YcHBcRQ==;Mgo+DSMBPh8sVXJ0S0d+XE9AcVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3xTckdjWXpadnVTRmZdUg==;NRAiBiAaIQQuGjN/V0Z+XU9EaFtFVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdEVnW39edXBTR2ZcVkV1;Mgo+DSMBMAY9C3t2VVhhQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkFhWX9bdHJUQGBUU0c=;NjIwMjI4QDMyMzAyZTMxMmUzMElEOExRT0I4SDNmVVlkZHZRMDRHdE5ma1MwNGU4WGN5Ky96a2J5L1c3TTQ9");


builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
        options.ProductToken = "CjxRBHF/NAA9UQRzfzc1BlEAc3o1Cj1bAXB6NAo5bjoNJ2ZdYhBVCCo/Dj1WPUsNalV8Al44B2ECAWllMit3cWhZPUsCbFtpDUMkGnxIaVlkMydkVAFpbx4KRGxNJGIIClpnQSJoHhFXd1swbx50S3dTL3kMB1FrAWlvHg9QbEMgfwweSX1YJm8eA0RgUzxiDhlWZ1NZfg4RSXFBKmQSQw9nUyB4ABxRa1M8fQAWWmdeLGcSEVoCQixvDQdIcVgwPUsRWnRFMGQXB0BvUzx9ABZaZ14sZxIRWgJCLG8NB0hxWDA9SxFabF4mdRcHQG9TPH0AFlpnXixnEhFaAkIsbw0HSHFYMD1LL08PbQt3EDRKVlwiYiYqRn9rBUF4IU15I1t6OCBAQWohQnl4a2I+LHoYGGoPaDFfERczT2kLXTU/a3w/AkYlCk9faSEAFShsUj1RV3YZSlInJQgQInN+X1V8eXhEUHlRVCc5V0xLKn92Bmd9ODB3DQRIdUsuH3YvXFN2EVwTL3NoZCd0KyZtQEgKdRE6SXNFDkEWeU4XOFFFEncxXmsNdHQ7N0lqFGQKdk5xMQ==";
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons()
    .AddBlazoriseRichTextEdit()
    .AddBootstrapComponents()
    .AddBootstrapProviders();
    

//para usar el local storage

builder.Services.AddBlazoredLocalStorage();


// builder.Services.AddSyncfusionBlazor();

builder.Services.AddSyncfusionBlazor();


//agregar para la authenticacion y autorizacion
builder.Services.AddAuthorizationCore();





builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(
    s => s.GetRequiredService<AuthStateProvider>());



await builder.Build().RunAsync();
