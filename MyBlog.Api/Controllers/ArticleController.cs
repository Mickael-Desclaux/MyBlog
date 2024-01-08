using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Filters;
using MyBlog.Api.Filters.ExceptionFilters;
using MyBlog.Api.Models;
using MyBlog.Api.Models.Repositories;

namespace MyBlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    [HttpGet("all")]
    public ActionResult<Article> Get()
    {
        return Ok(ArticleRepository.GetArticles());
    }

    [HttpGet("{id:int}")]
    [ArticleValidateIdFilter]
    public ActionResult<Article> GetById(int id)
    {
        return Ok(ArticleRepository.GetArticleById(id));
    }

    [HttpPost]
    [ArticleValidateCreateFilter]
    public ActionResult<Article> Create([FromBody] Article article)
    {
        ArticleRepository.AddArticle(article);

        return CreatedAtAction(nameof(GetById), new { id = article.ArticleId }, article);
    }

    [HttpPut("{id:int}")]
    [ArticleValidateIdFilter]
    [ArticleValidateUpdateFilter]
    [ArticleHandleUpdateExceptionsFilter]
    public ActionResult<Article> Update(int id, Article article)
    {
        ArticleRepository.UpdateArticle(article);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ArticleValidateIdFilter]
    public ActionResult<Article> Delete(int id)
    {
        var article = ArticleRepository.GetArticleById(id);
        ArticleRepository.DeleteArticle(id);
        
        return Ok(article);
    }
}