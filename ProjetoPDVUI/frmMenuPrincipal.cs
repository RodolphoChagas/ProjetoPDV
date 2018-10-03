using ProjetoPDVDao;
using ProjetoPDVModel;
using ProjetoPDVServico;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();


            //ToolStrip imagens
            toolStripButton2.Image = Image.FromFile(Application.StartupPath + @"\Imagens\settings.png");
            toolStripButton3.Image = Image.FromFile(Application.StartupPath + @"\Imagens\carrinho60.png");
            toolStripButton1.Image = Image.FromFile(Application.StartupPath + @"\Imagens\financeiro.png");
            toolStripButton5.Image = Image.FromFile(Application.StartupPath + @"\Imagens\produtos70.png");
            toolStripButton6.Image = Image.FromFile(Application.StartupPath + @"\Imagens\clientes70.png");
            toolStripButton4.Image = Image.FromFile(Application.StartupPath + @"\Imagens\caixa60.png");
            toolStripButton7.Image = Image.FromFile(Application.StartupPath + @"\Imagens\trofeu60.png");
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {

            this.Text = "Menu Principal (NFCe 4.00)";

            try
            {

                if (!(new EmitenteDao()).SelecionaEmitente())
                {
                    MessageBox.Show("Dados do Emitente não encontrado, tente novamente!", "Erro Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                stbPrincipal.Items[0].Text = Emitente.GetInstancia.Nome;
                stbPrincipal.Items[1].Text = "CNPJ: " + String.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToInt64(Emitente.GetInstancia.Cnpj));
                stbPrincipal.Items[2].Text = "IE: " + Emitente.GetInstancia.InsCest;
                stbPrincipal.Items[3].Text = DateTime.Now.ToString("dd/MM/yyyy");
                stbPrincipal.Items[5].Text = "Usuário: " + Usuario.getInstance.nomeUser;
                stbPrincipal.Items[6].Text = "";
            }
            catch (Exception ex)
            {
                //Log_Exception.Monta_ArquivoLog(ex);

                MessageBox.Show("Ocorreu um erro ao buscar os dados do Emitente no banco de dados, verfique por favor ou contate o administrador do sistema! " + Environment.NewLine + "Retorno do erro: " + ex.Message, "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //===========================================
            // Definindo o ambiente
            GeraXml.AmbienteNFCe = "1";
            //===========================================


            if (GeraXml.AmbienteNFCe == "1")
                stbPrincipal.Items[4].Text = "Ambiente PRODUÇÃO";
            else
                stbPrincipal.Items[4].Text = "Ambiente HOMOLOGAÇÃO";


            var control = (new ControleFiscalDao()).getControle();
            if (control != null)
            {
                ControleFiscal.GetInstance.TokenHomologacao = control.TokenHomologacao;
                ControleFiscal.GetInstance.TokenProducao = control.TokenProducao;
                ControleFiscal.GetInstance.CaminhoXmlAutorizado = control.CaminhoXmlAutorizado;
                ControleFiscal.GetInstance.CaminhoXmlCancelado = control.CaminhoXmlCancelado;
                ControleFiscal.GetInstance.CaminhoXmlInutilizado = control.CaminhoXmlInutilizado;

                control = null;
            }
        }


        private void frmMenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F5:
                    toolStripButton3_Click(sender, e);
                    break;
                case Keys.F10:
                    toolStripButton1_Click(sender, e);
                    break;
                case Keys.F4:
                    toolStripButton4_Click(sender, e);
                    break;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var frm = new frmCaixaTouch();
            frm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var frm = new frmHistoricoDePedidos();
            frm.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var frm = new frmAbreCaixa();
            frm.ShowDialog();
        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new frmProdutoCategoria();
            frm.ShowDialog();
        }

        private void gruposFiscalTributosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmProdutoGrupoFiscal();
            frm.ShowDialog();
        }

        private void contasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListaFornecedores();
            frm.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var frm = new frmListaProdutosCombos();
            frm.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListaProdutosCombos();
            frm.ShowDialog();
        }

        private void categoriasDeContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmListaCapCategorias();
            frm.ShowDialog();
        }

        private void históricoDeCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
