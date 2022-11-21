using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnebrbApi;

namespace Onebrb.SPA
{
    public class CustomErrorBoundry : ErrorBoundary
    {
        [Inject]
        private IWebAssemblyHostEnvironment _env { get; set; }

        [Inject]
        private IToastService _toastService { get; set; }

        protected override Task OnErrorAsync(Exception exception)
        {
            if (exception is ApiException<ProblemDetails>)
            {
                _toastService.ShowError(exception.Message);
            }
            else
            {
                _toastService.ShowError("Error! Please try again later.");
            }

            if (_env.IsDevelopment())
                return base.OnErrorAsync(exception);

            return Task.CompletedTask;
        }
    }
}
