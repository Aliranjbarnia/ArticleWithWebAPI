using _01_Framework;
using BlogManagement.Application.Contract.ArticleCategories;

namespace Article.Domain.ArticleCategoryAgg;
public interface IArticleCategoryRepository : IRepository<long,ArticleCategory>
{
    Task<EditArticleCategory?> GetDetails(long id);
    Task<List<ArticleCategoryViewModel>> ArticleCategorySearch(ArticleCategorySearchModel searchModel);
}
