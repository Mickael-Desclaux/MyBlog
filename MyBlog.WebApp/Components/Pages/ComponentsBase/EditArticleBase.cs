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

    public List<string> Genres = new List<string> {
        "Fantasy",
        "Science Fiction",
        "Dystopian",
        "Mystery",
        "Romance",
        "Horror",
        "Action & Aventure",
        "Thriller",
        "Mythology",
        "Historical Fiction",
        "Contemporary Fiction",
        "Graphic Novel",
        "Young Adult",
        "Biography",
        "Art",
        "History",
    };

    public List<string> SelectedGenres = new List<string>();

    public Dictionary<string, bool> genreChecked = new Dictionary<string, bool>();

    #endregion

    #region Functions

    protected override void OnInitialized()
    {
        foreach (var genre in Genres)
        {
            genreChecked.Add(genre, false);
        }
    }

    protected async Task EditArticle()
    {
        SelectedGenres.Clear();
        foreach (var genre in genreChecked)
        {
            if (genre.Value)
            {
                SelectedGenres.Add(genre.Key);
            }
        }

        Article.BookGenres = Article.BookGenres ?? new List<string?>();
        Article.BookGenres.Clear();
        foreach (var genre in SelectedGenres)
        {
            Article.BookGenres.Add(genre);
        }

        await ArticleService.UpdateArticleAsync(Article);
    }
    
    protected void AddQuote()
    {
        if (!string.IsNullOrWhiteSpace(NewQuote))
        {
            if (Article.Quotes == null)
            {
                Article.Quotes = new List<string?>();
            }

            Article.Quotes.Add(NewQuote);
            NewQuote = string.Empty;
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