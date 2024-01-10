namespace MyBlog.Api.Models.Repositories;

public static class ArticleRepository
{
    private static List<Article> _articles = new List<Article>()
    {
        new Article
        {
            ArticleId = 1, TagIds = [1, 2], BookAuthor = "test", BookTitle = "Test", BookNumberOfPages = 400, BookCover = "dddd", TextSection = "hfdgbhgdf dfgihdfg", ReviewResume = "ikjfgdnf",
            MyNote = 5, Quotes = ["dfgdfg", "dfgdfg"]
        },
        new Article
        {
            ArticleId = 2, TagIds = [1, 2], BookAuthor = "test", BookTitle = "Test", BookNumberOfPages = 400, BookCover = "ddddghg", TextSection = "hfhgdgbhgdf dfgihdfg", ReviewResume = "ikjfgddgnf",
            MyNote = 4, Quotes = ["dfgdfffg", "dfgdfgff"]
        }
    };

    public static List<Article> GetArticles()
    {
        return _articles;
    }

    public static bool ArticleExists(int id)
    {
        return _articles.Any(x => x.ArticleId == id);
    }

    public static Article? GetArticleById(int id)
    {
        return _articles.FirstOrDefault(a => a.ArticleId == id);
    }

    public static void AddArticle(Article article)
    {
        int maxId = _articles.Max(x => x.ArticleId);
        article.ArticleId = maxId + 1;
        article.CreatedAt = DateTime.Now;
        article.UpdatedAt = DateTime.Now;
        
        _articles.Add(article);
    }

    public static void UpdateArticle(Article article)
    {
        var articleToUpdate = _articles.First(x => x.ArticleId == article.ArticleId);
        articleToUpdate.TagIds = article.TagIds;
        articleToUpdate.BookCover = article.BookCover;
        articleToUpdate.BookAuthor = article.BookAuthor;
        articleToUpdate.BookTitle = article.BookTitle;
        articleToUpdate.BookNumberOfPages = article.BookNumberOfPages;
        articleToUpdate.TextSection = article.TextSection;
        articleToUpdate.ReviewResume = article.ReviewResume;
        articleToUpdate.MyNote = article.MyNote;
        articleToUpdate.Quotes = article.Quotes;
        articleToUpdate.UpdatedAt = DateTime.Now;
    }

    public static void DeleteArticle(int articleId)
    {
        var article = GetArticleById(articleId);
        if (article != null)
        {
            _articles.Remove(article);
        }
    }
}