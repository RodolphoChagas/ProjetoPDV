using System;
using System.Windows.Forms;
using ProjetoPDVModel;
using ProjetoPDVUtil;

namespace ProjetoPDVUI
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

            var frm = new frmLogin();
            frm.ShowDialog();
            if (frm.LogonSuccessful)
                Application.Run(new frmMenuPrincipal());
        }
    }
}
