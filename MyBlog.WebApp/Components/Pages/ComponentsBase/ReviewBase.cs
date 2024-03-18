using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Model;
using MyBlog.WebApp.Services;

namespace MyBlog.WebApp.Components.Pages.ComponentsBase
{
    public class ReviewBase : ComponentBase
    {
        [Parameter]
        public int id { get; set; }

        [Inject] protected ArticleService _articleService { get; init; } = default!;

        protected Article article { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (_articleService.Articles.Count == 0)
            {
                var articles = await _articleService.GetAllArticlesAsync();
                _articleService.Articles = articles;
            }

            Console.WriteLine(_articleService.Articles.Count);
            article = _articleService.Articles.First(a => a.ArticleId == id);

            if (article == null)
            {
                article = await _articleService.GetArticleByIdAsync(id);
                Console.WriteLine("Appel via l'API");
            }
        }

        protected string GetBookCover(byte[] imageBytes)
        {
            return $"data:image/jpeg;base64,{Convert.ToBase64String(imageBytes)}";
        }
    }
}
