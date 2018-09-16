using PetaPoco;
using ProjetoPDVModel;
using System;
using System.Windows.Forms;
using ProjetoPDVUtil;
using ProjetoPDVDao;

namespace ProjetoPDVUI
{
    public partial class frmFornecedor : Form
    {
        private Fornecedor _fornecedor = new Fornecedor();


        public frmFornecedor(int fornecedorId = 0)
        {
            _fornecedor.FornecedorId = fornecedorId;

            InitializeComponent();
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblSalvar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                MessageBox.Show("Informe o nome do fornecedor por favor.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!string.IsNullOrEmpty(txtCnpjCpf.Text.Trim()))
            {
                if (txtCnpjCpf.Text.Trim().Length <= 11)
                {
                    if (!Validacao.IsCpf(txtCnpjCpf.Text.Trim()))
                    {
                        MessageBox.Show("CPF inválido.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    if (!Validacao.IsCnpj(txtCnpjCpf.Text.Trim()))
                    {
                        MessageBox.Show("CNPJ inválido.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("CNPJ/CPF precisa ser preenchido.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_fornecedor.FornecedorId == 0)
            {
                if ((new FornecedorDao()).isFornecedorCadastrado(txtCnpjCpf.Text.Trim()))
                {
                    MessageBox.Show("Fornecedor já cadastrado, verifique por favor.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //if (string.IsNullOrEmpty(txtCep.Text.Trim()))
            //{
            //    MessageBox.Show("Informe o CEP por favor.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtEndereco.Text.Trim()))
            //{
            //    MessageBox.Show("Informe o valor do Lançamento.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtCep.Text.Trim()))
            //{
            //    MessageBox.Show("Informe o CEP por favor.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtBairro.Text.Trim()))
            //{
            //    MessageBox.Show("Informe o Bairro por favor.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (string.IsNullOrEmpty(txtCidade.Text.Trim()))
            //{
            //    MessageBox.Show("Informe a Cidade por favor.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}


            using (var db = new Database("stringConexao"))
            {
                try
                {
                    db.BeginTransaction();

                    _fornecedor.Descricao = txtNome.Text.Trim();
                    _fornecedor.CnpjCpf = txtCnpjCpf.Text.Trim();
                    _fornecedor.Email = txtEmail.Text.Trim();
                    _fornecedor.TelefonePrincipal = txtFonePrincipal.Text.Trim();
                    _fornecedor.InscEstRG = txtIeRg.Text.Trim();
                    _fornecedor.Observacao = txtObservacao.Text;
                    _fornecedor.Logradouro = txtEndereco.Text.Trim();
                    _fornecedor.Bairro = txtBairro.Text.Trim();
                    _fornecedor.Cidade = txtCidade.Text.Trim();
                    _fornecedor.Complemento = txtComplemento.Text;
                    _fornecedor.Cep = txtCep.Text.Trim();
                    _fornecedor.Uf = cboUf.Text;

                    if (_fornecedor.FornecedorId == 0)
                    {
                        if (Convert.ToInt32(db.Insert(_fornecedor)) == 0)
                            throw new Exception("Erro ao inserir o novo Fornecedor, tente novamente.");
                    }
                    else
                    {
                        if (db.Update(_fornecedor) <= 0)
                            throw new Exception("Erro ao atualizar o Fornecedor, tente novamente.");
                    }

                    db.CompleteTransaction();

                    Close();
                }
                catch (Exception ex)
                {
                    db.AbortTransaction();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frmFornecedor_Load(object sender, EventArgs e)
        {

            if (_fornecedor.FornecedorId != 0)
            {
                _fornecedor = (new FornecedorDao()).GetFornecedor(_fornecedor.FornecedorId);

                txtNome.Text = _fornecedor.Descricao;
                txtFonePrincipal.Text = _fornecedor.TelefonePrincipal ?? "";
                txtEmail.Text = _fornecedor.Email ?? "";
                txtCnpjCpf.Text = _fornecedor.CnpjCpf ?? "";
                txtIeRg.Text = _fornecedor.InscEstRG ?? "";
                txtObservacao.Text = _fornecedor.Observacao ?? "";

                txtCep.Text = _fornecedor.Cep ?? "";
                txtEndereco.Text = _fornecedor.Logradouro ?? "";
                txtBairro.Text = _fornecedor.Bairro ?? "";
                txtComplemento.Text = _fornecedor.Complemento ?? "";
                txtCidade.Text = _fornecedor.Cidade ?? "";
                cboUf.Text = _fornecedor.Uf ?? "";
            }
            else
            {
                cboUf.SelectedIndex = 0;
            }
            
        }

        private void BuscaCep()
        {
            try
            {
                var enderecoCep = new CEP(txtCep.Text);

                if (enderecoCep != null)
                {
                    txtEndereco.Text = enderecoCep.logradouro;
                    txtBairro.Text = enderecoCep.bairro;
                    txtCidade.Text = enderecoCep.localidade;
                    cboUf.Text = enderecoCep.uf;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar o CEP, tente novamente." + Environment.NewLine + ex.Message, "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscaCep_Click(object sender, EventArgs e)
        {
            BuscaCep();
        }

        private void txtCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                BuscaCep();
        }

        private void txtFonePrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCnpjCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

    }
}
