using _01_Framework;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _environment;

        public FileUploader(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string Upload(IFormFile file , string path)
        {
            if (file == null)
            {
                return "";
            }

            var pathRoot = $"{_environment.WebRootPath}//ProductPictures//{path}";
            if (!Directory.Exists(pathRoot))
            {
                Directory.CreateDirectory(pathRoot);
            }

            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{pathRoot}//{fileName}";
            
            using (var output = File.Create(filePath))
            {
                file.CopyTo(output);
            }

            return $"{path}/{fileName}";

        }
    }
}
