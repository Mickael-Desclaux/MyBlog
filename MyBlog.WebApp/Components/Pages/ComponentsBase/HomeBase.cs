using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MyBlog.WebApp.Model;
using MyBlog.WebApp.Services;

namespace MyBlog.WebApp.Components.Pages.ComponentsBase
{
    public class HomeBase : ComponentBase
    {
        protected List<Article> Articles = new();
        [Inject] private ArticleService ArticleService { get; init; } = default!;

        [Inject] private AuthenticationService AuthenticationService { get; init; } = default!;

        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; init; } = default!;

        protected string userEmail = "";
        protected bool IsUserAuthenticated { get; private set; }

        protected async Task Logout()
        {
            await AuthenticationService.Logout();
        }

        protected override async Task OnInitializedAsync()
        {
            var articles = await ArticleService.GetLastReadingsArticlesAsync();
            Articles = articles;

            var isAuthenticated = await AuthenticationService.IsUserAuthenticated();
            IsUserAuthenticated = isAuthenticated;
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                userEmail = user.FindFirst(c => c.Type == System.Security.Claims.ClaimTypes.Email)?.Value ?? "Non spécifié";
            }
        }
    }
}
