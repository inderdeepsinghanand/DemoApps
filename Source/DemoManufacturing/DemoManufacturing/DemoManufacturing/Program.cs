using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BarCodePrinting
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
           // Application.Run(new frmDashboard());
        }

        static void Application_ThreadException
       (object sender, System.Threading.ThreadExceptionEventArgs e)
        {// All exceptions thrown by the main thread are handled over this method

            //ShowExceptionDetails(e.Exception);

            MessageBox.Show("Error Occured :" + e.Exception.Message + ", Please contact administrator"); 
        }

        static void CurrentDomain_UnhandledException
            (object sender, UnhandledExceptionEventArgs e)
        {// All exceptions thrown by additional threads are handled in this method

            //            ShowExceptionDetails(e.ExceptionObject as Exception);
          //  MessageBox.Show("Error Occured :" + e.ExceptionObject.Message + ", Please contact administrator");
            // Suspend the current thread for now to stop the exception from throwing.
            // Thread.CurrentThread.Suspend();
        }

    }
}
