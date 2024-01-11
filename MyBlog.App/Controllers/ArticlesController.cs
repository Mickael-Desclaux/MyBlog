using Microsoft.AspNetCore.Mvc;
using MyBlog.App.Data;

namespace MyBlog.App.Controllers;

public class ArticlesController : Controller
{
    private readonly WebApiExecuter _webApiExecuter;

    public ArticlesController(WebApiExecuter webApiExecuter)
    {
        _webApiExecuter = webApiExecuter;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _webApiExecuter.GetArticles("article"));
    }
}