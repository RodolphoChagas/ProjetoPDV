using ProjetoPDVDao;
using ProjetoPDVModel;
using ProjetoPDVUtil;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmInformaPagamento : Form
    {
        private readonly string _tipoDePagamento;
        private readonly decimal _valorDoPedido;

        private int _pagamentoId;
        private TextBox _textBoxSelecionado;

        public TipoPagamento Pagamento;
        

        public frmInformaPagamento(string tipoDePagamento, decimal valorFaltando)
        {
            InitializeComponent();

            radVisa.Image = Bitmap.FromFile(@"Imagens\visa50.png");
            radMastercard.Image = Bitmap.FromFile(@"Imagens\mastercard50.png");
            radOutros.Image = Bitmap.FromFile(@"Imagens\Outros.png");
            radIfood.Image = Bitmap.FromFile(@"Imagens\ifood-logo-16.png");


            _valorDoPedido = valorFaltando;
            _tipoDePagamento = tipoDePagamento;


            //Painel do Teclado
            foreach (Control control in pnlTeclado.Controls)
            {
                if (control is Button button)
                    button.MouseDown += ControlsPanelTeclado_MouseDown;
            }
            //Painel Seleciona Bandeiras
            foreach (Control control in pnlBandeiras.Controls)
            {
                if (control is RadioButton radioButton)
                    radioButton.MouseDown += ControlsPanelSelecionaBandeira_MouseDown;
            }
            //Painel de Cedulas
            foreach (Control control in pnlCedulas.Controls)
            {
                if (control is Button btn)
                    btn.MouseDown += ControlsPanelCedulas_MouseDown;
            }

            txtValor.Enter += TextBox_Enter;
            txtNumAutorizacao.Enter += TextBox_Enter;
        }


        private void frmInformaPagamento_Load(object sender, EventArgs e)
        {
            btnValorFaltando.Text = _valorDoPedido.ToString("0.00") + " (Faltando)";

            switch (_tipoDePagamento)
            {
                case "DINHEIRO":
                    pnlBandeiras.Enabled = false;
                    break;
                case "CREDITO":
                    radIfood.Tag = 16;
                    radMastercard.Tag = 7;
                    radVisa.Tag = 2;
                    radOutros.Tag = 17;
                    radPix.Tag = 19;
                    break;
                case "DEBITO":
                    radIfood.Tag = 16;
                    radMastercard.Tag = 10;
                    radVisa.Tag = 11;
                    radOutros.Tag = 17;
                    radPix.Tag = 19;
                    break;
            }

            if (!_tipoDePagamento.Equals("DINHEIRO"))
                txtValor.Text = _valorDoPedido.ToString("0.00");

            txtValor.SelectAll();
            txtValor.Select();
        }

        private void ControlsPanelCedulas_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button btn)
            {
                var valorDaCedulaPressionada = Convert.ToDecimal(btn.Tag);

                txtValor.Text = (ModifierKeys == Keys.Shift ? Convert.ToDecimal(txtValor.Text) + valorDaCedulaPressionada : valorDaCedulaPressionada).ToString("0.00");
            }
        }

        private void ControlsPanelSelecionaBandeira_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is RadioButton radiobtn)
            {
                _pagamentoId  = Convert.ToInt32(radiobtn.Tag);
            }
        }

        private void ControlsPanelTeclado_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (!(sender is Button button)) return;

                if (_textBoxSelecionado == null)
                    return;

                if (button.Text == "C")
                {
                    _textBoxSelecionado.Text = string.Empty;
                    return;
                }

                if (_textBoxSelecionado.SelectionLength == _textBoxSelecionado.TextLength)
                    _textBoxSelecionado.Text = "";

                _textBoxSelecionado.Text += button.Text;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Erro inesperado ao usar o Painel de Teclado!");
            }
        }


        private void txtValor_Click(object sender, EventArgs e)
        {
            txtValor.SelectionStart = txtValor.Text.Length;

            if (txtValor.Text == "0,00")
                txtValor.SelectAll();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FormataTextBox.TextBoxMoeda(ref txtValor);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Valor Recebido digitado incorretamente!");
            }
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
                _textBoxSelecionado = txt;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (_textBoxSelecionado == null || _textBoxSelecionado.TextLength <= 0)
                return;

            _textBoxSelecionado.Text = _textBoxSelecionado.Text.Substring(0, _textBoxSelecionado.TextLength - 1);
        }

        private void btnValorFaltando_Click(object sender, EventArgs e)
        {
            txtValor.Text = _valorDoPedido.ToString("0.00");
        }

        private void lblSalvar_Click(object sender, EventArgs e)
        {
            if (txtValor.Text == "0,00")
            {
                MessageBox.Show("Digite um valor válido!", "Mensagem", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
                return;
            }

            if (_tipoDePagamento != "DINHEIRO")
            {
                if (_pagamentoId == 0)
                {
                    MessageBox.Show("Selecione a bandeira do cartão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                _pagamentoId = 1; //DINHEIRO
            }


            try
            {
                Pagamento = (new TipoPagamentoDao()).GetTipoPagamento(_pagamentoId) ?? throw new ArgumentNullException("Forma de pagamento não encontrada no Banco de Dados, verifique por favor.");

                Pagamento.ValorPago = Convert.ToDecimal(txtValor.Text);
                Pagamento.Observacao = txtObservacao.Text.Trim();
                Pagamento.NumeroDeAutorizacaoDoCartao = txtNumAutorizacao.Text.Trim();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro inesperado ao Salvar a forma de pagamento, tente novamente." + Environment.NewLine + "Erro: " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmInformaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    Cancelar();
                    break;
            }
        }
        private void btnLimparValor_Click(object sender, EventArgs e)
        {
            txtValor.Text = "0,00";
        }

        private void Cancelar()
        {
            Close();
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlBandeiras_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radOutros_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
