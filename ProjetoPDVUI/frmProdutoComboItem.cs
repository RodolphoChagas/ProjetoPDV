using ProjetoPDVDao;
using ProjetoPDVModel;
using ProjetoPDVUtil;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PetaPoco;

namespace ProjetoPDVUI
{
    public partial class frmProdutoComboItem : Form
    {

        private ProdutoComboItem _comboItem;
        private int _comboId;


        public frmProdutoComboItem(int comboId, ProdutoComboItem comboItem = null)
        {
            InitializeComponent();

            _comboId = comboId;

            if (comboItem != null)
            {
                _comboItem = comboItem;

                txtDescricao.Text = _comboItem.Descricao;
                txtValor.Text = _comboItem.ValorItem.ToString("0.00");
            }
        }

        private void frmProdutoComboItem_Load(object sender, EventArgs e)
        {
            // Combobox Categoria
            var categorias = new List<ProdutoCategoria> { new ProdutoCategoria(0, "TODOS") };
            categorias.AddRange((new ProdutoCategoriaDao()).GetCategorias());
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "descricao".ToUpper();
            cboCategoria.ValueMember = "categoriaid";

            Inicia_ListaDeProdutos();
        }

        private void Inicia_ListaDeProdutos(int categoriaId = 0)
        {
            lstVWProdutos.Items.Clear();

            try
            {
                var categorias = new List<ProdutoCategoria>();

                if (categoriaId != 0)
                    categorias.Add((new ProdutoCategoriaDao()).GetCategoria(categoriaId));
                else
                    categorias.AddRange((new ProdutoCategoriaDao()).GetCategorias());

                foreach (ProdutoCategoria categoria in categorias)
                {
                    var lsGroup = new ListViewGroup(categoria.Descricao);
                    lstVWProdutos.Groups.Add(lsGroup);

                    var produtos = (new ProdutoDao()).GetProdutosPorCategoria(categoria.CategoriaId);
                    foreach (Produto produto in produtos)
                    {
                        var ls = new ListViewItem(produto.ProdutoId.ToString(), lsGroup);
                        ls.SubItems.Add(produto.Descricao);
                        ls.SubItems.Add(produto.PrecoDeVenda.ToString("0.00"));

                        if(_comboItem != null)
                        if (_comboItem.Produtos.Find(x => x.ProdutoId == produto.ProdutoId) != null)
                            ls.Checked = true;

                        lstVWProdutos.Items.Add(ls);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao iniciar a lista de Produtos, tente novamente por favor.");
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text.Trim()))
            {
                MessageBox.Show("Digite a descrição do Item por favor.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtValor.Text == "0,00")
            {
                MessageBox.Show("Valor incorreto.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lstVWProdutos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Selecione ao menos um Produto para esse Item.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_comboItem == null)
            {
                _comboItem = new ProdutoComboItem();
                _comboItem.ComboId = _comboId;
            }

            _comboItem.Descricao = txtDescricao.Text.Trim();
            _comboItem.ValorItem = Convert.ToDecimal(txtValor.Text);

            using (var db = new Database("stringConexao"))
            {

                try
                {
                    db.BeginTransaction();

                    if (_comboItem.ComboItemId == 0)
                        _comboItem.ComboItemId = Convert.ToInt32(db.Insert(_comboItem));
                    else
                    {
                        db.Update(_comboItem, new string[] { "descricao", "valor" });
                        (new ProdutoComboItemDao()).DeletaTodosOsProdutosDoItem(_comboItem.ComboId, _comboItem.ComboItemId);
                    }

                    foreach (ListViewItem item in lstVWProdutos.CheckedItems)
                    {
                        var produtoComboItem_Rel = new ProdutoComboItemRel(_comboItem.ComboId, _comboItem.ComboItemId, int.Parse(item.Text));
                        db.Insert(produtoComboItem_Rel);
                    }

                    db.CompleteTransaction();

                    Close();
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    MessageBox.Show("Erro aos relacionar os Produtos a esse Item, tente novamente.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoria.Focused)
            {
                if (cboCategoria.Text == "TODOS")
                    Inicia_ListaDeProdutos();
                else
                    Inicia_ListaDeProdutos(Convert.ToInt32(cboCategoria.SelectedValue));

                lstVWProdutos.Focus();
            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FormataTextBox.TextBoxMoeda(ref txtValor);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Valor digitado incorretamente!");
            }
        }

        private void txtValor_MouseClick(object sender, MouseEventArgs e)
        {
            txtValor.SelectionStart = txtValor.TextLength;
        }
    }
}
