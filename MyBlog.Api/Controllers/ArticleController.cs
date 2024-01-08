using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Filters;
using MyBlog.Api.Models;
using MyBlog.Api.Models.Repositories;

namespace MyBlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Getting all the articles";
    }

    [HttpGet("{id:int}")]
    [ArticleValidateIdFilter]
    public ActionResult<Article> GetById(int id)
    {
        return Ok(ArticleRepository.GetArticleById(id));
    }

    [HttpPost]
    public string Create([FromForm]Article article)
    {
        return "Creating a article";
    }

    [HttpPut("{id:int}")]
    public string Update(int id)
    {
        return $"Updating article with id : {id}";
    }

    [HttpDelete("{id:int}")]
    public string Delete(int id)
    {
        return $"Deleting article with id: {id}";
    }
}