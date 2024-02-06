using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Data;
using MyBlog.Api.Filters.ActionFilters;
using MyBlog.Api.Filters.ExceptionFilters;
using MyBlog.Api.Models;

namespace MyBlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Article>> Get(bool lastReadings = false)
    {
        var articleNumber = 5;

        IQueryable<Article> query = dbContext.Articles;

        if (lastReadings)
        {
            query = query.OrderByDescending(a => a.CreatedAt).Take(articleNumber);
        }

        var articles = query.ToList();
        return Ok(articles);
    }


    [HttpGet("{id:int}")]
    [TypeFilter(typeof(ArticleValidateIdFilterAttribute))]
    public ActionResult<Article> GetById(int id)
    {
        return Ok(HttpContext.Items["article"]);
    }

    [HttpPost]
    // [Authorize]
    [ArticleValidateCreateFilter]
    public ActionResult<Article> Create([FromBody] Article article)
    {
        article.CreatedAt = DateTime.UtcNow;
        article.UpdatedAt = article.CreatedAt;
        dbContext.Articles.Add(article);
        dbContext.SaveChanges();

        return Ok(article);
    }

    [HttpPut("{id:int}")]
    // [Authorize]
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
        articleToUpdate.BookResume = article.BookResume;
        articleToUpdate.ReviewResume = article.ReviewResume;
        articleToUpdate.MyNote = article.MyNote;
        articleToUpdate.Quotes = article.Quotes;
        articleToUpdate.UpdatedAt = DateTime.UtcNow;

        dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    // [Authorize]
    [TypeFilter(typeof(ArticleValidateIdFilterAttribute))]
    public ActionResult<Article> Delete(int id)
    {
        var articleToDelete = HttpContext.Items["article"] as Article;

        dbContext.Articles.Remove(articleToDelete);
        dbContext.SaveChanges();
        
        return Ok(articleToDelete);
    }
}