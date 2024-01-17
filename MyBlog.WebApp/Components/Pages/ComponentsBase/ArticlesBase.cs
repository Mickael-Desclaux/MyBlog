﻿using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Components.Pages.Views;
using MyBlog.WebApp.Model;
using MyBlog.WebApp.Services;

namespace MyBlog.WebApp.Components.Pages.ComponentsBase;

public class ArticlesBase : ComponentBase
{
    #region Statement

    protected List<Article> Articles = new();
    [Inject] private ArticleService ArticleService { get; init; } = default!;
    [Inject] private NavigationManager NavigationManager { get; init; } = default!;

    #endregion

    #region Functions

    protected override async Task OnInitializedAsync()
    {
        var articles = await ArticleService.GetAllArticlesAsync();
        Articles = articles;
    }
    
    protected void Callback(Article article)
    {
        EditArticleBase.Article = article;
        NavigationManager.NavigateTo($"EditArticle/{article.ArticleId}");
    }
    
    protected async Task OnDeleteArticle(Article article)
    {
        await ArticleService.DeleteArticleAsync(article.ArticleId);
        Articles.Remove(article);
    }

    #endregion
}