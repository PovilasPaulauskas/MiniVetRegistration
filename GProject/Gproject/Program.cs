using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Gproject
{
    static class Program
    {
        private static Mutex mut;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ok;
            mut = new System.Threading.Mutex(true, "StartAppMutex", out ok);

            if(!ok)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formMain());
        }
    }
}
