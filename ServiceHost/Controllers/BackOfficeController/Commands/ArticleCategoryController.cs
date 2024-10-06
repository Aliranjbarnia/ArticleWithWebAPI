using _01_Framework;
using BlogManagement.Application.Contract.ArticleCategories;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers.BackOfficeController.Commands;
[Route("api/[controller]")]
[ApiController]
public class ArticleCategoryController : ControllerBase
{
    private readonly IArticleCategoryApplication _articleCategory;

    public ArticleCategoryController(IArticleCategoryApplication articleCategory)
    {
        _articleCategory = articleCategory;
    }

    [HttpPost("CreateCategory")]
    public  OperationResult CreateCategory([FromForm] CreateArticleCategory command)
    {
        return  _articleCategory.CreateArticleCategory(command);
    }

    [HttpPut("EditCategory")]
    public  OperationResult EditCategory([FromForm] EditArticleCategory command)
    {
        return  _articleCategory.EditArticleCategory(command);
    }

    [HttpDelete("RemoveCategory")]
    public OperationResult RemoveCategory([FromBody] long id)
    {
        return _articleCategory.Removed(id);
    }

    [HttpPatch("ActiveCategory")]
    public OperationResult ActiveCategory([FromBody] long id)
    {
        return _articleCategory.Active(id);
    }
}
