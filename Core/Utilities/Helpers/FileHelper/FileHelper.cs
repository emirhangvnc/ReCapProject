using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";
        public static IResult Upload(IFormFile file)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message!=null)
            {
                return new ErrorResult(fileExists.Message);       
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message!=null)
            {
                return new ErrorResult(typeValid.Message);
            }

            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateNewImagePath(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace(@"\\", "/"));
        }

        public static IResult Delete(string filePath)
        {
            DeleteOldImageFile((_currentDirectory + filePath).Replace("/", @"\\"));
            return new SuccessResult();
        }

        public static IResult Update(IFormFile file, string filePath)
        {
            var fileExists=CheckFileExists(file);
            if (fileExists.Message!=null)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type=Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName=Guid.NewGuid().ToString();

            if (typeValid.Message!=null)
            {
                return new ErrorResult(typeValid.Message);
            }

            DeleteOldImageFile((_currentDirectory + filePath).Replace("/", @"\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateNewImagePath(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace(@"\\", "/"));
        }

        private static IResult CheckFileExists(IFormFile file)
        {
            if (file!=null&&file.Length>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doesn!t exists");
        }

        private static IResult CheckFileTypeValid(string type)
        {
            if (type!=".jpeg"&&type!=".png"&&type!=".jpg")
            {
                return new ErrorResult("Wrong File Type");
            }
            return new SuccessResult();
        }

        private static void CreateNewImagePath(string directory, IFormFile file)
        {
            using (FileStream fileStream=File.Create(directory))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/", @"\\")))
            {
                File.Delete(directory.Replace("/", @"\\"));
            }
        }
    }
}
