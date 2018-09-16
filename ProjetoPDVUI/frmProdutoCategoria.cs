using PetaPoco;
using ProjetoPDVDao;
using ProjetoPDVModel;
using System;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmProdutoCategoria : Form
    {
        public frmProdutoCategoria()
        {
            InitializeComponent();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescCategoria.Text.Trim()))
            {
                MessageBox.Show("Digite a descrição da Categoria por favor!", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var produtoCateg = new ProdutoCategoria();
            var db = new Database("stringConexao");

            try
            {

                db.BeginTransaction();

                produtoCateg.CategoriaId = Convert.ToInt32(txtCodCategoria.Text);
                produtoCateg.Descricao = txtDescCategoria.Text.Trim();

                string msg;


                if (txtCodCategoria.Text == "0")
                {
                    var retCateg = db.Insert(produtoCateg);

                    txtCodCategoria.Text = retCateg.ToString();
                    msg = "Categoria inserida com sucesso!";
                }
                else
                {
                    if (db.Update(produtoCateg) == 0)
                        throw new Exception("Não foi possível atualizar a Categoria selecionada.");
                    msg = "Categoria atualizada com sucesso!";
                }

                db.CompleteTransaction();

                MessageBox.Show(msg, "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Inicia_ListaCategoria();
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                MessageBox.Show("Houve um erro inesperado ao salvar a categoria, tente novamente." + Environment.NewLine + "Mensagem do erro: " + ex.Message, "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db?.Dispose();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCodCategoria.Text = "0";
            txtDescCategoria.Text = string.Empty;

            txtDescCategoria.Focus();
        }

        private void frmProdutoCategoria_Load(object sender, EventArgs e)
        {
            Inicia_ListaCategoria();
        }

        private void Inicia_ListaCategoria()
        {
            lstvwCategoria.Items.Clear();

            var produtoCategoriaDao = new ProdutoCategoriaDao();
            var lstCategoria = produtoCategoriaDao.GetCategorias();

            foreach (var categ in lstCategoria)
            {
                var ls = new ListViewItem(categ.CategoriaId.ToString());
                var quantidadeDeItens = produtoCategoriaDao.GetQuantidadeDeItensPorCategoria(categ.CategoriaId);

                ls.SubItems.Add(categ.Descricao);
                ls.SubItems.Add(quantidadeDeItens.ToString("00"));
                ls.SubItems.Add(categ.Status == 0 ? "Ativo": "Desativado");

                lstvwCategoria.Items.Add(ls);
            }
        }

        private void lstvwCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvwCategoria.FocusedItem == null)
                return;

            var item = lstvwCategoria.FocusedItem;

            txtCodCategoria.Text = item.Text;
            txtDescCategoria.Text = item.SubItems[1].Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
