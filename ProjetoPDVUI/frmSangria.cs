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


                var operacaoId = 0;

                foreach (Control control in panelOperacao.Controls)
                {
                    if (control is RadioButton radio)
                    {
                        if (radio.Checked == true)
                        {
                            operacaoId = Convert.ToInt32(radio.Tag);
                        }
                    }
                }




                Pedido = new Pedido()
                {
                    DataDigitacao = DateTime.Now,
                    ValorPedido = Convert.ToDecimal(txtValor.Text),
                    StatusPedido = "F",
                    UsuarioId = Usuario.getInstance.codUser,
                    OperacaoId = operacaoId
                };

                Pedido.NumDoc = Convert.ToInt32(db.Insert(Pedido));

                db.Insert("Movdb_Pagamento_Rel", new { numdoc = Pedido.NumDoc, pagamento_id = 1, valor = Convert.ToDecimal(txtValor.Text), observacao = txtObservacao.Text });
                

                db.CompleteTransaction();


                if (ckImprimir.Checked)
                {
                    VerificaStatusImpressora();

                    bool isSangria = false;

                    if (operacaoId == 2)
                        isSangria = true;

                    if (!ImpressoraBematech.isSangriaAcrescimo(isSangria, Pedido.DataDigitacao, Pedido.ValorPedido, txtObservacao.Text.Trim()))
                        MessageBox.Show("Houve um erro inesperado ao se comunicar com a IMPRESSOSA BEMATECH, verifique-a por favor!");

                }
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                MessageBox.Show("Houve um erro inesperado ao finalizar o Lançamento, tente novamente!" + Environment.NewLine + ex.Message);
            }

            Close();
        }



        private void VerificaStatusImpressora()
        {
            MP2032.ConfiguraModeloImpressora(7); // Bematech MP-4200 TH
            MP2032.IniciaPorta("USB");

            var codigoRetorno = MP2032.Le_Status();
            if (codigoRetorno == 0)
            {
                MessageBox.Show("Erro ao se comunicar com a Impressora Bematech MP-4200 TH, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (codigoRetorno == 5)
            {
                MessageBox.Show("Impressora com pouco papel, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (codigoRetorno == 9)
            {
                MessageBox.Show("Impressora com a tampa aberta, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MP2032.FechaPorta();
                return;
            }
            else if (codigoRetorno == 32)
            {
                MessageBox.Show("Impressora sem papel, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
