using ProjetoPDVDao;
using ProjetoPDVModel;
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
    public partial class frmListaFornecedores : Form
    {
        private List<Fornecedor> _fornecedor;


        public frmListaFornecedores()
        {
            InitializeComponent();
        }

        private void frmListaFornecedores_Load(object sender, EventArgs e)
        {
            ListaFornecedores();
        }


        private void ListaFornecedores()
        {
            try
            {
                lstvwFornecedores.Items.Clear();

                var query = string.Empty;

                if (txtBusca.Text.Trim().Length != 0)
                    query = "descricao LIKE '" + txtBusca.Text.Trim() + "%'";

                _fornecedor = query == string.Empty ? (new FornecedorDao()).GetFornecedores() : (new FornecedorDao()).GetFornecedores(query);

                if (_fornecedor.Count <= 0) return;

                foreach (var fornecedor in _fornecedor)
                {
                    var ls = new ListViewItem(fornecedor.FornecedorId.ToString());
                    ls.SubItems.Add(fornecedor.Descricao);
                    ls.SubItems.Add(fornecedor.TelefonePrincipal);
                    ls.SubItems.Add(fornecedor.Email);

                    lstvwFornecedores.Items.Add(ls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro inesperado ao buscar os Fornecedores no Banco de Dados, tente novamente!" + Environment.NewLine + "Retorno do erro: " + ex.Message);
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            ListaFornecedores();
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            if (lstvwFornecedores.FocusedItem == null)
                return;

            var fornecedorId = Convert.ToInt32(lstvwFornecedores.FocusedItem.Text);

            var frm = new frmFornecedor(fornecedorId);
            frm.ShowDialog();
            ListaFornecedores();
        }

        private void lblNovo_Click(object sender, EventArgs e)
        {
            var frm = new frmFornecedor();
            frm.ShowDialog();
            ListaFornecedores();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblEditar_Click(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            lblNovo_Click(sender, e);
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            lblSair_Click(sender, e);
        }

        private void lstvwFornecedores_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var fornecedorId = Convert.ToInt32(lstvwFornecedores.FocusedItem.Text);

            var frm = new frmFornecedor(fornecedorId);
            frm.ShowDialog();
            ListaFornecedores();
        }
    }
}
