using MyBlog.WebApp.Model;

namespace MyBlog.WebApp.Services;

public class ArticleService(HttpClient httpClient)
{
    public async Task<List<Article>> GetAllArticlesAsync()
    {
        var response = await httpClient.GetAsync("article");
        response.EnsureSuccessStatusCode();

        var articles = await response.Content.ReadFromJsonAsync<List<Article>>();
        return articles ?? new List<Article>();
    }
    
    //Add CRUD operations here
}