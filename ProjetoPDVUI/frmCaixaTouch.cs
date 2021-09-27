using ProjetoPDVDao;
using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace ProjetoPDVUI
{
    public partial class frmCaixaTouch : Form
    {
        private Pedido _pedido;
        
        public frmCaixaTouch()
        {
            InitializeComponent();

            btnDeleteItem.Image = Image.FromFile(Application.StartupPath + @"\Imagens\cross.png");
        }

        private void frmCaixaTouch_Load(object sender, EventArgs e)
        {
            IniciaNovaVenda();

            var vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            tableProdutos.Padding = new Padding(0, 0, vertScrollWidth, 0);
            tableCategoria.Padding = new Padding(0, 0, vertScrollWidth, 0);

            var categorias = new List<ProdutoCategoria>();
            categorias.AddRange((new ProdutoCategoriaDao()).GetCategorias());
            categorias.Add(new ProdutoCategoria() { CategoriaId = 0, Descricao = "COMBOS" });
            GenerateTableLayout(tableCategoria, categorias);

            var produtosSalgados = (new ProdutoDao()).GetProdutosPorCategoria(17);
            GenerateTableLayout(tableProdutos, produtosSalgados);
        }

        private void GenerateTableLayout<T>(TableLayoutPanel tableLayout, IEnumerable<T> lst)
        {
            //Clear out the existing controls, we are generating a new table layout
            tableLayout.Controls.Clear();

            //Clear out the existing row and column styles
            tableLayout.ColumnStyles.Clear();
            tableLayout.RowStyles.Clear();

            const int columnCount = 5;

            //Now we will generate the table, setting up the row and column counts first
            tableLayout.ColumnCount = columnCount;
            tableLayout.RowCount = 0;

            for (var x = 0; x < columnCount; x++)
            {
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            }

            foreach (object obj in lst)
            {
                //Create the control, in this case we will add a button
                var cmd = new Button
                {
                    //Size = new Size(138, 102),
                    Size = new Size(138, 87),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font(Font.FontFamily, 10),
                    Cursor = Cursors.Hand,
                    Margin = new Padding(3, 3, 15, 8)

                };
                //cmd.Font = new Font(cmd.Font, FontStyle.Bold);

                switch (obj)
                {
                    case ProdutoCategoria categoria:
                        //cmd.Size = new Size(138, 77);
                        cmd.Size = new Size(138, 60);

                        cmd.Tag = categoria.CategoriaId;
                        cmd.Text = categoria.Descricao;
                        cmd.Font = new Font(cmd.Font, FontStyle.Bold);
                        //cmd.BackColor = Color.FromArgb(229, 159, 2);
                        cmd.MouseDown += ControlsTableCategoria_MouseDown;
                        break;
                    case Produto produto:
                        cmd.Tag = produto.ProdutoId;
                        cmd.Text = produto.Descricao + Environment.NewLine + produto.PrecoDeVenda.ToString("0.00");
                        cmd.MouseDown += ControlsTableProduto_MouseDown;
                        break;
                    case ProdutoCombo combo:
                        cmd.Tag = combo.ComboId;
                        cmd.Text = combo.Descricao + Environment.NewLine + combo.ValorCombo.ToString("0.00");
                        cmd.MouseDown += ControlsTableCombos_MouseDown;
                        break;
                }

                tableLayout.Controls.Add(cmd);
            }
        }

        private void InsereProdutoNaListView(Produto produto, int comboId = 0)
        {
            try
            {
                var ls = new ListViewItem(produto.ProdutoId.ToString());

                ls.SubItems.Add(produto.Descricao);
                ls.SubItems.Add("1"); // Quantidade
                ls.SubItems.Add(produto.PrecoDeVenda.ToString("0.00"));
                ls.SubItems.Add(produto.PrecoDeVenda.ToString("0.00"));
                ls.SubItems.Add(comboId.ToString());
                lstVWItens.Items.Add(ls);

                ls.Selected = true;
                lstVWItens.EnsureVisible(lstVWItens.Items.Count - 1);

                AtualizaValorTotalEQuantidadeDeItens(Convert.ToDecimal(ls.SubItems[3].Text), 1);
            }
            catch (Exception)
            {
                Console.WriteLine(@"Erro ao inserir o produto, tente novamente!");
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lstVWItens.SelectedItems.Count <= 0)
            {
                IniciaNovaVenda();
                return;
            }

            AtualizaValorTotalEQuantidadeDeItens(Convert.ToDecimal(lstVWItens.SelectedItems[0].SubItems[4].Text) * -1, Convert.ToInt32(lstVWItens.SelectedItems[0].SubItems[2].Text) * -1);

            lstVWItens.Items.Remove(lstVWItens.SelectedItems[0]);
        }

       
        private void btnSomaItem_Click(object sender, EventArgs e)
        {
            if (lstVWItens.SelectedItems.Count > 0)
            {
                var valorProduto = Convert.ToDecimal(lstVWItens.SelectedItems[0].SubItems[3].Text);
                AtualizaProdutoNaLista(valorProduto, 1);
            }
        }
        private void btnSubtraiItem_Click(object sender, EventArgs e)
        {
            if (lstVWItens.SelectedItems.Count > 0)
            {
                var valorProduto = Convert.ToDecimal(lstVWItens.SelectedItems[0].SubItems[3].Text);
                AtualizaProdutoNaLista(valorProduto * -1, -1);
            }
        }

        private void ControlsTableCombos_MouseDown(object sender, MouseEventArgs e)
        {
            var comboId = Convert.ToInt32(((Button)sender).Tag);

            var frmItens = new frmItensDoCombo(comboId);
            frmItens.StartPosition = FormStartPosition.CenterScreen;
            //frmItens.Left = 900;
            //frmItens.Top = 100;
            frmItens.ShowDialog();

            if(frmItens.ProdutosSelecionados.Count > 0)
            {
                foreach (Produto produto in frmItens.ProdutosSelecionados)
                {
                    if (lstVWItens.Items.Count > 0)
                    {
                        var item = lstVWItens.FindItemWithText(produto.ProdutoId.ToString(), false, 0, true);

                        //Se o item já existir na lista
                        if (item != null)
                        {
                            //Item ficará em evidência na lista
                            item.Selected = true;
                            lstVWItens.EnsureVisible(item.Index);

                            //Atualiza a quantidade e o valor do item
                            AtualizaProdutoNaLista(produto.PrecoDeVenda, 1);
                            continue;
                        }
                    }

                    InsereProdutoNaListView(produto, comboId);
                }

            }
        }

        private void ControlsTableCategoria_MouseDown(object sender, MouseEventArgs e)
        {
            var categoriaId = Convert.ToInt32(((Button)sender).Tag);

            foreach (Control control in panelCategorias.Controls)
            {
                if (control is TableLayoutPanel tb)
                {
                    foreach (Button btn in tb.Controls)
                    {
                        if (Convert.ToInt32(btn.Tag) == categoriaId)
                            btn.BackColor = Color.LightGray;
                        else
                            btn.BackColor = Color.Transparent;
                    }
                }
            }


            if (categoriaId == 0)
            {
                var combos = (new ProdutoComboDao()).GetCombos();
                GenerateTableLayout(tableProdutos, combos);
                return;
            }

            var produtosPorCategoria = (new ProdutoDao()).GetProdutosPorCategoria(categoriaId);
            GenerateTableLayout(tableProdutos, produtosPorCategoria);
            txtBuscaProduto.Focus();
        }

        private void ControlsTableProduto_MouseDown(object sender, MouseEventArgs e)
        {
            var codProduto = ((Button)sender).Tag;

            try
            {
                var produto = (new ProdutoDao()).GetProduto(Convert.ToInt32(codProduto)) ?? throw new ArgumentNullException("Produto não encontrado no Banco de Dados, verifique por favor.");

                if (lstVWItens.Items.Count > 0)
                {
                    //var item = lstVWItens.FindItemWithText(produto.ProdutoId.ToString(), false, 0, true);
                    var item = lstVWItens.FindItemWithText(produto.ProdutoId.ToString(), false, 0, false);

                    //Se o item já existir na lista
                    if (item != null)
                    {
                        //Item ficará em evidência na lista
                        item.Selected = true;
                        lstVWItens.EnsureVisible(item.Index);

                        //Atualiza a quantidade e o valor do item
                        AtualizaProdutoNaLista(produto.PrecoDeVenda, 1);
                        txtBuscaProduto.Focus();
                        return;
                    }
                }
                                
                InsereProdutoNaListView(produto);
                txtBuscaProduto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// TRUE para somar e FALSE para subtrair
        /// </summary>
        private void AtualizaValorTotalEQuantidadeDeItens(decimal valor, int quantidadeItem)
        {
            try
            {
                var valorTotal = Convert.ToDecimal(lblTotalVenda.Text);
                var quantidadeTotal = Convert.ToInt32(lblTotalItens.Text);

                //if (isSomar)
                //{
                //    valorTotal += valor;
                //    quantidadeTotal += quantidadeItem;
                //}
                //else
                //{
                //    valorTotal -= valor;
                //    quantidadeTotal -= quantidadeItem;
                //}

                valorTotal = valorTotal + (valor);
                quantidadeTotal = quantidadeTotal + (quantidadeItem);

                lblTotalVenda.Text = valorTotal.ToString("0.00");
                lblTotalItens.Text = quantidadeTotal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Erro ao atualizar o valor total da Venda!" + Environment.NewLine + ex.Message);
            }
        }

        

        private void frmCaixaTouch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape || e.KeyData == Keys.F8)
            {
                Close();
            }
            else if(e.KeyData == Keys.F5)
            {
                FinalizaVenda();
            }
        }

        /// <summary>
        /// TRUE para somar e FALSE para subtrair
        /// </summary>
        private void AtualizaProdutoNaLista(decimal valorProduto, int quantidade)
        {
            try
            {
                if (lstVWItens.SelectedItems.Count <= 0)
                    return;

                if (quantidade < 0)
                    if ((lstVWItens.SelectedItems[0].SubItems[2].Text == "1")) //Quantidade
                        return;


                //var valorDoProduto = Convert.ToDecimal(lstVWItens.SelectedItems[0].SubItems[3].Text);
                var valorTotalAnterior = Convert.ToDecimal(lstVWItens.SelectedItems[0].SubItems[4].Text);
                var quantidadeAnterior = Convert.ToInt32(lstVWItens.SelectedItems[0].SubItems[2].Text);

                var valorTotalFinal = (valorTotalAnterior + (valorProduto));
                var quantidadeFinal = quantidadeAnterior + (quantidade);

                //Quantidade final
                lstVWItens.SelectedItems[0].SubItems[2].Text = quantidadeFinal.ToString();
                //Valor Total final
                lstVWItens.SelectedItems[0].SubItems[4].Text = (valorTotalFinal).ToString("0.00");

                AtualizaValorTotalEQuantidadeDeItens(valorProduto, 1 * quantidade);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Houve um erro inesperado, tente novamente", @"Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rectangleShape3_Click(object sender, EventArgs e)
        {
            FinalizaVenda();
        }

        private void FinalizaVenda()
        {
            if (lstVWItens.Items.Count <= 0)
            {
                MessageBox.Show(@"Selecione pelo menos um Produto para finalizar a Venda!", @"Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {

                //Itens do Pedido
                _pedido.ItensDoPedido = new List<PedidoItem>();

                var subTotal = 0m;
                foreach (ListViewItem listViewItem in lstVWItens.Items)
                {
                    var produtoId = Convert.ToInt32(listViewItem.Text);
                    var produto = (new ProdutoDao()).GetProduto(produtoId);
                    produto.GrupoFiscal = (new ProdutoGrupoFiscalDao()).GetGrupoFiscalPorProduto(produtoId);

                    var quantidade = Convert.ToInt32(listViewItem.SubItems[2].Text);
                    var valorDesconto = 0;
                    var valorProduto = Convert.ToDecimal(listViewItem.SubItems[3].Text);
                    var valorTotalProduto = Convert.ToDecimal(listViewItem.SubItems[4].Text);
                    var comboId = Convert.ToInt32(listViewItem.SubItems[5].Text);

                    subTotal += (valorProduto * quantidade);

                    _pedido.ItensDoPedido.Add(new PedidoItem(_pedido, produtoId, produto, quantidade, valorDesconto, valorProduto, valorTotalProduto, comboId));
                }
                
                //Valor Total do Pedido
                _pedido.ValorPedido = Convert.ToDecimal(lblTotalVenda.Text);
                _pedido.SubTotal = subTotal;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Erro ao finalizar a Venda, verifique os valores e tente novamente!", @"Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var frmPagamento = new frmSelecionaPagamento1(_pedido, this);
            frmPagamento.ShowDialog();
        }

        public void IniciaNovaVenda()
        {
            _pedido = new Pedido
            {
                NumDoc = 0,
                StatusPedido = "A",
                UsuarioId = Usuario.getInstance.codUser,
                Operacao = new Operacao(),
                ModeloNFiscal = "65",
                SerieNFiscal = 1,
                ValorPedido = 0,
                ValorDesconto = 0,
                NFiscal = 0
            };
            
            lblTotalVenda.Text = @"0,00";
            lblTotalItens.Text = @"0";
            lstVWItens.Items.Clear();

            txtBuscaProduto.Focus();
        }


        private void VerificaCaixaAberto()
        {
            var pedidoAberturaDeCaixa = (new PedidoDao()).GetPedidoAberturaDeCaixa(DateTime.Now);
            if (pedidoAberturaDeCaixa == null)
            {
                var resultDialog = MessageBox.Show("Antes de anotar o pagamento, é preciso ABRIR seu caixa. Isso o ajudará a conferir os valores da sua gaveta após o fechamento." + Environment.NewLine + Environment.NewLine + "Deseja abrir seu caixa agora?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (resultDialog == DialogResult.Yes)
                {
                    var frmAbreCaixa = new frmAbreCaixa();
                    frmAbreCaixa.ShowDialog();
                }
                else
                    return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            VerificaCaixaAberto();

            FinalizaVenda();
        }

        private void lstVWItens_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VerificaCaixaAberto();

            FinalizaVenda();
        }

        private void rectangleShape4_Click(object sender, EventArgs e)
        {
            CancelaVenda();
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            CancelaVenda();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CancelaVenda();
        }

        private void CancelaVenda()
        {
            Close();
        }

        private void txtBuscaProduto_TextChanged(object sender, EventArgs e)
        {
            List<Produto> produtos;

            if (txtBuscaProduto.Text.Trim().Length > 0)
                produtos = (new ProdutoDao()).GetProdutos("descricao LIKE '%" + txtBuscaProduto.Text.Trim() + "%' COLLATE LATIN1_GENERAL_CI_AI");
            else
                produtos = (new ProdutoDao()).GetProdutosPorCategoria(17);

            GenerateTableLayout(tableProdutos, produtos);
        }

        private void txtBuscaProduto_Enter(object sender, EventArgs e)
        {
            if (txtBuscaProduto.Text.Trim().Length > 0)
                txtBuscaProduto.Text = "";
        }
    }
}
