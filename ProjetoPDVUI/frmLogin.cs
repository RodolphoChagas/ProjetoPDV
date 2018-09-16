using System;
using System.Windows.Forms;
using ProjetoPDVDao;
using ProjetoPDVModel;


namespace ProjetoPDVUI
{
    public partial class frmLogin : Form
    {
        public bool LogonSuccessful;

        public frmLogin()
        {
            LogonSuccessful = false;
            InitializeComponent();
        }

        private void Valida_UsuarioeSenha()
        {

            if (txtLogin.Text.Trim().Length == 0)
            {
                MessageBox.Show("Entre com o nome do usuário.", "Erro - Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtSenha.Text.Trim().Length == 0)
            {
                MessageBox.Show("Entre com a senha do usuário.", "Erro - Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (!(new UsuarioDao()).SelecionaUsuario(txtLogin.Text, txtSenha.Text))
                {
                    MessageBox.Show("Nome de usuário ou senha incorretos.", "Erro Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado ao se comunicar com o banco de dados." + Environment.NewLine + "Erro: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Selecionando o certificado
                CertificadoDigital.getInstance.Seleciona_Certificado();

                //Iniciando o certificado
                if (CertificadoDigital.getInstance.oCertificado == null)
                {
                    MessageBox.Show("Certificado não encontrado." + Environment.NewLine + "Tente novamente...", "Certificado - Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if ((CertificadoDigital.getInstance.dValidadeFinal - DateTime.Now).Days <= 7)
                {
                    if ((CertificadoDigital.getInstance.dValidadeFinal - DateTime.Now).Days <= 0)
                    {
                        MessageBox.Show("CERTIFICADO EXPIRADO!" + Environment.NewLine + "Informe imediatamente ao gerente do Setor.", "Certificado - Validade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("Atenção, faltam " + (CertificadoDigital.getInstance.dValidadeFinal - DateTime.Now).Days + " dias para o certificado expirar!", "Atenção - Validade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                LogonSuccessful = true;
                Close();
            }
            catch (Exception ex)
            {
                //Log_Exception.Monta_ArquivoLog(ex);

                MessageBox.Show("Erro ao selecionar CERTIFICADO DIGITAL no computador, verifique por favor!" + Environment.NewLine + "Retorno do erro: " + ex.Message, "Login - Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogonSuccessful = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            LogonSuccessful = false;
            Close();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Valida_UsuarioeSenha();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Valida_UsuarioeSenha();
        }
    }
}
