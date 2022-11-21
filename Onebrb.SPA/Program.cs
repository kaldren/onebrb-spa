using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Onebrb.SPA;
using OnebrbApi;
using Radzen;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient("OnebrbAPI",
        (srv, client) =>
        {
            client.BaseAddress = new Uri("https://localhost:7088");
        })
.AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped<IOnebrbApiClient, OnebrbApiClient>((x) =>
{
    var httpClient = x.GetRequiredService<IHttpClientFactory>().CreateClient("OnebrbAPI");
    var client = ActivatorUtilities.CreateInstance<OnebrbApiClient>(x, "https://localhost:7088", httpClient);

    return client;
});

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://onebrb.onmicrosoft.com/833324ec-9cac-45f3-87dd-6f065c77101c/Onebrb.Read");
});

builder.Services.AddLocalization();

builder.Services.AddAutoMapper(typeof(Program));

var jsInterop = builder.Build().Services.GetRequiredService<IJSRuntime>();
var appLanguage = await jsInterop.InvokeAsync<string>("appCulture.get");

if (appLanguage != null)
{
    CultureInfo cultureInfo = new CultureInfo(appLanguage);
    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
}

builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddScoped<DialogService>();

await builder.Build().RunAsync();
