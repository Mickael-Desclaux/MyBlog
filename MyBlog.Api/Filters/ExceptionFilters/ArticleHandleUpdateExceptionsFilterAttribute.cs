using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Api.Models.Repositories;

namespace MyBlog.Api.Filters.ExceptionFilters;

public class ArticleHandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        base.OnException(context);

        var strArticleId = context.RouteData.Values["id"] as string;
        if (int.TryParse(strArticleId, out int articleId))
        {
            if (!ArticleRepository.ArticleExists(articleId))
            {
                context.ModelState.AddModelError("ArticleId", "Article doesn't exist anymore");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status404NotFound
                };
                context.Result = new NotFoundObjectResult(problemDetails);
            }
        }
    }
}