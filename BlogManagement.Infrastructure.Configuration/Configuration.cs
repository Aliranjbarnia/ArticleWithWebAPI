using Article.Domain.ArticleCategoryAgg;
using BlogManagement.Application;
using BlogManagement.Application.Contract.ArticleCategories;
using BlogManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Infrastructure.Configuration;
public static class Configuration
{
    public static void Bootstrapper(IServiceCollection services,string connectionString)
    {
        services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
        services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();

        services.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString));
    }
}
