using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Model;
using MyBlog.WebApp.Services;

namespace MyBlog.WebApp.Components.Pages;

public class ArticlesBase : ComponentBase
{
    protected List<Article> Article = new();
    [Inject] private ArticleService ArticleService { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var articles = await ArticleService.GetAllArticlesAsync();
        Article = articles;
    }
}