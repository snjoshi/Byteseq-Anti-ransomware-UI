using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetluxUI
{
    static class Program
    {
        public static int x = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // if(x!=0)
                Application.Run(new NXAntivirus());
          //  else
          //      Application.Run(new Activation());
            // Application.Run(new Protection());
        }
    }
}
