using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace MyBlog.WebApp.Services;

public class AuthenticationService(ILocalStorageService localStorage, HttpClient httpClient)
{
    public static bool isAuthenticated { get; set; }

    public async Task<bool> Login(string email, string password)
    {
        var response = await httpClient.PostAsJsonAsync("login", new { email, password });
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Login failed\n" + response.StatusCode);
            return false;
        }

        var jsonResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
        if (jsonResponse?.AccessToken != null)
        {
            await localStorage.SetItemAsync("accessToken", jsonResponse.AccessToken);
            await InitializeHttpClient(jsonResponse.AccessToken);
            return true;
        }

        return false;
    }

    private class TokenResponse
    {
        public string? AccessToken { get; set; }
    }

    private Task InitializeHttpClient(string token)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return Task.CompletedTask;
    }

    public async Task Logout()
    {
        await localStorage.RemoveItemAsync("accessToken");
        httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<bool> IsUserAuthenticated()
    {
        var token = await localStorage.GetItemAsync<string>("accessToken");
        return !string.IsNullOrWhiteSpace(token);
    }
}