using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string Upload(IFormFile formFile, string root);
        void Delete(string filePath);
        string Update(IFormFile formFile, string filePath, string root);
    }
}