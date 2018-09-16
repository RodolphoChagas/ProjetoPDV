using System;
using System.Drawing;
using System.Windows.Forms;
using ProjetoPDVDao;
using ProjetoPDVModel;
using ProjetoPDVUtil;

namespace ProjetoPDVUI
{
    public partial class frmSelecionaPagamento : Form
    {
        private TextBox _textBoxSelecionado;
        private TipoPagamento _tipoPagamento;
        private readonly Pedido _pedido;
        private readonly frmCaixaTouch _instanciaFrmCaixa;
        

        public frmSelecionaPagamento(Pedido pedido, frmCaixaTouch frmCaixa)
        {
            InitializeComponent();

            //Inicializando as imagens dos botoes
            btnVisa.Image = Image.FromFile(@"Imagens\visa3.png");
            btnMasterCard.Image = Image.FromFile(@"Imagens\mastercard3.png");
            btnELO.Image = Image.FromFile(@"Imagens\elo.png");
            btnDiners.Image = Image.FromFile(@"Imagens\diners.png");
            btnAmericanExpress.Image = Image.FromFile(@"Imagens\american2.png");
            btnVisaEletron.Image = Image.FromFile(@"Imagens\visaelectron2.png");
            btnRedeShop.Image = Image.FromFile(@"Imagens\maestro3.png");
            btnDinheiro.Image = Image.FromFile(@"Imagens\dinheiro.png");
            btnFinalizar.Image = Image.FromFile(@"Imagens\accept.png");
            btnCancelar.Image = Image.FromFile(@"Imagens\cancel.png");

            _pedido = pedido;
            _instanciaFrmCaixa = frmCaixa;

            //Botões do Painel de Tipos de Pagamento
            foreach (Control control in pnlPagamento.Controls)
            {
                if (control is Button button)
                    button.MouseDown += ControlsPanelPagamento_MouseDown;
            }
            //Botões do Painel de Teclado
            foreach (Control control in pnlTeclado.Controls)
            {
                if (control is Button button)
                    button.MouseDown += ControlsPanelTeclado_MouseDown;
            }

            //Busco todos os TextBox do Formulário e insiro o Evento Enter criado, para saber qual TextBox o usuário selecionou
            foreach (Control control in Controls)
            {
                switch (control)
                {
                    case GroupBox gp:
                        foreach (Control controlTextBox in gp.Controls)
                        {
                            if(controlTextBox is TextBox text)
                            text.Enter += TextBox_Enter;
                        }
                        break;
                }
            }
        }


        private void frmSelecionaPagamento_Load(object sender, EventArgs e)
        {
            lblValorTotal.Text = _pedido.ValorPedido.ToString("0.00");
            txtValorRecebido.Text = _pedido.ValorPedido.ToString("0.00");
        }


        private void FinalizaPagamento()
        {
            var dialogResult = MessageBox.Show("Confirma gerar a NFC-e ?", "Finalizando pagamento", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            


            Dispose();
            Close();

            _instanciaFrmCaixa.IniciaNovaVenda();
        }

        private void ControlsPanelPagamento_MouseDown(object sender, MouseEventArgs e)
        {
            if (_tipoPagamento != null)
            {
                foreach (Control control in pnlPagamento.Controls)
                {
                    if(control is Button b)
                        b.BackColor = Color.Transparent;
                }
            }

            if (sender is Button btn)
            {
                btn.BackColor = Color.FromArgb(100, 151, 209);

                try
                {
                    _tipoPagamento = (new TipoPagamentoDao()).GetTipoPagamento(Convert.ToInt32(btn.Tag)) ?? throw new ArgumentNullException(@"Erro ao buscar as informações do Tipo de Pagamento no Banco de Dados, tente novamente.");


                    if (_tipoPagamento.Descricao == "Dinheiro")
                    {
                        txtValorRecebido.Enabled = true;

                        txtValorRecebido.Focus();
                        txtValorRecebido.SelectAll();
                    }
                    else
                    {
                        txtValorRecebido.Text = lblValorTotal.Text;
                        txtValorRecebido.Enabled = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao iniciar as formas de pagamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (_textBoxSelecionado == null || _textBoxSelecionado.TextLength <= 0)
                return;

            _textBoxSelecionado.Text = _textBoxSelecionado.Text.Substring(0, _textBoxSelecionado.TextLength - 1);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
                _textBoxSelecionado = txt;
        }

        private void txtValorRecebido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FormataTextBox.TextBoxMoeda(ref txtValorRecebido);

                lblTroco.Text = (Convert.ToDecimal(txtValorRecebido.Text) - Convert.ToDecimal(lblValorTotal.Text)).ToString("0.00");
            }
            catch (Exception)
            {
                MessageBox.Show(@"Valor Recebido digitado incorretamente!");
            }
        }

        private void txtValorRecebido_Click(object sender, EventArgs e)
        {
            txtValorRecebido.SelectionStart = txtValorRecebido.Text.Length;
        }

        private void btnCincoReais_Click(object sender, EventArgs e)
        {
            txtValorRecebido.Text = @"5,00";
        }

        private void btnDezReais_Click(object sender, EventArgs e)
        {
            txtValorRecebido.Text = @"10,00";
        }

        private void btnVinteReais_Click(object sender, EventArgs e)
        {
            txtValorRecebido.Text = @"20,00";
        }

        private void btnCinquentaReais_Click(object sender, EventArgs e)
        {
            txtValorRecebido.Text = @"50,00";
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            FinalizaPagamento();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
