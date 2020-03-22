using System.Configuration;
using System.Threading;


namespace FileShepherdTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcefolder = ConfigurationManager.AppSettings.Get("source_folder");
            string documentsfolder = ConfigurationManager.AppSettings.Get("documents_folder");
            string picturesfolder = ConfigurationManager.AppSettings.Get("pictures_folder");
            string soundfolder = ConfigurationManager.AppSettings.Get("music_folder");
            while (true)
            {
                Thread.Sleep(1000);
                FileManager.FileManager.MonitorDirectory(sourcefolder,picturesfolder,soundfolder,documentsfolder);
            }


        }
    }
}
