using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Model;
using MyBlog.WebApp.Services;

namespace MyBlog.WebApp.Components.Pages.ComponentsBase;

public class ArticlesBase : ComponentBase
{
    protected List<Article> Articles = new();
    [Inject] private ArticleService ArticleService { get; init; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var articles = await ArticleService.GetAllArticlesAsync();
        Articles = articles;
    }
    
    protected async Task OnDeleteArticle(int articleId)
    {
        await ArticleService.DeleteArticleAsync(articleId);
        await ReloadArticles();
    }
    
    private async Task ReloadArticles()
    {
        Articles = await ArticleService.GetAllArticlesAsync();
        StateHasChanged();
    }
}