using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Services;
using MyBlog.WebApp.Model;

namespace MyBlog.WebApp.Components.Pages.ComponentsBase
{
    public class TopBooksBase : ComponentBase
    {
        #region Statement

        [Inject] protected ArticleService _articleService { get; init; } = default!;
        [Inject] private NavigationManager NavigationManager { get; init; } = default!;
        [Inject] private AuthenticationService AuthenticationService { get; init; } = default!;

        protected bool IsUserAuthenticated { get; private set; }

        #endregion

        #region Functions

        protected override async Task OnInitializedAsync()
        {
            var articles = await _articleService.GetFavoriteArticlesAsync();
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

        #endregion
    }
}
