using System;
using System.Windows.Forms;
using ProjetoPDVModel;
using ProjetoPDVDao;
using System.Drawing;
using PetaPoco;

namespace ProjetoPDVUI
{
    public partial class frmAbreCaixa : Form
    {
        private Pedido _pedidoAberturaDeCaixa;
        private DateTime? _dataDoDia = DateTime.Now;
        private int _countPedidosDoDia;

        public frmAbreCaixa(DateTime? data = null)
        {
            InitializeComponent();

            if (data != null)
                _dataDoDia = data;

            pictureBox3.Image = Image.FromFile(Application.StartupPath + @"\Imagens\imprimir.png");
            pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\Imagens\imprimir.png");
            pictureBox2.Image = Image.FromFile(Application.StartupPath + @"\Imagens\imprimir.png");
            btnLancamento.Image = Image.FromFile(Application.StartupPath + @"\Imagens\add.png");
            btnExcluirLancamento.Image = Image.FromFile(Application.StartupPath + @"\Imagens\cancel.png");
        }

        private void CaixaAberto(DateTime dataDaAbertura)
        {
            lblDataHoraAbertura.Text = dataDaAbertura.ToString();
            lblStatusCaixa.BackColor = Color.YellowGreen;
            lblStatusCaixa.Text = "Caixa Aberto";

            lblAbrirCaixa.Enabled = false;
            pictureBox1.Enabled = false;
        }

        private void frmAbreCaixa_Load(object sender, EventArgs e)
        {
            if ((new CaixaDao()).isCaixaFechado(_dataDoDia))
            {
                btnLancamento.Visible = false;
                btnExcluirLancamento.Visible = false;
                pictureBox1.Visible = false;
                lblFecharCaixa.Visible = false;
            }
            
            _pedidoAberturaDeCaixa = (new PedidoDao()).GetPedidoAberturaDeCaixa(_dataDoDia);

            if (_pedidoAberturaDeCaixa != null)
            {
                txtValor.Text = _pedidoAberturaDeCaixa.ValorPedido.ToString("0.00");
                txtObservacao.Text = _pedidoAberturaDeCaixa.Observacao;

                CaixaAberto(_pedidoAberturaDeCaixa.DataDigitacao);

                Lista_Movimentacao();

                lblTicket.Text = (Convert.ToDecimal(lblTotal.Text) / _countPedidosDoDia).ToString("0.00");
            }
        }

        private void Lista_Movimentacao()
        {
            lstvwMovimentacao.Items.Clear();

            var totalAcrescimos = 0m;
            var totalDinheiro = 0m;
            var totalCredito = 0m;
            var totalDebito = 0m;
            var totalOutros = 0m;
            var totalPix = 0m;
            var totalDespesas = 0m;

            var totalIfood = 0m;

            _countPedidosDoDia = 0;

            var pedidosDoDia = (new PedidoDao()).GetPedidos(_dataDoDia, _dataDoDia);


            var pedidoo = 1;

            try
            {
                



                foreach (Pedido pedido in pedidosDoDia)
                {
                    pedidoo = pedido.NumDoc;

                    pedido.Operacao = (new OperacaoDao()).GetOperacaoPorPedido(pedido.NumDoc);
                    pedido.Pagamentos = (new TipoPagamentoDao()).GetPagametosDoPedido(pedido.NumDoc);

                    var ls = new ListViewItem(pedido.NumDoc.ToString());
                    ls.UseItemStyleForSubItems = false;
                    ls.SubItems.Add(pedido.DataDigitacao.ToString());

                    ls.SubItems.Add(pedido.Operacao.AbreCaixa == 1 ? "SALDO INICIAL" : pedido.Operacao.Nome);
                    ls.SubItems.Add(pedido.Operacao.Caixa == 1 ? pedido.ValorPedido.ToString("0.00") : "").ForeColor = Color.MediumBlue;
                    ls.SubItems.Add(pedido.Operacao.Caixa == -1 ? pedido.ValorPedido.ToString("0.00") : "").ForeColor = Color.Red;

                    foreach (TipoPagamento pagamento in pedido.Pagamentos)
                    {
                        ls.SubItems.Add(pedido.Pagamentos.Count == 1 ? pagamento.Descricao : "Dinheiro/Cartão");
                        ls.SubItems.Add(pedido.Operacao.VND.ToString());

                        if (pedido.Operacao.VND == 1)
                        {
                            if (pagamento.CodigoNFCe.Equals(1))
                                totalDinheiro += (pagamento.ValorPago - pedido.Troco);
                            else if ((pagamento.CodigoNFCe.Equals(3)) && (pagamento.Descricao != "iFood"))
                                totalCredito += pagamento.ValorPago;
                            else if (pagamento.CodigoNFCe.Equals(4))
                                totalDebito += pagamento.ValorPago;
                            else if (pagamento.CodigoNFCe.Equals(99))
                                totalOutros += pagamento.ValorPago;
                            else if (pagamento.CodigoNFCe.Equals(17))
                                totalPix += pagamento.ValorPago;
                            else if (pagamento.Descricao.Equals("iFood"))
                                totalIfood += pagamento.ValorPago;

                            _countPedidosDoDia += 1;
                        }

                        if (pedido.Operacao.Caixa == -1)
                            totalDespesas += pagamento.ValorPago;

                        if (pedido.Operacao.OperacaoId == 4)
                            totalAcrescimos += pagamento.ValorPago;
                    }

                    lstvwMovimentacao.Items.Add(ls);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro inesperado ao listar a movimentação, tente novamente ou entre em contato com o administrador do sistena." + Environment.NewLine + "Erro: " + ex.Message + pedidoo.ToString());
            }


            Lista_Saldos(totalDinheiro, totalCredito, totalDebito, totalOutros, totalAcrescimos, totalDespesas, totalIfood, totalPix);
        }

        private void Lista_Saldos(decimal totalDinheiro, decimal totalCredito, decimal totalDebito, decimal totalOutros, decimal totalAcrescimos, decimal totalDespesas, decimal totalIfood, decimal totalPix)
        {
            lblSaldoInicial.Text = txtValor.Text.Trim();

            lblEntrada.Text = totalAcrescimos.ToString("0.00");

            lblDinheiro.Text = totalDinheiro.ToString("0.00");
            lblCartaoDebito.Text = totalDebito.ToString("0.00");
            lblCartaoCredito.Text = totalCredito.ToString("0.00");
            lbliFood.Text = totalIfood.ToString("0.00");
            lblOutros.Text = totalOutros.ToString("0.00");
            lblPix.Text = totalPix.ToString("0.00");

            lblTotal.Text = (totalDinheiro + totalDebito + totalCredito + totalOutros + totalIfood + totalPix).ToString("0.00");
            lblTotalMaisAcrescimos.Text = (totalAcrescimos + totalDinheiro + totalDebito + totalCredito + totalOutros + totalIfood + totalPix).ToString("0.00");

            lblSangria.Text = totalDespesas.ToString("0.00");

            lblSomenteDinheiro.Text = ((Convert.ToDecimal(lblSaldoInicial.Text) + totalAcrescimos + totalDinheiro) - totalDespesas).ToString("0.00");
            lblTudo.Text = ((Convert.ToDecimal(lblSaldoInicial.Text) + totalAcrescimos + totalDinheiro + totalDebito + totalCredito + totalOutros + totalIfood + totalPix) - totalDespesas).ToString("0.00");
        }

        private void btnLancamento_Click(object sender, EventArgs e)
        {
            var frm = new frmSangria();
            frm.ShowDialog();

            if (frm.Pedido != null)
            {
                Lista_Movimentacao();
            }
        }

        private void lblAbrirCaixa_Click(object sender, EventArgs e)
        {
            if (txtValor.Text == "0,00")
            {
                MessageBox.Show("Informe o valor do Lançamento.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var db = new Database("stringConexao");

            try
            {
                db.BeginTransaction();

                var pedido = new Pedido()
                {
                    DataDigitacao = DateTime.Now,
                    ValorPedido = Convert.ToDecimal(txtValor.Text),
                    StatusPedido = "F",
                    UsuarioId = Usuario.getInstance.codUser,
                    Observacao = txtObservacao.Text.Trim(),
                    OperacaoId = 1
                };

                pedido.NumDoc = Convert.ToInt32(db.Insert(pedido));
                db.Insert("Movdb_Pagamento_Rel", new { numdoc = pedido.NumDoc, pagamento_id = 1, valor = Convert.ToDecimal(txtValor.Text), observacao = txtObservacao.Text });

                db.CompleteTransaction();


                CaixaAberto(pedido.DataDigitacao);
                Lista_Movimentacao();
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                MessageBox.Show("Houve um erro inesperado ao fazer a Abertura do Caixa, tente novamente!" + Environment.NewLine + ex.Message);
            }
        }

        private void lstvwMovimentacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvwMovimentacao.SelectedItems.Count == 0)
                btnExcluirLancamento.Enabled = false;
            else
                if (lstvwMovimentacao.SelectedItems[0].SubItems[6].Text == "0" && lstvwMovimentacao.SelectedItems[0].Index != 0)
                    btnExcluirLancamento.Enabled = true;
        }

        private void btnExcluirLancamento_Click(object sender, EventArgs e)
        {
            
            var db = new Database("stringConexao");

            try
            {
                db.BeginTransaction();

                var numDoc = Convert.ToInt32(lstvwMovimentacao.SelectedItems[0].Text);


                int aff = db.Execute("DELETE FROM Movdb_Pagamento_Rel WHERE NumDoc=@0", numDoc);
                if (aff > 0)
                {
                    if (db.Execute("DELETE FROM Movdb WHERE NumDoc=" + numDoc) <= 0)
                        throw new Exception();
                }
                else
                    throw new Exception();


                db.CompleteTransaction();

                Lista_Movimentacao();
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                MessageBox.Show("Houve um erro inesperado ao excluir o Lançamento, tente novamente!" + Environment.NewLine + ex.Message);
            }
        }

        private void frmAbreCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }

        private void lblFecharCaixa_Click(object sender, EventArgs e)
        {
            var frm = new frmFechaCaixa(Convert.ToDecimal(lblSaldoInicial.Text), Convert.ToDecimal(lblTotal.Text), Convert.ToDecimal(lblDinheiro.Text), Convert.ToDecimal(lblCartaoCredito.Text), Convert.ToDecimal(lblCartaoDebito.Text), Convert.ToDecimal(lblOutros.Text), Convert.ToDecimal(lbliFood.Text), Convert.ToDecimal(lblPix.Text), Convert.ToDecimal(lblSangria.Text), Convert.ToDecimal(lblSomenteDinheiro.Text), _countPedidosDoDia);
            frm.ShowDialog();
        }

        private void lblVisualizarPedido_Click(object sender, EventArgs e)
        {
            if (lstvwMovimentacao.FocusedItem == null)
                return;

            var pedido = (new PedidoDao()).GetPedido(Convert.ToInt32(lstvwMovimentacao.FocusedItem.Text));

            var frmVisualizaPedido = new frmVisualizaPedido(pedido);
            frmVisualizaPedido.ShowDialog();
        }

        private void lstvwMovimentacao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lblVisualizarPedido_Click(sender, e);
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
