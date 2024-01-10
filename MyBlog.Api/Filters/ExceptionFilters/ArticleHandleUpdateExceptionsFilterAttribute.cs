using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Api.Data;

namespace MyBlog.Api.Filters.ExceptionFilters;

public class ArticleHandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
{
    private readonly ApplicationDbContext _db;
    
    public ArticleHandleUpdateExceptionsFilterAttribute(ApplicationDbContext db)
    {
        _db = db;
    }
    public override void OnException(ExceptionContext context)
    {
        base.OnException(context);

        var strArticleId = context.RouteData.Values["id"] as string;
        if (int.TryParse(strArticleId, out int articleId))
        {
            if (_db.Articles.FirstOrDefault(x => x.ArticleId == articleId) == null)
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