using ProjetoPDVDao;
using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmItensDoCombo : Form
    {
        private readonly int _comboId;
        public List<Produto> ProdutosSelecionados = new List<Produto>();


        public frmItensDoCombo(int comboId)
        {
            _comboId = comboId;

            InitializeComponent();
        }

        private void Inicia_ListaDeProdutos(int categoriaId = 0)
        {
            lstVWProdutos.Items.Clear();

            try
            {
                var itensDoCombo = new List<ProdutoComboItem>();

                itensDoCombo.AddRange((new ProdutoComboItemDao()).GetItensDoCombo(_comboId));

                foreach (ProdutoComboItem item in itensDoCombo)
                {
                    var lsGroup = new ListViewGroup(item.Descricao + " (Escolha uma opção)");
                    lsGroup.Tag = item.ComboItemId;
                    lstVWProdutos.Groups.Add(lsGroup);

                    var produtos = (new ProdutoComboItemDao()).GetProdutosDoItem(item.ComboItemId);
                    foreach (Produto produto in produtos)
                    {
                        var ls = new ListViewItem(produto.ProdutoId.ToString(), lsGroup);
                        ls.SubItems.Add(produto.Descricao);
                        ls.SubItems.Add(produto.PrecoDeVenda.ToString("0.00"));
                        ls.ForeColor = Color.DarkBlue;

                        lstVWProdutos.Items.Add(ls);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao iniciar a lista de Produtos, tente novamente por favor.");
            }
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            Inicia_ListaDeProdutos();
        }



        private void lstVWProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVWProdutos.FocusedItem == null)
                return;

            var item = lstVWProdutos.FocusedItem;

            if (item.Checked == true)
                item.Checked = false;
            else
                item.Checked = true;
        }

        private void lstVWProdutos_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void lstVWProdutos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                foreach (ListViewItem itemview in e.Item.Group.Items)
                {
                    if (e.Item == itemview)
                        itemview.Checked = true;
                    else
                        itemview.Checked = false;
                }
            }
        }

        private void frmItensDoCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }

        private void lblSelecionar_Click(object sender, EventArgs e)
        {
            if (lstVWProdutos.CheckedItems.Count == 0)
            {
                MessageBox.Show("Itens do combo não selecionados");
                return;
            }

            try
            {
                foreach (ListViewItem listItem in lstVWProdutos.CheckedItems)
                {
                    var produto = (new ProdutoComboItemDao()).GetProdutoDoItem(_comboId, Convert.ToInt32(listItem.Group.Tag), Convert.ToInt32(listItem.Text));

                    ProdutosSelecionados.Add(produto);
                }

                Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
