using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoImoveis.Domain.v1.Extension
{
    public class ImageUpload
    {
        public static string SaveImg(IFormFile file)
        {
            if (file.Length <= 0) return "";

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images",  DateTime.Now.ToString("ddMMyyyyhhmmss") + file.FileName);
            if(path.Length > 300) return "";
            if (System.IO.File.Exists(path))
            {               
                return "";
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return path;

        }

        public static void DeleteImg(string path)
        {
            if (System.IO.File.Exists(path))
            {
                File.Delete(path);
            }
        }


    }
}
