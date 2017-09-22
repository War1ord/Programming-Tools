using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sql_to_CS_Class_Generator
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
            Application.Run(new frnClassGenerator());
        }
    }
}
