using System;
using System.Windows.Forms;
using PetaPoco;
using ProjetoPDVDao;
using ProjetoPDVModel;

namespace ProjetoPDVUI
{
    public partial class frmProduto : Form
    {
        private int _codpro;
        private Produto _produto = new Produto();
        private readonly ProdutoCategoriaDao _produtoCategDao = new ProdutoCategoriaDao();
        private readonly ProdutoGrupoFiscalDao _produtoGrupoFiscalDao = new ProdutoGrupoFiscalDao();
        private readonly frmListaProdutosCombos _frmLista;

        
        public frmProduto(int codpro = 0)
        {
            InitializeComponent();

            _codpro = codpro;
            //_frmLista = frm;
        }
        
        private void Inicia_Combobox()
        {
            try
            {
                // ComboBox Categoria
                var lstCategoria = _produtoCategDao.GetCategorias();
                cboCategoria.DataSource = lstCategoria;
                cboCategoria.DisplayMember = "descricao";
                cboCategoria.ValueMember = "categoriaid";


                // ComboBox Grupo Fiscal
                var lstGrupo = _produtoGrupoFiscalDao.GetGruposFiscais();
                cboGrupo.DataSource = lstGrupo;
                cboGrupo.DisplayMember = "descricao";
                cboGrupo.ValueMember = "grupoid";


                if (_codpro != 0)
                {
                    cboCategoria.SelectedValue = _produto.Categoria.CategoriaId;
                    cboGrupo.SelectedValue = _produto.GrupoFiscal.GrupoId;
                    cboSituacao.SelectedIndex = _produto.Status;
                }
                else
                {
                    cboCategoria.SelectedIndex = 0;
                    cboGrupo.SelectedIndex = 0;
                    cboSituacao.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao iniciar os combobox, tente novamente!");
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text.Trim()))
            {
                MessageBox.Show("Digite a descrição do Produto por favor.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Convert.ToDecimal(txtPrcVenda.Text) <= 0)
            {
                MessageBox.Show("Preço de Venda inválido.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (Convert.ToDecimal(txtPrcCusto.Text) <= 0)
            //{
            //    MessageBox.Show("Preço de Custo inválido.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            var dataAtual = DateTime.Now;
            var db = new Database("stringConexao");

            try
            {

                var produto = new Produto()
                {
                    Descricao = txtDescricao.Text.Trim(),
                    DataInicio = dataAtual,
                    DataUltAtualizacao = dataAtual,
                    PrecoDeVenda = Convert.ToDecimal(txtPrcVenda.Text.Trim()),
                    PrecoDeCusto = Convert.ToDecimal(txtPrcCusto.Text.Trim()),
                    Status = cboSituacao.SelectedIndex,
                    CategoriaId = (int)cboCategoria.SelectedValue,
                    GrupoId = (int)cboGrupo.SelectedValue
                };


                db.BeginTransaction();

                // INSERT
                string msg;
                if (_codpro == 0)
                {
                    var retCodPro = db.Insert(produto);

                    txtCodPro.Text = retCodPro.ToString();
                    txtDataInicio.Text = dataAtual.ToString("dd/MM/yyyy");
                    txtDataUltAtt.Text = dataAtual.ToString("dd/MM/yyyy");

                    msg = "Produto inserido com sucesso!";
                }
                else // UPDATE
                {
                    db.Update("Produto", "produto_id", new { descricao = produto.Descricao, data_atualizacao = produto.DataUltAtualizacao, preco_venda = produto.PrecoDeVenda, preco_custo = produto.PrecoDeCusto, status = produto.Status, categoria_id = produto.CategoriaId, grupo_id = produto.GrupoId }, Convert.ToInt32(txtCodPro.Text));
                    msg = "Produto atualizado com sucesso!";
                }

                db.CompleteTransaction();

                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                MessageBox.Show("Erro ao inserir/atualizar o produto, tente novamente." + Environment.NewLine + "Retorno do erro: " + ex.Message, "Login - Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db?.Dispose();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _codpro = 0;
            txtCodPro.Text = string.Empty;
            txtDataInicio.Text = string.Empty;
            txtDataUltAtt.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtPrcVenda.Text = "0,00";
            txtPrcCusto.Text = "0,00";
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            try
            {
                if (_codpro != 0)
                {
                    _produto = (new ProdutoDao()).GetProduto(_codpro);
                    _produto.Categoria = _produtoCategDao.GetCategoriaPorProduto(_codpro);
                    _produto.GrupoFiscal = _produtoGrupoFiscalDao.GetGrupoFiscalPorProduto(_codpro);

                    txtCodPro.Text = _produto.ProdutoId.ToString();
                    txtDescricao.Text = _produto.Descricao;
                    txtDataInicio.Text = _produto.DataInicio?.ToString("dd/MM/yyyy");
                    txtDataUltAtt.Text = _produto.DataUltAtualizacao?.ToString("dd/MM/yyyy");
                    txtPrcVenda.Text = _produto.PrecoDeVenda.ToString("0.00");
                    txtPrcCusto.Text = _produto.PrecoDeCusto.ToString("0.00");
                }

                Inicia_Combobox();
                _produto = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar o produto, tente novamente por favor." + Environment.NewLine + "Retorno do erro: " + ex.Message, "Login - Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrcVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }
            if ((e.KeyChar == ',') && (((TextBox)sender).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente uma virgula");
            }
        }

        private void frmProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }
    }
}
