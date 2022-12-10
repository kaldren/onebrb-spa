using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigationManager)
        : base(provider, navigationManager)
    {
        //ConfigureHandler(
        //    authorizedUrls: new[] { "https://onebrbapi20221203165217.azurewebsites.net/api" },
        //    scopes: new[] { "https://onebrb.onmicrosoft.com/api/Onebrb.Read" });


        ConfigureHandler(new[] { "https://onebrbapi20221203165217.azurewebsites.net/api" });
    }
}