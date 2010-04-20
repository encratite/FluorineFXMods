using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;

namespace FluorineFxPolicyServer
{
    static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            if (log.IsInfoEnabled)
            {
                log.Info("*********************************************");
                log.Info("Starting FluorineFx Silverlight Policy Server");
                log.Info("*********************************************");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ErrorBox.Show(e.Exception);
        }
    }
}