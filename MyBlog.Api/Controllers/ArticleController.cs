using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Models;

namespace MyBlog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController
{
    [HttpGet]
    public string Get()
    {
        return "Getting all the articles";
    }

    [HttpGet("{id:int}")]
    public string GetById(int id)
    {
        return $"Getting article with ID : {id}";
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