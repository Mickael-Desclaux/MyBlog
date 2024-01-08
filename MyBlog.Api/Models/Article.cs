namespace MyBlog.Api.Models;

public class Article
{
    public int ArticleId { get; set; }
    
    public int TagId { get; set; }
    
    public string? BookCover { get; set; }
    
    public string? TextSection { get; set; }
    
    public string? ReviewResume { get; set; }
    
    public float? MyNote { get; set; }
    
    public List<string?>? Quotes { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}