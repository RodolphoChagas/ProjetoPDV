using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmCancela : Form
    {
        public frmCancela()
        {
            InitializeComponent();

            pictureBox1.Image = Bitmap.FromFile(@"Imagens\lixeira.png");
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {

        }

        private void CmdFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
