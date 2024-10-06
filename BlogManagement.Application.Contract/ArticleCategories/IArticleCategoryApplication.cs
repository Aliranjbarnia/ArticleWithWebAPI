using _01_Framework;

namespace BlogManagement.Application.Contract.ArticleCategories;
public interface IArticleCategoryApplication
{
    OperationResult CreateArticleCategory(CreateArticleCategory command);
    OperationResult EditArticleCategory(EditArticleCategory command);
    Task<EditArticleCategory?> GetDetails(long id);
    Task<List<ArticleCategoryViewModel>> ArticleCategorySearch(ArticleCategorySearchModel searchModel);
    OperationResult Removed(long id);
    OperationResult Active(long id);
}
