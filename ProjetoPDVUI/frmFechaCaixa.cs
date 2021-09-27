using PetaPoco;
using ProjetoPDVDao;
using ProjetoPDVModel;
using ProjetoPDVUtil;
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
    public partial class frmFechaCaixa : Form
    {
        private readonly decimal _totalSaldoFinal;
        private readonly int _countPedidosDoDia;


        public frmFechaCaixa(decimal saldoInicial, decimal totalDoDia, decimal totalDinheiro, decimal totalCredito, decimal totalDebito, decimal totalOutros, decimal totalIfood, decimal totalPix, decimal totalSangria, decimal totalSaldoFinal, int countPedidosDoDia)
        {
            InitializeComponent();
            
            txtTotalVendas.Text = totalDoDia.ToString("0.00");
            txtDinheiro.Text = totalDinheiro.ToString("0.00");
            txtDebito.Text = totalDebito.ToString("0.00");
            txtCredito.Text = totalCredito.ToString("0.00");
            txtOutros.Text = totalOutros.ToString("0.00");
            txtIfood.Text = totalIfood.ToString("0.00");
            txtPix.Text = totalPix.ToString("0.00");


            txtSaldoInicial.Text = saldoInicial.ToString("0.00");
            txtVendaDinheiro.Text = totalDinheiro.ToString("0.00");
            txtSangrias.Text = totalSangria.ToString("0.00");

            _totalSaldoFinal = totalSaldoFinal;
            _countPedidosDoDia = countPedidosDoDia;
        }


        private void frmFechaCaixa_Load(object sender, EventArgs e)
        {
            txtTotalVendas.ReadOnly = true;
            txtDinheiro.ReadOnly = true;
            txtCredito.ReadOnly = true;
            txtDebito.ReadOnly = true;
            txtSangrias.ReadOnly = true;
            txtOutros.ReadOnly = true;
            txtIfood.ReadOnly = true;
            txtPix.ReadOnly = true;

            txtSaldoInicial.ReadOnly = true;
            txtVendaDinheiro.ReadOnly = true;
            txtSaldoFinal.ReadOnly = true;
            txtDiferença.ReadOnly = true;

            txtDinheiroCaixa.Select();
        }

        private void lblFecharCaixa_Click(object sender, EventArgs e)
        {
            if (txtDinheiroCaixa.Text.Trim().Length == 0 || txtDinheiroCaixa.Text.Trim() == "0,00")
            {
                MessageBox.Show("Informe o valor final do caixa!");
                txtDinheiroCaixa.Select();
                return;
            }


            Cursor = Cursors.WaitCursor;

            var db = new Database("stringConexao");

            try
            {

                db.BeginTransaction();

                var caixa = new Caixa()
                {
                    Data = DateTime.Now,
                    UsuarioId = Usuario.getInstance.codUser,
                    NomeUsuario = Usuario.getInstance.nomeUser,
                    SaldoInicial = Convert.ToDecimal(txtSaldoInicial.Text),
                    VendaEmDinheiro = Convert.ToDecimal(txtVendaDinheiro.Text),
                    Sangria = Convert.ToDecimal(txtSangrias.Text),
                    SaldoFinalSistema = _totalSaldoFinal,
                    SaldoFinalCaixa = Convert.ToDecimal(txtDinheiroCaixa.Text),
                };


                if (Convert.ToInt32(db.Insert(caixa)) == 0)
                    throw new Exception("Erro ao fechar o caixa, tente novamente por favor.");

                txtSaldoFinal.Text = _totalSaldoFinal.ToString("0.00");
                txtDiferença.Text = (caixa.SaldoFinalCaixa - Convert.ToDecimal(txtSaldoFinal.Text)).ToString("0.00");
                caixa.Diferenca = Convert.ToDecimal(txtDiferença.Text);

                db.CompleteTransaction();

                if (EnviaEmail(caixa))
                    MessageBox.Show("Caixa finalizado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    throw new Exception("O caixa foi finalizado com sucesso, mas houve um erro ao enviar o relatório por E-mail!" + Environment.NewLine + "Informe ao administrador do sistema.");

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool EnviaEmail(Caixa caixa)
        {

            try
            {

                var produtosVendidosDoMes = (new PedidoItemDao()).getlst_Itens_AcumuladodoMes(DateTime.Now);
                for (int i = 0; i <= produtosVendidosDoMes.Count - 1; i++)
                {
                    produtosVendidosDoMes[i].Produto = (new ProdutoDao()).GetProduto(produtosVendidosDoMes[i].ProdutoId);
                }


                //DateTime com o primeiro dia do mês
                var primeiroDiaDoMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

                var pedidosDoMes = (new PedidoDao()).GetPedidosDoCaixa(primeiroDiaDoMes, DateTime.Today); //.ForEach(x => x.Pagamentos = (new TipoPagamentoDao()).GetPagametosDoPedido(x.NumDoc));
                foreach (var pedido in pedidosDoMes)
                {
                    pedido.Operacao = (new OperacaoDao()).GetOperacaoPorPedido(pedido.NumDoc);
                    pedido.Pagamentos = (new TipoPagamentoDao()).GetPagametosDoPedido(pedido.NumDoc);
                }


                (new Email()).Email_ConferenciaCaixa(produtosVendidosDoMes, caixa, Convert.ToDecimal(txtDinheiro.Text), Convert.ToDecimal(txtDebito.Text), Convert.ToDecimal(txtCredito.Text), Convert.ToDecimal(txtOutros.Text), Convert.ToDecimal(txtIfood.Text), Convert.ToDecimal(txtPix.Text), pedidosDoMes, _countPedidosDoDia);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        private void lblVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDinheiroCaixa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FormataTextBox.TextBoxMoeda(ref txtDinheiroCaixa);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Valor digitado incorretamente!");
            }
        }

        private void txtDinheiroCaixa_MouseClick(object sender, MouseEventArgs e)
        {
            txtDinheiroCaixa.SelectionStart = txtDinheiroCaixa.TextLength;
        }
    }
}
