using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Model;
using MyBlog.WebApp.Services;

namespace MyBlog.WebApp.Components.Pages.ComponentsBase;

public class ArticlesBase : ComponentBase
{
    #region Statement

    [Inject] protected ArticleService _articleService { get; init; } = default!;
    [Inject] private NavigationManager NavigationManager { get; init; } = default!;
    [Inject] private AuthenticationService AuthenticationService { get; init; } = default!;

    protected bool IsUserAuthenticated { get; private set; }

    protected string searchQuery = string.Empty;

    #endregion

    #region Functions

    protected override async Task OnInitializedAsync()
    {
        var articles = await _articleService.GetAllArticlesAsync();
        _articleService.Articles = articles;

        var isAuthenticated = await AuthenticationService.IsUserAuthenticated();
        IsUserAuthenticated = isAuthenticated;
    }
    
    protected void Callback(Article article)
    {
        EditArticleBase.Article = article;
        NavigationManager.NavigateTo($"EditArticle/{article.ArticleId}");
    }
    
    protected async Task OnDeleteArticle(Article article)
    {
        await _articleService.DeleteArticleAsync(article.ArticleId);
        _articleService.Articles.Remove(article);
    }

    protected string GetBookCover(byte[] imageBytes)
    {
        return $"data:image/jpeg;base64,{Convert.ToBase64String(imageBytes)}";
    }

    protected IEnumerable<Article> FilteredArticles => _articleService.Articles.Where(article =>
    string.IsNullOrEmpty(searchQuery) ||
    article.BookTitle.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
    article.BookAuthor.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));

    protected void FilterArticles()
    {
        StateHasChanged();
    }

    protected void ResetFilter()
    {
        searchQuery = string.Empty;
    }

    #endregion
}