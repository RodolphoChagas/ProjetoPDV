using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmCancela : Form
    {
        public frmCancela()
        {
            InitializeComponent();

            pictureBox1.Image = System.Drawing.Bitmap.FromFile(@"Imagens\lixeira.png");
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {

        }

        private void CmdFechar_Click(object sender, EventArgs e)
        {

        }
    }
}
