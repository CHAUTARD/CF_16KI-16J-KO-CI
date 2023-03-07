/*
 * Ecran de démarrage
 * User: CHAUTARD
 * Date: 06/03/2023
 */
using System;
using System.Windows.Forms;

namespace CF_16KI_16J_KO_CI
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormOpen());
        }
    }
}
