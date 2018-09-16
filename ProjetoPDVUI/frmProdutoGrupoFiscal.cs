using PetaPoco;
using ProjetoPDVDao;
using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmProdutoGrupoFiscal : Form
    {
        private List<ProdutoGrupoFiscal> _lstGrupo = new List<ProdutoGrupoFiscal>();

        public frmProdutoGrupoFiscal()
        {
            InitializeComponent();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescGrupo.Text))
            {
                MessageBox.Show("Informe a descrição do Grupo por favor.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtNCM.Text))
            {
                MessageBox.Show("Informe o NCM por favor.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtCSOSN.Text) || Convert.ToInt32(txtCSOSN.Text) == 0)
            {
                MessageBox.Show("Informe o CSOSN!", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCSOSN.Focus();
                return;
            }



            var db = new Database("stringConexao");


            try
            {
                db.BeginTransaction();

                var grupo = new ProdutoGrupoFiscal()
                {
                    GrupoId = Convert.ToInt32(txtCodGrupo.Text),
                    Descricao = txtDescGrupo.Text.Trim(),
                    Ncm = txtNCM.Text.Trim(),
                    Cest = txtCEST.Text.Trim(),
                    pis = Convert.ToDecimal(string.IsNullOrEmpty(txtPIS.Text) ? "0" : txtPIS.Text.Trim()),
                    Cofins = Convert.ToDecimal(string.IsNullOrEmpty(txtCOFINS.Text) ? "0" : txtCOFINS.Text.Trim()),
                    Csll = Convert.ToDecimal(string.IsNullOrEmpty(txtCSLL.Text) ? "0" : txtCSLL.Text.Trim()),
                    Irpj = Convert.ToDecimal(string.IsNullOrEmpty(txtIRPJ.Text) ? "0" : txtIRPJ.Text.Trim()),
                    ST = cboICMS.SelectedIndex,
                    CSOSN = txtCSOSN.Text ?? "",
                    PISCST = txtPISCST.Text  ?? "",
                    COFINSCST = txtCOFINSCST.Text ?? ""
                };

                string msg;
                if (grupo.GrupoId == 0)
                {
                    if (Convert.ToInt32(db.Insert(grupo)) != 0)
                        msg = "Grupo inserido com sucesso!";
                    else
                        throw new Exception("Houve um erro inesperado ao inserir este Grupo, tente novamente!");
                }
                else
                {
                    if (db.Update(grupo) != 0)
                        msg = "Grupo atualizado com sucesso!";
                    else
                        throw new Exception("Houve um erro inesperado ao atualizar este Grupo, tente novamente!");
                }

                db.CompleteTransaction();

                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Inicia_ListaGrupo();
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                MessageBox.Show(ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ReSharper disable once RedundantCheckBeforeAssignment
            if (_lstGrupo != null)
            {
                _lstGrupo = null;
            }

            Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCodGrupo.Text = "0";
            txtDescGrupo.Text = string.Empty;
            txtNCM.Text = string.Empty;
            txtCEST.Text = string.Empty;
            txtPIS.Text = "0";
            txtCOFINS.Text = "0";
            txtCSLL.Text = "0";
            txtIRPJ.Text = "0";
            txtCSOSN.Text = "0";
            txtPISCST.Text = "99";
            txtCOFINSCST.Text = "99";
        }

        private void frmProdutoGrupoFiscal_Load(object sender, EventArgs e)
        {
            cboICMS.SelectedIndex = 0;
            Inicia_ListaGrupo();
        }

        private void Inicia_ListaGrupo()
        {
            try
            {
                _lstGrupo = (new ProdutoGrupoFiscalDao()).GetGruposFiscais();

                lstvwGrupo.Items.Clear();

                foreach (ProdutoGrupoFiscal pGrupo in _lstGrupo)
                {
                    ListViewItem ls = new ListViewItem(pGrupo.GrupoId.ToString());
                    ls.SubItems.Add(pGrupo.Descricao);
                    lstvwGrupo.Items.Add(ls);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro ao listar os Grupos Fiscais, tente novamente." + Environment.NewLine + "Erro: " + ex.Message, "Grupo Fiscal - Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstvwGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvwGrupo.FocusedItem == null)
                return;

            var grupo = _lstGrupo.Find(x => x.GrupoId == Convert.ToInt32(lstvwGrupo.FocusedItem.Text));

            txtCodGrupo.Text = grupo.GrupoId.ToString();
            txtDescGrupo.Text = grupo.Descricao.Trim();
            txtNCM.Text = grupo.Ncm;
            txtCEST.Text = grupo.Cest;

            txtPIS.Text = grupo.pis.ToString("0.00");
            txtPISCST.Text = grupo.PISCST;

            txtCOFINS.Text = grupo.Cofins.ToString("0.00");
            txtCOFINSCST.Text = grupo.COFINSCST;

            txtCSOSN.Text = grupo.CSOSN;
            cboICMS.SelectedIndex = grupo.ST;
            txtCSLL.Text = grupo.Csll.ToString("0.00");
            txtIRPJ.Text = grupo.Irpj.ToString("0.00");

        }

        private void cboICMS_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cboICMS.SelectedIndex == 1)
            //    txtpICMS.Enabled = false;
            //else
            //    txtpICMS.Enabled = true;
        }

        private void txtPIS_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCOFINS_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCSLL_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIRPJ_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtpICMS_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }
            if ((e.KeyChar == ',') && (((TextBox)sender).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCEST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }
            if ((e.KeyChar == ',') && (((TextBox)sender).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCSOSN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
