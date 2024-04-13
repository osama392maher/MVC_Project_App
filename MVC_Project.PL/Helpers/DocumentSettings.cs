using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace MVC_Project.PL.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        { 
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            var filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
            

    }
}
