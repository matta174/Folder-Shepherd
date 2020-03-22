using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FolderShepherdService
{

    public partial class FolderShepherdService : ServiceBase
    {
        public string sourcefolder = ConfigurationManager.AppSettings.Get("source_folder");
        public string documentsfolder = ConfigurationManager.AppSettings.Get("documents_folder");
        public string picturesfolder = ConfigurationManager.AppSettings.Get("pictures_folder");
        public string soundfolder = ConfigurationManager.AppSettings.Get("music_folder");
        System.Threading.Thread m_thread = null;

        //EventLog eventLog1 = new System.Diagnostics.EventLog();
        private int eventId = 1;
        public FolderShepherdService()
        {
            InitializeComponent();

        }



        public async Task StartTimer(System.Threading.CancellationToken cancellationToken)
        {

            await Task.Run(async () =>
            {
                while (true)
                {
                    FileManager.FileManager.MonitorDirectory(sourcefolder, picturesfolder, soundfolder, documentsfolder);
                    await Task.Delay(10000, cancellationToken);
                    if (cancellationToken.IsCancellationRequested)
                        break;
                }
            });
        }

        public void ThreadProc()
        {
          
            int interval = 300000; 
            int elapsed = 0;

            int waitTime = 1000; // 1 second
            try
            {
                // do this loop forever (or until the service is stopped)
                while (true)
                {
                    // if enough time has passed
                    if (interval >= elapsed)
                    {
                        // reset how much time has passed to zero
                        elapsed = 0;

                        FileManager.FileManager.MonitorDirectory(sourcefolder, picturesfolder, soundfolder, documentsfolder);

                    }
                    // Sleep for 1 second
                    System.Threading.Thread.Sleep(waitTime);
                    // indicate that 1 additional second has passed
                    elapsed += waitTime;
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
        }

        protected override void OnStart(string[] args)
        {
            m_thread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            m_thread.Start();

            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {

        }

        protected override void OnStop()
        {


        }

        protected override void OnContinue()
        {

        }
    }
}
