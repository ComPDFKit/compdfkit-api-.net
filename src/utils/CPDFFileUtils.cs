using System;
using System.IO;

namespace ComPDFKit.utils
{
    public class CPDFFileUtils
    {
        /**
         * MultipartFileToFile
         *
         * @param file IFormFile
         * @return FileInfo
         */
        //public static FileInfo MultipartFileToFile(IFormFile file)
        //{
        //    FileInfo toFile = null;
        //    try
        //    {
        //        if (file.Length <= 0)
        //        {
        //            file = null;
        //        }
        //        else
        //        {
        //            using (Stream ins = file.OpenReadStream())
        //            {
        //                toFile = new FileInfo(file.FileName);
        //                InputStreamToFile(ins, toFile);
        //            }
        //        }
        //    }
        //    catch (IOException e)
        //    {
        //        Console.WriteLine(e.StackTrace);
        //    }
        //    return toFile;
        //}

        // Get flow file
        private static void InputStreamToFile(Stream ins, FileInfo file)
        {
            try
            {
                using (FileStream os = file.Create())
                {
                    int bytesRead = 0;
                    byte[] buffer = new byte[8192];
                    while ((bytesRead = ins.Read(buffer, 0, 8192)) != -1)
                    {
                        os.Write(buffer, 0, bytesRead);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
