using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigationManager)
        : base(provider, navigationManager)
    {
        //ConfigureHandler(
        //    authorizedUrls: new[] { "https://localhost:7088/api" },
        //    scopes: new[] { "https://onebrb.onmicrosoft.com/api/Onebrb.Read" });


        ConfigureHandler(new[] { "https://localhost:7088/api" });
    }
}