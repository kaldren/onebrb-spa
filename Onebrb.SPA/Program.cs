using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Onebrb.SPA;
using OnebrbApi;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient<IOnebrbApiClient, OnebrbApiClient>()
    .AddHttpMessageHandler(sp => sp.GetRequiredService<CustomAuthorizationMessageHandler>());

builder.Services.AddScoped<IOnebrbApiClient>(p => ActivatorUtilities.CreateInstance<OnebrbApiClient>(p, "https://localhost:7088"));

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://onebrb.onmicrosoft.com/api/Onebrb.Read");
});

builder.Services.AddLocalization();

var jsInterop = builder.Build().Services.GetRequiredService<IJSRuntime>();
var appLanguage = await jsInterop.InvokeAsync<string>("appCulture.get");

if (appLanguage != null)
{
    CultureInfo cultureInfo = new CultureInfo(appLanguage);
    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
}


await builder.Build().RunAsync();
