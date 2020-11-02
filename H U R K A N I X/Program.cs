using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace H_U_R_K_A_N_I_X
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameLoading());
        }
    }
}
