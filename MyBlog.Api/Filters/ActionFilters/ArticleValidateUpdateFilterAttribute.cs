using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Api.Models;

namespace MyBlog.Api.Filters;

public class ArticleValidateUpdateFilterAttribute: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var id = context.ActionArguments["id"] as int?;
        var article = context.ActionArguments["article"] as Article;

        if (id.HasValue && article != null && id != article.ArticleId)
        {
            context.ModelState.AddModelError("ArticleId", "ArticleId is not the same as id");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
    }
}