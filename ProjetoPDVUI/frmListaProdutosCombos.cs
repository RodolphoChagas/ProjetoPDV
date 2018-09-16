using Dotnetrix.Controls;
using ProjetoPDVDao;
using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmListaProdutosCombos : Form
    {
        private List<Produto> _produtos;
        private ProdutoCategoriaDao _produtoCategDao = new ProdutoCategoriaDao();
        private string _tabNameSelecionada = "Produtos";

        public frmListaProdutosCombos()
        {
            InitializeComponent();
        }

        private void frmListaProdutosCombos_Load(object sender, EventArgs e)
        {
            try
            {
                Inicia_Combobox();
                Lista_Produtos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inicia_Combobox()
        {
            try
            {
                // Combobox Categoria
                var categorias = new List<ProdutoCategoria> { new ProdutoCategoria(0, "Todos") };
                categorias.AddRange((new ProdutoCategoriaDao()).GetCategorias());
                cboCategoria.DataSource = categorias;
                cboCategoria.DisplayMember = "descricao";
                cboCategoria.ValueMember = "categoriaid";

                cboCategoria.SelectedIndex = 0;
                //cboLocalizar.SelectedIndex = 0;
                cboSituacao.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro inesperado ao iniciar os dados da busca." + ex.Message);
            }
        }

        public void Lista_Produtos()
        {
            try
            {
                lstvwProduto.Items.Clear();
                var query = string.Empty;

                if (txtBusca.Text.Trim().Length != 0)
                {
                    query = "descricao LIKE '" + txtBusca.Text.Trim() + "%'";
                }

                if (cboCategoria.SelectedIndex != 0)
                {
                    if (query == string.Empty)
                        query = "categoria_id = " + cboCategoria.SelectedValue;
                    else
                        query += " And categoria_id = " + cboCategoria.SelectedValue;
                }

                if (cboSituacao.Text != "Todos")
                {
                    if (query == string.Empty)
                        query = "status = " + (cboSituacao.SelectedIndex - 1);
                    else
                        query += " And status = " + (cboSituacao.SelectedIndex - 1);
                }


                _produtos = query == string.Empty ? (new ProdutoDao()).GetProdutos() : (new ProdutoDao()).GetProdutos(query);


                if (_produtos.Count <= 0) return;

                foreach (var p in _produtos)
                {
                    p.Categoria = _produtoCategDao.GetCategoriaPorProduto(p.ProdutoId);

                    var ls = new ListViewItem(p.ProdutoId.ToString());
                    ls.SubItems.Add(p.Descricao);
                    ls.SubItems.Add(p.Categoria.Descricao);
                    ls.SubItems.Add("10");
                    ls.SubItems.Add(p.Status.Equals(0) ? "Disponível": "Indisponível");
                    ls.SubItems.Add(p.PrecoDeVenda.ToString("0.00"));

                    lstvwProduto.Items.Add(ls);
                }

                //lblCount.Text = lstvwProduto.Items.Count + " itens encontrados";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro inesperado ao buscar os Produtos no Banco de Dados, tente novamente!" + Environment.NewLine + "Retorno do erro: " + ex.Message);
            }
        }

        public void Lista_Combos()
        {
            try
            {
                lstvwCombo.Items.Clear();
                var query = string.Empty;

                if (txtBusca.Text.Trim().Length != 0)
                {
                    query = "Produto_Combo.descricao LIKE '" + txtBusca.Text.Trim() + "%'";
                }


                var _combos = query == string.Empty ? (new ProdutoComboDao()).GetCombos() : (new ProdutoComboDao()).GetCombos(query);


                if (_combos.Count <= 0) return;

                foreach (var c in _combos)
                {

                    var ls = new ListViewItem(c.ComboId.ToString());
                    ls.SubItems.Add(c.DataInicio.ToString());
                    ls.SubItems.Add(c.Descricao);
                    ls.SubItems.Add(c.ValorCombo.ToString("0.00"));

                    lstvwCombo.Items.Add(ls);
                }

                //lblCount.Text = lstvwProduto.Items.Count + " itens encontrados";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro inesperado ao buscar os Produtos no Banco de Dados, tente novamente!" + Environment.NewLine + "Retorno do erro: " + ex.Message);
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (_tabNameSelecionada == "Produtos")
                Lista_Produtos();
            else
                Lista_Combos();
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            if (_tabNameSelecionada == "Produtos")
            {
                if (lstvwProduto.FocusedItem == null)
                    return;

                var produtoId = Convert.ToInt32(lstvwProduto.FocusedItem.Text);

                var frm = new frmProduto(produtoId);
                frm.ShowDialog();
                Lista_Produtos();
            }
            else
            {
                if (lstvwCombo.FocusedItem == null)
                    return;

                var comboId = Convert.ToInt32(lstvwCombo.FocusedItem.Text);

                var frm = new frmProdutoCombo(comboId);
                frm.ShowDialog();
                Lista_Combos();
            }
        }

        private void lstvwProduto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var produtoId = Convert.ToInt32(lstvwProduto.FocusedItem.Text);

            var frm = new frmProduto(produtoId);
            frm.ShowDialog();
            Lista_Produtos();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblEditar_Click(sender, e);
        }

        private void lblNovo_Click(object sender, EventArgs e)
        {
            if (_tabNameSelecionada == "Produtos")
            {
                var frm = new frmProduto();
                frm.ShowDialog();
                Lista_Produtos();
            }
            else
            {
                var frm = new frmProdutoCombo();
                frm.ShowDialog();
                Lista_Combos();
            }
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

        private void tabControlEX1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = (TabControlEX)sender;

            _tabNameSelecionada = tab.SelectedTab.Name;

            if (_tabNameSelecionada == "Produtos")
                Lista_Produtos();
            else if (_tabNameSelecionada == "Combos")
                Lista_Combos();
        }

        private void lstvwCombo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var comboId = Convert.ToInt32(lstvwCombo.FocusedItem.Text);

            var frm = new frmProdutoCombo(comboId);
            frm.ShowDialog();
            Lista_Combos();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lista_Produtos();
        }

        private void cboSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lista_Produtos();
        }
    }
}
