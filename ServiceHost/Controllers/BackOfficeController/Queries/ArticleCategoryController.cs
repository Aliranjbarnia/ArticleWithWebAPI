using BlogManagement.Application.Contract.ArticleCategories;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers.BackOfficeController.Queries;
[Route("api/[controller]")]
[ApiController]
public class ArticleCategoryController : ControllerBase
{
    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public ArticleCategoryController(IArticleCategoryApplication articleCategoryApplication)
    {
        _articleCategoryApplication = articleCategoryApplication;
    }

    [HttpGet("SearchList")]
    public async Task<List<ArticleCategoryViewModel>> SearchList([FromQuery] ArticleCategorySearchModel command)
    {
        return await _articleCategoryApplication.ArticleCategorySearch(command);
    }

    [HttpGet("GetCategoryById")]
    public async Task<EditArticleCategory?> GetCategoryById([FromQuery] long id)
    {
        return await _articleCategoryApplication.GetDetails(id);
    }
}
