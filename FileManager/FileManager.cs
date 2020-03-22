using System;
using System.IO;



namespace FileManager
{
    public class FileManager
    {
        DateTime lastread = DateTime.MinValue;
        
        public static void MonitorDirectory(string source_path, string image_path, string sound_path, string document_path)
        {
            string [] files = Directory.GetFiles(source_path);
            foreach(string File in files)
            {
                Utilities.processFile(File,image_path,sound_path,document_path);
            }
        }


    }
}
