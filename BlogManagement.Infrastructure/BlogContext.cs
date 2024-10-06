using Article.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure;
public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
        
    }
    public DbSet<ArticleCategory> ArticleCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(ArticleCategoryMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}
