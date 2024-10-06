using _01_Framework;

namespace Article.Domain.ArticleCategoryAgg;
public class ArticleCategory : EntityBase
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Picture { get; private set; }
    public bool Remove { get; private set; }
    public bool Active { get; private set; } = true;

    private ArticleCategory() { }
    public ArticleCategory(string title,string description,string picture)
    {
        Title = title;
        Description = description;
        Picture = picture;
    }
    public void Edit(string title, string description, string picture)
    {
        Title = title;
        Description = description;
        if (!string.IsNullOrWhiteSpace(picture))
            Picture = picture;
    }
    public void Removed()
    {
        Remove = true;
        Active = false;
    }
    public void Activation()
    {
        Active = true;
        Remove = false;
    }
}
