using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extension
{
    public static class Extensions
    {
        public static async Task<string> CreateFile(this IFormFile file, string rootPath, string fileType)
        {
            string fileName = file.FileName;

            if(fileName.Length > 219)
            {
                fileName.Substring(fileName.Length - 219, 219);
            }

            fileName = Guid.NewGuid().ToString() + fileName;

            string path = Path.Combine(rootPath, "uploads", fileType, fileName);

            using(FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }
    }
}
