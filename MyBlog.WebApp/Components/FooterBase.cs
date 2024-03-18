using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Services;

namespace MyBlog.WebApp.Components
{
    public class FooterBase : ComponentBase
    {
        [Inject] protected AuthenticationService AuthService { get; init; } = default!;

        protected bool IsUserAuthenticated { get; private set; }

        protected async Task Logout()
        {
            await AuthService.Logout();
        }

        protected override async Task OnInitializedAsync()
        {
            var isAuthenticated = await AuthService.IsUserAuthenticated();
            IsUserAuthenticated = isAuthenticated;

            Console.WriteLine(AuthenticationService.isAuthenticated);
        }
    }
}
