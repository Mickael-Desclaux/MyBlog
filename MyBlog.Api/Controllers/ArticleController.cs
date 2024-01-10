using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Data;
using MyBlog.Api.Filters.ActionFilters;
using MyBlog.Api.Filters.ExceptionFilters;
using MyBlog.Api.Models;
using MyBlog.Api.Models.Repositories;

namespace MyBlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    
    public ArticleController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    [HttpGet("all")]
    public ActionResult<Article> Get()
    {
        return Ok(_db.Articles.ToList());
    }

    [HttpGet("{id:int}")]
    [TypeFilter(typeof(ArticleValidateIdFilterAttribute))]
    public ActionResult<Article> GetById(int id)
    {
        return Ok(HttpContext.Items["article"]);
    }

    [HttpPost]
    [ArticleValidateCreateFilter]
    public ActionResult<Article> Create([FromBody] Article article)
    {
        article.CreatedAt = DateTime.UtcNow;
        article.UpdatedAt = DateTime.UtcNow;
        _db.Articles.Add(article);
        _db.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = article.ArticleId }, article);
    }

    [HttpPut("{id:int}")]
    [TypeFilter(typeof(ArticleValidateIdFilterAttribute))]
    [ArticleValidateUpdateFilter]
    [TypeFilter(typeof(ArticleHandleUpdateExceptionsFilterAttribute))]
    public ActionResult<Article> Update(int id, Article article)
    {
        var articleToUpdate = HttpContext.Items["article"] as Article;
        articleToUpdate.TagIds = article.TagIds;
        articleToUpdate.BookCover = article.BookCover;
        articleToUpdate.BookAuthor = article.BookAuthor;
        articleToUpdate.BookTitle = article.BookTitle;
        articleToUpdate.BookNumberOfPages = article.BookNumberOfPages;
        articleToUpdate.TextSection = article.TextSection;
        articleToUpdate.ReviewResume = article.ReviewResume;
        articleToUpdate.MyNote = article.MyNote;
        articleToUpdate.Quotes = article.Quotes;
        articleToUpdate.UpdatedAt = DateTime.UtcNow;

        _db.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [TypeFilter(typeof(ArticleValidateIdFilterAttribute))]
    public ActionResult<Article> Delete(int id)
    {
        var articleToDelete = HttpContext.Items["article"] as Article;

        _db.Articles.Remove(articleToDelete);
        _db.SaveChanges();
        
        return Ok(articleToDelete);
    }
}