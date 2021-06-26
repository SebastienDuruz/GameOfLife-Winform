/// Autor : Sébastien Duruz
/// Date : 16.06.2021
/// Description : The entry point of the program

using System;
using System.Windows.Forms;

namespace sebduruz_GameOfLife
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
