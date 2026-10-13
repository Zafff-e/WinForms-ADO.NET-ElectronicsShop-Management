using System;
using System.Windows.Forms;

namespace ElectronicsShop
{
    /// <summary>
    /// Application entry point.
    /// STAThread is required for WinForms — COM/UI threading model.
    /// </summary>
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.ThreadException += (s, e) => {
                System.IO.File.WriteAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "thread_crash.txt"), e.Exception.ToString());
                MessageBox.Show(e.Exception.ToString(), "CRASH!");
            };
            AppDomain.CurrentDomain.UnhandledException += (s, e) => {
                System.IO.File.WriteAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "domain_crash.txt"), e.ExceptionObject.ToString());
                MessageBox.Show(e.ExceptionObject.ToString(), "CRASH!");
            };
            try 
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
            } 
            catch (Exception ex) 
            {
                System.IO.File.WriteAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crash_log.txt"), ex.ToString());
                MessageBox.Show(ex.ToString(), "CRASH!");
            }
        }
    }
}
