using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper.Abstract
{
    public interface IFileHelper
    {
        string Add(IFormFile file,string root);
        void Delete(string filePath);
        string Update(IFormFile file,string filePath,string root);
    }
}
