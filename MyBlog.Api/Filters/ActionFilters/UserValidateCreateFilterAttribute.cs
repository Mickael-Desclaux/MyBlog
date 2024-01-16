using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Api.Data;
using MyBlog.Api.Models;

namespace MyBlog.Api.Filters.ActionFilters;

public class UserValidateCreateFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var dbContext = context.HttpContext.RequestServices.GetService<ApplicationDbContext>();
        var user = context.ActionArguments["user"] as User;

        if (user == null)
        {
            context.ModelState.AddModelError("User", "User object is null.");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
        
        var existingUser = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
        if (existingUser != null)
        {
            context.ModelState.AddModelError("Email", "An user with this email already exists.");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }

        base.OnActionExecuting(context);
    }
}