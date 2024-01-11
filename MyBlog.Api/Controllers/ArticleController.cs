﻿using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Data;
using MyBlog.Api.Filters.ActionFilters;
using MyBlog.Api.Filters.ExceptionFilters;
using MyBlog.Api.Models;

namespace MyBlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    
    public ArticleController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public ActionResult<Article> Get()
    {
        return Ok(_dbContext.Articles);
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
        article.UpdatedAt = article.CreatedAt;
        _dbContext.Articles.Add(article);
        _dbContext.SaveChanges();

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
        articleToUpdate.BookResume = article.BookResume;
        articleToUpdate.ReviewResume = article.ReviewResume;
        articleToUpdate.MyNote = article.MyNote;
        articleToUpdate.Quotes = article.Quotes;
        articleToUpdate.UpdatedAt = DateTime.UtcNow;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [TypeFilter(typeof(ArticleValidateIdFilterAttribute))]
    public ActionResult<Article> Delete(int id)
    {
        var articleToDelete = HttpContext.Items["article"] as Article;

        _dbContext.Articles.Remove(articleToDelete);
        _dbContext.SaveChanges();
        
        return Ok(articleToDelete);
    }
}