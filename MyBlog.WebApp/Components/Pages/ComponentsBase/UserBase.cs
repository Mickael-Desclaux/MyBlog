using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Model;

namespace MyBlog.WebApp.Components.Pages.ComponentsBase;

public class UserBase : ComponentBase
{
    [Inject] protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject] protected HttpClient HttpClient { get; set; } = default!;

    protected User user = new User();

    protected async Task HandleLoginAsync()
    {
        var response = await HttpClient.PostAsJsonAsync("user/connect", user);
        if (response.IsSuccessStatusCode)
        {
            NavigationManager.NavigateTo("/");
        }
    }
}