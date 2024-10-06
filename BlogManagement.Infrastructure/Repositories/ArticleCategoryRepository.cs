using _01_Framework;
using Article.Domain.ArticleCategoryAgg;
using BlogManagement.Application.Contract.ArticleCategories;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.Repositories;
public class ArticleCategoryRepository : RepositoryBase<long,ArticleCategory>, IArticleCategoryRepository
{
    private readonly BlogContext _blogContext;

    public ArticleCategoryRepository(BlogContext blogContext) : base(blogContext)
    {
        _blogContext = blogContext;
    }

    public async Task<List<ArticleCategoryViewModel>> ArticleCategorySearch(ArticleCategorySearchModel searchModel)
    {
        var filter = _blogContext.ArticleCategories.Select(x => new ArticleCategoryViewModel
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            CreationDate = x.CreationDate.ToFarsi(),
            Picture = x.Picture
        });

        if (!string.IsNullOrWhiteSpace(searchModel.Title))
        {
            filter = filter.Where(x => x.Title.Contains(searchModel.Title));
        }
        if (searchModel.Id.HasValue)
        {
            filter = filter.Where(x => x.Id == searchModel.Id);
        }

        return await filter.ToListAsync();
    }

    public async Task<EditArticleCategory?> GetDetails(long id)
    {
        return await _blogContext.ArticleCategories.Where(x => x.Id == id).Select(x => new EditArticleCategory
        {
            Id = x.Id,
            Description = x.Description,
            Title = x.Title,
            CreationDate = x.CreationDate.ToFarsi()
            
        }).FirstOrDefaultAsync();
    }
}
