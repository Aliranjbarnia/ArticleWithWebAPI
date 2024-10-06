using Microsoft.AspNetCore.Http;

namespace _01_Framework;

public interface IFileUploader
{
    string Upload(IFormFile file, string path);
}