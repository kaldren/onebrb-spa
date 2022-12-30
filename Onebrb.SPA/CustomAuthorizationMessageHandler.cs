using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
{
    private readonly IConfiguration _configuration;

    public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigationManager, IConfiguration configuration)
        : base(provider, navigationManager)
    {
        //ConfigureHandler(
        //    authorizedUrls: new[] { "https://localhost:7088/api" },
        //    scopes: new[] { "https://onebrb.onmicrosoft.com/api/Onebrb.Read" });


        _configuration = configuration;
        ConfigureHandler(new[] { _configuration.GetValue<string>("Api:FullUrl") });
    }
}