namespace MyBlog.WebApp.Model;

public class Article
{
    public int ArticleId { get; set; }

    public List<int?>? TagIds { get; set; }

    public string? BookAuthor { get; set; }
    
    public string? BookTitle { get; set; }
    
    public int? BookNumberOfPages { get; set; }
    
    public byte[] BookCover { get; set; }
    
    public string? TextSection { get; set; }
    
    public string? BookResume { get; set; }
    
    public string? ReviewResume { get; set; }
    
    public float? MyNote { get; set; }
    
    public List<string?>? Quotes { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}