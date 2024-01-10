using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Api.Data;
using MyBlog.Api.Models.Repositories;

namespace MyBlog.Api.Filters.ActionFilters;

public class ArticleValidateIdFilterAttribute : ActionFilterAttribute
{
    private readonly ApplicationDbContext _db;

    public ArticleValidateIdFilterAttribute(ApplicationDbContext db)
    {
        this._db = db;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var articleId = context.ActionArguments["id"] as int?;
        if (articleId.HasValue)
        {
            if (articleId.Value <= 0)
            {
                context.ModelState.AddModelError("ArticleId", "ArticleId is invalid");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var article = _db.Articles.Find(articleId.Value);

                if (article == null)
                {
                    context.ModelState.AddModelError("ArticleId", "Article doesn't exist");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
                else
                {
                    context.HttpContext.Items["article"] = article;
                }
            }
        }
    }
}