using AIMP.NET.RemoteAPI;
using System;
using System.Windows.Forms;

namespace AimpApi_Remote_test
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
            Application.Run(new MainForm(new AimpRemote()));
        }
    }
}
