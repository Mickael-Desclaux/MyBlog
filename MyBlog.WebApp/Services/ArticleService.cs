using MyBlog.WebApp.Model;
using System.Net;
using System.Text.Json;

namespace MyBlog.WebApp.Services;

public class ArticleService(HttpClient httpClient)
{
    public List<Article> Articles = new();

    public async Task<List<Article>> GetAllArticlesAsync()
    {
        var response = await httpClient.GetAsync("api/article");
        response.EnsureSuccessStatusCode();

        var articles = await response.Content.ReadFromJsonAsync<List<Article>>();
        return articles ?? new List<Article>();
    }

    public async Task<List<Article>> GetLastReadingsArticlesAsync()
    {
        var response = await httpClient.GetAsync("api/article?lastReadings=true");
        response.EnsureSuccessStatusCode();

        var articles = await response.Content.ReadFromJsonAsync<List<Article>>();
        return articles ?? new List<Article>();
    }

    public async Task<List<Article>> GetFavoriteArticlesAsync()
    {
        var response = await httpClient.GetAsync("api/article/favorites");
        response.EnsureSuccessStatusCode();

        var articles = await response.Content.ReadFromJsonAsync<List<Article>>();
        return articles ?? new List<Article>();
    }
    
    public async Task CreateArticleAsync(Article article)
    {
        var response = await httpClient.PostAsJsonAsync("api/article", article);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteArticleAsync(int articleId)
    {
        var response = await httpClient.DeleteAsync($"api/article/{articleId}");
        response.EnsureSuccessStatusCode();
    }
    
    public async Task UpdateArticleAsync(Article article)
    {
        var response = await httpClient.PutAsJsonAsync($"api/article/{article.ArticleId}", article);
        response.EnsureSuccessStatusCode();
    }

    public async Task<Article> GetArticleByIdAsync(int articleId)
    {
        var response = await httpClient.GetAsync($"api/article/{articleId}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        var article = JsonSerializer.Deserialize<Article>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return article ?? throw new HttpRequestException("Article data is null.", null, HttpStatusCode.NoContent);
    }
}