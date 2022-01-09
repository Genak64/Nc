using System;
using System.IO;
using System.Collections.Generic;

namespace NcLibrary
{
    public class GcodeIO
    {
        public static List<string> Load(string pathFile)
        {
            List<string> listCommand = new List<string>();

            FileInfo fileInfo = new FileInfo(pathFile);
            if (!fileInfo.Exists) return null;

            using (StreamReader sr=new StreamReader(pathFile))
            {
                while (!sr.EndOfStream) listCommand.Add(sr.ReadLine());
            }

            return listCommand;
        }

        public static int Save(string pathFile, List<string> list)
        {
            using (StreamWriter sw=new StreamWriter(pathFile, false))
            {
                foreach (string item in list) sw.WriteLine(item);
            }

            return 0;
        }

        public static string CreateOutName(string fileName, int Xquantity, int Yquantity)
        {
            FileInfo file = new FileInfo(fileName);

            return String.Concat(fileName.Replace(file.Extension, ""), "_x-", Xquantity.ToString(), "_y-", Yquantity.ToString(),file.Extension); 
        }
    }
}
