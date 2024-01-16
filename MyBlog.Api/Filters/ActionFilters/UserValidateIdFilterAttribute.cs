using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Api.Data;

namespace MyBlog.Api.Filters.ActionFilters;

public class UserValidateIdFilterAttribute(ApplicationDbContext dbContext) : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var userId = context.ActionArguments["id"] as int?;
        if (userId.HasValue)
        {
            if (userId.Value <= 0)
            {
                context.ModelState.AddModelError("UserId", "UserId is invalid");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var user = dbContext.Users.Find(userId.Value);

                if (user == null)
                {
                    context.ModelState.AddModelError("UserId", "User doesn't exist");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
                else
                {
                    context.HttpContext.Items["user"] = user;
                }
            }
        }
    }
}