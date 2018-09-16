using System;
using System.Windows.Forms;
using PetaPoco;
using ProjetoPDVModel;
using ProjetoPDVDao;


namespace ProjetoPDVUI
{
    public partial class frmProdutoCombo : Form
    {
        private ProdutoCombo _combo;

        public frmProdutoCombo(int comboId = 0)
        {
            InitializeComponent();

            //comboId = 3;

            Inicia_Combo(comboId);
        }

        private void Inicia_Combo(int comboId)
        {
            if (comboId == 0)
            {
                _combo = new ProdutoCombo();
                return;
            }

            _combo = (new ProdutoComboDao()).GetCombo(comboId);

            txtDescricao.Text = _combo.Descricao;

            Atualiza_ListaDeItensDoCombo();
            btnAdicionaItem.Enabled = true;
        }


        private void Atualiza_ListaDeItensDoCombo()
        {
            lstVWItens.Items.Clear();

            _combo.Itens = ((new ProdutoComboItemDao()).GetItensDoCombo(_combo.ComboId));

            var valorTotalDoCombo = 0m;

            for (int i = 0; i <= _combo.Itens.Count - 1; i++)
            {
                _combo.Itens[i].Produtos = (new ProdutoComboItemDao()).GetProdutosDoItem(_combo.Itens[i].ComboItemId);

                var descricaoDosProdutos = "";
                _combo.Itens[i].Produtos.ForEach(delegate (Produto produto) { descricaoDosProdutos += produto.Descricao + ", "; });

                valorTotalDoCombo += _combo.Itens[i].ValorItem;

                var ls = new ListViewItem(_combo.Itens[i].ComboItemId.ToString());
                ls.SubItems.Add(_combo.Itens[i].Descricao);
                ls.SubItems.Add(_combo.Itens[i].ValorItem.ToString("0.00"));
                ls.SubItems.Add(descricaoDosProdutos.Substring(0, descricaoDosProdutos.Trim().Length - 1));

                lstVWItens.Items.Add(ls);
            }

            txtValorDoCombo.Text = valorTotalDoCombo.ToString("0.00");
        }

        private void frmProdutoCombo_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdicionaItem_Click(object sender, EventArgs e)
        {
            var frm = new frmProdutoComboItem(_combo.ComboId);
            frm.ShowDialog();

            Atualiza_ListaDeItensDoCombo();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            var db = new Database("stringConexao");
            var mensagem = "Combo criado com sucesso!";

            try
            {
                db.BeginTransaction();
                
                _combo.Descricao = txtDescricao.Text.Trim();

                if (_combo.ComboId == 0)
                {
                    _combo.DataInicio = DateTime.Now;
                    _combo.ComboId = Convert.ToInt32(db.Insert(_combo));

                    btnAdicionaItem.Enabled = true;
                }
                else
                {
                    _combo.DataAtualizacao = DateTime.Now;
                    db.Update(_combo, new string[] { "Descricao", "data_atualizacao" }); 
                    mensagem = "Combo atualizado com sucesso!";
                }

                db.CompleteTransaction();

                MessageBox.Show(mensagem);
            }
            catch (Exception ex)
            {
                db.AbortTransaction();

                MessageBox.Show(ex.Message);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmProdutoComboItem(_combo.ComboId, _combo.Itens[lstVWItens.FocusedItem.Index]);
            frm.ShowDialog();

            Atualiza_ListaDeItensDoCombo();
        }

        private void lstVWItens_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdicionaItem_Click(sender, e);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProdutoCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            var itemId = Convert.ToInt32(lstVWItens.SelectedItems[0].Text);
            if (itemId == 0)
                return;

            var db = new Database("stringConexao");

            try
            {
                db.BeginTransaction();

                int aff = db.Execute("DELETE FROM produto_combo_item_rel WHERE combo_id=@0 and combo_item_id=@1", _combo.ComboId, itemId);
                if (aff > 0)
                {
                    if (db.Execute("DELETE FROM produto_combo_item WHERE combo_id=@0 and id=@1", _combo.ComboId, itemId) <= 0)
                        throw new Exception();
                }
                else
                    throw new Exception();


                db.CompleteTransaction();

                Atualiza_ListaDeItensDoCombo();
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                MessageBox.Show("Houve um erro inesperado ao excluir o Lançamento, tente novamente!" + Environment.NewLine + ex.Message);
            }
        }

    }
}
