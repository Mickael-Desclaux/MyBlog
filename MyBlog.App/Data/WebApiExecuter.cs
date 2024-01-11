using MyBlog.Api.Models;

namespace MyBlog.App.Data;

public class WebApiExecuter
{
    private const string ApiName = "MyBlogApi";
    private readonly IHttpClientFactory _httpClientFactory;

    public WebApiExecuter(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<Article>?> GetArticles(string relativeUrl)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiName);
        return await httpClient.GetFromJsonAsync<List<Article>>(relativeUrl);
    }
}