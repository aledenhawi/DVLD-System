using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DVLD_Classes
{
    public class clsUtil
    {
        public static string GeterateGuid() 
        {
            return Guid.NewGuid().ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath) 
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                } 
                catch 
                {
                    return false;
                }
            }
            return true;
        }

        public static string RepleaceFileNameWithGuid(string SourceFile) 
        {
            string FileName = SourceFile;
            FileInfo FileInfo = new FileInfo(FileName);
            string ext = FileInfo.Extension;
            return GeterateGuid() + ext;
        }

        public static bool CopyImageToProjectImagesFile(ref string SourceFile) 
        {
            string DestinationFolder = "C:\\DVLD-Images";

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
                return false;

            string DestinationFile = Path.Combine(DestinationFolder,RepleaceFileNameWithGuid(SourceFile));

            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch(IOException)
            { 
                
            }

            SourceFile = DestinationFile;

            return true;
        }

    }
}
