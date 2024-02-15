﻿using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Model;
using MyBlog.WebApp.Services;

namespace MyBlog.WebApp.Components.Pages.ComponentsBase;

public class ArticlesBase : ComponentBase
{
    #region Statement

    [Inject] protected ArticleService _articleService { get; init; } = default!;
    [Inject] private NavigationManager NavigationManager { get; init; } = default!;

    #endregion

    #region Functions

    protected override async Task OnInitializedAsync()
    {
        var articles = await _articleService.GetAllArticlesAsync();
        _articleService.Articles = articles;
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

    #endregion
}