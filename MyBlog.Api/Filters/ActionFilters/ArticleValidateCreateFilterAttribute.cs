using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Api.Models;

namespace MyBlog.Api.Filters.ActionFilters;

public class ArticleValidateCreateFilterAttribute: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var article = context.ActionArguments["article"] as Article;

        if (article == null)
        {
            context.ModelState.AddModelError("Article", "Article object is null.");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
    }
}