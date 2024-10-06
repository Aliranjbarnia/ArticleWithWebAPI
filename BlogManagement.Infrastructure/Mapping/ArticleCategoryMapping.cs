using Article.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.Mapping;
public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
{
    public void Configure(EntityTypeBuilder<ArticleCategory> builder)
    {
        builder.ToTable("ArticleCategories");
        builder.HasKey(x => x.Id);

        builder.Property(x=>x.Title).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(150).IsRequired();
        builder.Property(x=>x.CreationDate).IsRequired();
        builder.Property(x => x.Picture);
        builder.Property(x => x.Active);
        builder.Property(x => x.Remove);
    }
}
