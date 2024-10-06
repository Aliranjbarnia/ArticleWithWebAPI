using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contract.ArticleCategories;
public class CreateArticleCategory
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile Picture { get; set; }
}
