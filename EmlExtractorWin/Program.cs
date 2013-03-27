using System;
using System.Collections.Generic;

using System.Windows.Forms;
using log4net;
namespace EmlExtractorWin
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogConfig();
            Application.Run(new Main());
        }
         static void LogConfig()
        {
            System.IO.FileInfo finfo = new System.IO.FileInfo(Environment.CurrentDirectory + "\\config\\log4net.config");
            log4net.Config.XmlConfigurator.Configure(finfo);
        }
    }
}
