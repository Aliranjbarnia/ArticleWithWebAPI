namespace BlogManagement.Application.Contract.ArticleCategories;

public class EditArticleCategory : CreateArticleCategory
{
    public long Id { get; set; }
    public string CreationDate { get; set; }
}
