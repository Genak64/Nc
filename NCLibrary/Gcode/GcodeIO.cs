using System;
using System.IO;
using System.Collections.Generic;

namespace NcLibrary
{
    public class GcodeIO
    {
        /// <summary>
        /// Reads a g-code program from a file and returns its text representation
        /// </summary>
        /// <param name="pathFile">Path and file name(required)</param>
        /// <returns>text representation of the g-code program</returns>
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
        /// <summary>
        /// Saves the text representation of the g-code program to a file
        /// </summary>
        /// <param name="pathFile">Path and file name(required)</param>
        /// <param name="list">text representation of the g-code program(required)</param>
        /// <returns></returns>
        public static int Save(string pathFile, List<string> list)
        {
            using (StreamWriter sw=new StreamWriter(pathFile, false))
            {
                foreach (string item in list) sw.WriteLine(item);
            }

            return 0;
        }
        /// <summary>
        /// Creates a new file name based on the old one and the value of the number of copies in X and Y directions
        /// </summary>
        /// <param name="fileName">old file name(required)</param>
        /// <param name="Xquantity">value of the number of copies in X directions(required)</param>
        /// <param name="Yquantity">value of the number of copies in Y directions(required)</param>
        /// <returns></returns>
        public static string CreateOutName(string fileName, int Xquantity, int Yquantity)
        {
            FileInfo file = new FileInfo(fileName);

            return String.Concat(fileName.Replace(file.Extension, ""), "_x-", Xquantity.ToString(), "_y-", Yquantity.ToString(),file.Extension); 
        }
    }
}
