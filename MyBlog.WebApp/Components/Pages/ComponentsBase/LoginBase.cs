using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Model;
using MyBlog.WebApp.Services;

namespace MyBlog.WebApp.Components.Pages.ComponentsBase;

public class LoginBase : ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject] private AuthenticationService _authenticationService { get; init; } = default!;

    protected User user = new();

    protected async Task LoginAsync()
    {
        var result = await _authenticationService.Login(user.Email, user.Password);
        if (!result)
        {
            return;
        }
        
        NavigationManager.NavigateTo("/");
        StateHasChanged();
    }
}