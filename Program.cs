using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Count() > 0)
            {
                switch (args[0].ToLower())
                {
                    case "/s":
                        Application.Run(new ScreenSaver());
                        break;
                }
            }
        }
    }
}
