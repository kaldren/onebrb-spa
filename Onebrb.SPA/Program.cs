using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using Onebrb.SPA;
using Onebrb.SPA.Interfaces;
using OnebrbApi;
using Radzen;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient("OnebrbAPIAuth",
        (srv, client) =>
        {
            client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Api:BaseUrl"));
        })
.AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped<IOnebrbApiClient, OnebrbApiClient>((x) =>
{
    var httpClient = x.GetRequiredService<IHttpClientFactory>().CreateClient("OnebrbAPIAuth");
    var client = ActivatorUtilities.CreateInstance<OnebrbApiClient>(x, builder.Configuration.GetValue<string>("Api:BaseUrl"), httpClient);

    return client;
});

builder.Services.AddHttpClient("OnebrbAPINoAuth",
        (srv, client) =>
        {
            client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Api:BaseUrl"));
        });

builder.Services.AddScoped<IOnebrbApiClientPublic, OnebrbApiClient>((x) =>
{
    var httpClient = x.GetRequiredService<IHttpClientFactory>().CreateClient("OnebrbAPINoAuth");
    var client = ActivatorUtilities.CreateInstance<OnebrbApiClient>(x, builder.Configuration.GetValue<string>("Api:BaseUrl"), httpClient);

    return client;
});


builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://onebrb.onmicrosoft.com/56efe119-737a-44a9-b98e-9cc0a5f8547f/Onebrb.Read");
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

//builder.Services.AddCookieConsent(o =>
//{
//    o.Revision = 1;
//    o.ConsentModalPosition = ConsentModalPosition.BottomRight;
//    o.ConsentModalLayout = ConsentModalLayout.Cloud;
//    o.ConsentSecondaryActionOpensSettings = false;

//    o.Categories.Add(new CookieCategory
//    {
//        TitleText = new()
//        {
//            ["en"] = "Google Services",
//            ["de"] = "Google Dienste"
//        },
//        DescriptionText = new()
//        {
//            ["en"] = "Allows the integration and usage of Google services.",
//            ["de"] = "Erlaubt die Verwendung von Google Diensten."
//        },
//        Identifier = "google",
//        IsPreselected = true,

//        Services = new()
//        {
//            new CookieCategoryService
//            {
//                Identifier = "google-maps",
//                PolicyUrl = "https://policies.google.com/privacy",
//                TitleText = new()
//                {
//                    ["en"] = "Google Maps",
//                    ["de"] = "Google Maps"
//                },
//                ShowPolicyText = new()
//                {
//                    ["en"] = "Display policies",
//                    ["de"] = "Richtlinien anzeigen"
//                }
//            },
//            new CookieCategoryService
//            {
//                Identifier = "google-analytics",
//                PolicyUrl = "https://policies.google.com/privacy",
//                TitleText = new()
//                {
//                    ["en"] = "Google Analytics",
//                    ["de"] = "Google Analytics"
//                },
//                ShowPolicyText = new()
//                {
//                    ["en"] = "Display policies",
//                    ["de"] = "Richtlinien anzeigen"
//                }
//            }
//        }
//    });
//});

await builder.Build().RunAsync();
