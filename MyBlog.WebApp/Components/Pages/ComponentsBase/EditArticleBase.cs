using Microsoft.AspNetCore.Components;
using MyBlog.WebApp.Model;
using MyBlog.WebApp.Services;

namespace MyBlog.WebApp.Components.Pages.ComponentsBase;

public class EditArticleBase : ComponentBase
{
    #region Statement

    [Inject] private ArticleService ArticleService { get; init; } = default!;
    
    protected string NewQuote = string.Empty;
    
    public static Article Article = new();
    
    [Parameter] public int? ArticleId { get; set; }

    #endregion

    #region Functions

    protected async Task EditArticle()
    {
        await ArticleService.UpdateArticleAsync(Article);
    }
    
    protected void AddQuote()
    {
        if (!string.IsNullOrWhiteSpace(NewQuote))
        {
            if (Article.Quotes == null)
            {
                Article.Quotes = new List<string>();
            }

            Article.Quotes.Add(NewQuote);
            NewQuote = string.Empty; // Réinitialiser le champ de saisie
        }
    }

    protected void RemoveQuote(string quote)
    {
        if (Article.Quotes != null && Article.Quotes.Contains(quote))
        {
            Article.Quotes.Remove(quote);
        }
    }

    #endregion
}