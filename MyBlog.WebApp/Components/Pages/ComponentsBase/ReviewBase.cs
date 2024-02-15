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
            article = _articleService.Articles.FirstOrDefault(a => a.ArticleId == id);
            
            if (article == null)
            {
                article = await _articleService.GetArticleByIdAsync(id);
                Console.WriteLine("Appel via l'API");
            }
        }
    }
}
