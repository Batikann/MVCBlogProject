﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities.Helper
{
    public class FileOperationsHelper
    {
        //public static string Add(IFormFile image)
        //{
        //    string directory = Environment.CurrentDirectory + @"\Gallery\";
        //    string fileName = CreateNewFileName(image.FileName);

        //    string path = Path.Combine(directory, "Images");
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        //    {
        //        image.CopyTo(stream);
        //    }

        //    string filePath = Path.Combine(path, fileName);
        //    return fileName;
        //}



        public static string CreateNewFileName(string fileName)
        {
            string[] file = fileName.Split('.');
            string extension = file[1];
            string newFileName = string.Format(@"{0}." + extension, Guid.NewGuid());
            return newFileName;
        }

    }
}
