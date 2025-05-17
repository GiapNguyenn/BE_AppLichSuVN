using Microsoft.AspNetCore.Http;
 using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
namespace HistoryAPI.Helper
{
    public static class FileUploadHelper
    {
       public static async Task<string> SaveImageAsync(IFormFile image, string folderName)
    {
        if (image == null || image.Length == 0)
            throw new ArgumentException("Ảnh không hợp lệ");

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(image.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        return $"/{folderName}/{fileName}";
    }
    }
}