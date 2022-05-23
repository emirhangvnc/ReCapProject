using Core.Utilities.Helpers.FileHelper.Abstract;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Core.Utilities.Helpers.FileHelper.Concrete
{
    public class FileHelperManager : IFileHelper
    {
        public string Add(IFormFile file, string root)
        {
            if (file.Length>0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName); //Dosya Adı
                string guid = GuidHelper.CreateGuild(); //Oluşturulan Guid
                string filePath = guid + extension; //Birleşim

                using (FileStream fileStream=File.Create(root+filePath))
                {
                    file.CopyTo(fileStream); //Dosyanın kopyalanma yolu
                    fileStream.Flush(); //Arabellekten Siler
                    return filePath;
                }
            }
            return null;
        }

        //fileStream : Belirtilen dosyalar üzerinde bazı işlevleri vardır(Oku/Yazdır vb..)
        //IFromFile : Projeye dosya yüklemesini sağlar.

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))//Bu isim de dosya var mı?
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Update(file,filePath, root);
        }
    }
}
