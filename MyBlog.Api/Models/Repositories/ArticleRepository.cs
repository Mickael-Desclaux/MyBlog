namespace MyBlog.Api.Models.Repositories;

public static class ArticleRepository
{
    private static List<Article> _articles = new List<Article>()
    {
        new Article
        {
            ArticleId = 1, TagID = 1, BookCover = "dddd", TextSection = "hfdgbhgdf dfgihdfg", ReviewResume = "ikjfgdnf",
            MyNote = 5, Quotes = ["dfgdfg", "dfgdfg"]
        },
        new Article
        {
            ArticleId = 2, TagID = 1, BookCover = "ddddghg", TextSection = "hfhgdgbhgdf dfgihdfg", ReviewResume = "ikjfgddgnf",
            MyNote = 4, Quotes = ["dfgdfffg", "dfgdfgff"]
        }
    };

    public static bool ArticleExists(int id)
    {
        return _articles.Any(x => x.ArticleId == id);
    }

    public static Article? GetArticleById(int id)
    {
        return _articles.FirstOrDefault(a => a.ArticleId == id);
    }
}