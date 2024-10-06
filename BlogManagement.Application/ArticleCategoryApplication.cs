using _01_Framework;
using Article.Domain.ArticleCategoryAgg;
using BlogManagement.Application.Contract.ArticleCategories;

namespace BlogManagement.Application;
public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository _repository;
    private readonly IFileUploader _fileUploader;

    public ArticleCategoryApplication(IArticleCategoryRepository repository, IFileUploader fileUploader)
    {
        _repository = repository;
        _fileUploader = fileUploader;
    }

    public  OperationResult Active(long id)
    {
        OperationResult operationResult = new OperationResult();
        var articleCategory = _repository.Get(id);
        if (articleCategory == null)
            return operationResult.Failed(ApplicationMessage.RecordNotFound);

        articleCategory.Activation();
        _repository.SaveChanges();
        return operationResult.Succedded();
    }

    public async Task<List<ArticleCategoryViewModel>> ArticleCategorySearch(ArticleCategorySearchModel searchModel)
    {
        return await _repository.ArticleCategorySearch(searchModel);
    }

    public OperationResult CreateArticleCategory(CreateArticleCategory command)
    {
        OperationResult operationResult = new OperationResult();
        if (_repository.Exists(x => x.Title == command.Title))
            return operationResult.Failed(ApplicationMessage.DuplicatedRecord);
        var picture = _fileUploader.Upload(command.Picture, command.Title);
        var articleCategory = new ArticleCategory(command.Title,command.Description,picture);
        _repository.Create(articleCategory);
        _repository.SaveChanges();
        return operationResult.Succedded();
    }

    public  OperationResult EditArticleCategory(EditArticleCategory command)
    {
        OperationResult operationResult = new OperationResult();
        var articleCategory = _repository.Get(command.Id);

        if (articleCategory == null)
            return operationResult.Failed(ApplicationMessage.RecordNotFound);
        if (_repository.Exists(x => x.Title == command.Title && x.Id == command.Id))
            return operationResult.Failed(ApplicationMessage.DuplicatedRecord);

        var picture = _fileUploader.Upload(command.Picture, command.Title);
        articleCategory.Edit(command.Title, command.Description, picture);
        _repository.SaveChanges();
        return operationResult.Succedded();
    }

    public async Task<EditArticleCategory?> GetDetails(long id)
    {
        return await _repository.GetDetails(id);
    }

    public OperationResult Removed(long id)
    {
        OperationResult operationResult = new OperationResult();
        var articleCategory = _repository.Get(id);
        if (articleCategory == null)
            return operationResult.Failed(ApplicationMessage.RecordNotFound);

        articleCategory.Removed();
        _repository.SaveChanges();
        return operationResult.Succedded();
    }
}
