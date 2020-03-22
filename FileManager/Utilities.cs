using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    class Utilities
    {
        public static void processFile(string path,string imagefolder, string soundfolder, string documentfolder)
        {
            string extension = checkExtension(path);
            string filename = Path.GetFileName(path);
            switch(extension)
            {
                case "image":
                    movefile(path, imagefolder, filename);
                    break;
                case "sound":
                    movefile(path, soundfolder, filename);
                    break;
                case "document":
                    movefile(path, documentfolder, filename);
                    break;
                default:
                    movefile(path, documentfolder, filename);
                    break;
            }
          
        }

        public static string checkExtension(string path)
        {
            List<string> image_list = new List<string> { ".img", ".jpg", ".jpeg", ".png", ".apng", ".bmp", ".gif", ".ico", ".cur", ".jfif", ".pjpeg", ".pjp", ".svg", ".tif", ".tiff", ".webp" };
            List<string> sound_list = new List<string> { ".3gp", ".aa", ".aac", ".aax", ".act", ".aiff", ".alac", ".amr", ".ape", ".au", ".awb", ".dct", ".dss", ".dvf", ".flac", ".gsm", ".iklax", ".ivs", ".m4a", ".m4b", ".m4p", ".mmf", ".mp3", ".mpc", ".msv", ".nmf", ".nsf", ".ogg", ".oga", ".mogg", ".opus", ".raw", ".sln", ".tta", ".voc", ".vox", ".wav", ".wma", ".wv", ".webm", ".8svx" };
            List<string> document_list = new List<string> { ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".html", ".txt", ".pptx", ".ppt", ".pps", ".odp",".rtf"};
            string filetype = "";
            var fileExtension = Path.GetExtension(path);
            
            if (image_list.Contains(fileExtension))
            {

                filetype = "image";
                return filetype;
            }
            else if (sound_list.Contains(fileExtension))
            {
                filetype = "sound";
                return filetype;
            }
            else if (document_list.Contains(fileExtension))
            {
                filetype = "document";
                return filetype;
            }
            return filetype;
        }

        public static void movefile(string source, string destination, string filename)
        {
            var placetogo = Path.Combine(destination, filename);
            try
            {
                System.IO.Directory.Move(source, placetogo);
            }
            catch(System.IO.IOException e)
            { 
                Console.ForegroundColor = System.ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }
        }
    }
}
