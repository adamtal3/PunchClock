using System;
using System.Windows.Forms;
using PunchClock.Infra;

namespace PunchClock
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
            ScrollLockInterceptor.SetHook();
            Application.Run(new Main());
            ScrollLockInterceptor.UnhookWindowsHookEx();
        }
    }
}
