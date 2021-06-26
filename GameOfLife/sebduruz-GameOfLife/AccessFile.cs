/// Autor : Sébastien Duruz
/// Date : 22.06.2021
/// Description : Acces file and check for errors related to file.

using System;
using System.IO;

namespace sebduruz_GameOfLife
{
    /// <summary>
    /// Class AccesFile
    /// </summary>
    public static class AccessFile
    {
        /// <summary>
        /// Read the content of a given file.
        /// </summary>
        /// <param name="path">The path of the file to read</param>
        /// <returns>The content of the file readed. Null if content could not be readed</returns>
        public static string ReadContent(string path)
        {
            if(CheckFile(path))
            {
                try
                {
                    // Read all the text contains in the file
                    return File.ReadAllText(path);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"ReadContent throw at {DateTime.Now} Exception : {ex.Message}\n{ex.StackTrace}");

                    return null;
                }
            }
            else
            {
                // Create the file
                File.Create(path);

                return null;
            }
        }

        /// <summary>
        /// Write content of a string to file (erase the existing file)
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <param name="contentToWrite">The string to write into file</param>
        /// <returns></returns>
        public static bool WriteContent(string path, string contentToWrite)
        {
            try
            {
                File.WriteAllText(path, contentToWrite);
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"WriteContent throw at {DateTime.Now} Exception : {ex.Message}\n{ex.StackTrace}");
                
                return false;
            }
        }

        /// <summary>
        /// Check if the file alrealy exists
        /// </summary>
        /// <param name="path">The path of the file to check</param>
        /// <returns>true if exists, false if not</returns>
        public static bool CheckFile(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }
    }
}
