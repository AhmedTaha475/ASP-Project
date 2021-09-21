using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_BLL.Helper
{
    public class FileControll
    {


        public static string UploadFile(string FolderName,IFormFile File)
        {
            try
            {
                string FolderPath = Directory.GetCurrentDirectory() + FolderName;

                string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);

                string FinalPath = Path.Combine(FolderPath, FileName);

                using (var stream = new FileStream(FinalPath, FileMode.Create))
                {
                    File.CopyTo(stream);

                }
                return FileName;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
         
        }



        public static void RemoveFile(string FolderName,string FileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + "/" + FileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName + "/" + FileName);

            }

        }

    }
}
