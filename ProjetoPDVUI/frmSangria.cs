using PetaPoco;
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
    public partial class frmSangria : Form
    {
        public Pedido Pedido;
        private int _operacaoId;

        public frmSangria()
        {
            InitializeComponent();

            foreach (Control control in panelOperacao.Controls)
            {
                if (control is RadioButton radio)
                    radio.MouseDown += ControlsPanelOperacao_MouseDown;
            }
        }

        private void lblSalvar_Click(object sender, EventArgs e)
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

                Pedido = new Pedido()
                {
                    DataDigitacao = DateTime.Now,
                    ValorPedido = Convert.ToDecimal(txtValor.Text),
                    StatusPedido = "F",
                    UsuarioId = Usuario.getInstance.codUser,
                    OperacaoId = _operacaoId
                };

                Pedido.NumDoc = Convert.ToInt32(db.Insert(Pedido));

                db.Insert("Movdb_Pagamento_Rel", new { numdoc = Pedido.NumDoc, pagamento_id = 1, valor = Convert.ToDecimal(txtValor.Text), observacao = txtObservacao.Text });


                db.CompleteTransaction();
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                MessageBox.Show("Houve um erro inesperado ao finalizar o Lançamento, tente novamente!" + Environment.NewLine + ex.Message);
            }

            Close();
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

        private void frmSangria_Load(object sender, EventArgs e)
        {

        }

        private void ControlsPanelOperacao_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (sender is RadioButton radio)
                {
                    _operacaoId = Convert.ToInt32(radio.Tag);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Erro inesperado ao usar o Painel de Teclado!");
            }
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
