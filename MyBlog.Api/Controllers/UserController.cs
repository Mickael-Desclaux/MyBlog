using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Api.Data;
using MyBlog.Api.Filters.ActionFilters;
using MyBlog.Api.Models;
using MyBlog.Api.Services;

namespace MyBlog.Api.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly PasswordHasherService _passwordHasherService;

    public UserController(ApplicationDbContext dbContext, PasswordHasherService passwordHasherService)
    {
        _dbContext = dbContext;
        _passwordHasherService = passwordHasherService;
    }
    
    [HttpGet]
    public ActionResult<User> Get()
    {
        return Ok(_dbContext.Users);
    }
    
    [HttpGet("{id:int}")]
    [TypeFilter(typeof(UserValidateIdFilterAttribute))]
    public ActionResult<User> GetById(int id)
    {
        return Ok(HttpContext.Items["user"]);
    }

    [HttpPost("create")]
    public ActionResult<User> Create([FromBody] User user)
    {
        user.Password = _passwordHasherService.HashPassword(user.Password);
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
    }    
    
    [HttpPost("connect")]
    public ActionResult<User> Connect([FromBody] User loginUser)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == loginUser.Email);
        if (user != null && _passwordHasherService.VerifyPassword(loginUser.Password, user.Password))
        {
            return Ok(user);
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpDelete("{id:int}")]
    [TypeFilter(typeof(UserValidateIdFilterAttribute))]
    public ActionResult<User> Delete(int id)
    {
        var userToDelete = HttpContext.Items["user"] as User;
        
        _dbContext.Users.Remove(userToDelete);
        _dbContext.SaveChanges();
        
        return Ok(userToDelete);
    }
}