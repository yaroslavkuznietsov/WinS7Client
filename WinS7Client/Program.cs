using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinS7Library.DataAccess;

namespace WinS7Client
{
    static class Program
    {

        //static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        //[STAThread]
        //static void Main()
        //{
        //    if (mutex.WaitOne(TimeSpan.Zero, true))
        //    {
        //        Application.EnableVisualStyles();
        //        Application.SetCompatibleTextRenderingDefault(false);
        //        Application.Run(new Form1());
        //        mutex.ReleaseMutex();
        //    }
        //    else
        //    {
        //        MessageBox.Show("only one instance at a time");
        //    }
        //}


        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                GlobalConfig.InitializeConnections(DatabaseType.Sql);

                //Application.Run(new Form1());
                Application.Run(new MainForm()); 
            }
            //else
            //{
            //    MessageBox.Show("only one instance at a time");
            //}
        }
    }
}
