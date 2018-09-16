using PetaPoco;
using ProjetoPDVDao;
using ProjetoPDVModel;
using System;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmCapCategorias : Form
    {
        private string _id;
        private CapCategoria _categoria;
        private CapSubcategoria _subCategoria;

        public frmCapCategorias(string id = "")
        {
            InitializeComponent();

            _id = id;
        }


        private void lblSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text.Trim()))
            {
                MessageBox.Show("Informe o nome do fornecedor por favor.", "Mensagem - Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            using (var db = new Database("stringConexao"))
            {
                try
                {
                    db.BeginTransaction();


                    // NOVO
                    if (_id == "")
                    {
                        // Categoria
                        if (ckCategoriaPrincipal.Checked)
                        {
                            var categoria = new CapCategoria
                            {
                                Descricao = txtDescricao.Text,
                                Status = "A"
                            };

                            db.Insert(categoria);
                        }
                        else // SubCategoria
                        {
                            var subCategoria = new CapSubcategoria
                            {
                                Descricao = txtDescricao.Text,
                                CategoriaId = Convert.ToInt32(cboCategorias.SelectedValue),
                                Status = "A"
                            };

                            db.Insert(subCategoria);
                        }

                    }
                    else // EDITANDO
                    {
                        // SubCategoria
                        if (_id.Substring(0, 1) == "S")
                        {
                            // Alterando para Categoria
                            if (ckCategoriaPrincipal.Checked)
                            {
                                var categoria = new CapCategoria
                                {
                                    Descricao = txtDescricao.Text,
                                    Status = "A"
                                };

                                db.Insert(categoria);
                            }
                            else
                            {
                                _subCategoria.Descricao = txtDescricao.Text;
                                _subCategoria.CategoriaId = Convert.ToInt32(cboCategorias.SelectedValue);

                                db.Update(_subCategoria);
                            }
                        }
                        else // Categoria
                        {

                            if (ckCategoriaPrincipal.Checked)
                            {
                                _categoria.Descricao = txtDescricao.Text;
                                db.Update(_categoria);
                            }
                            else // Alterando para SubCategoria
                            {
                                var subCategoria = new CapSubcategoria
                                {
                                    Descricao = txtDescricao.Text,
                                    CategoriaId = Convert.ToInt32(cboCategorias.SelectedValue),
                                    Status = "A"
                                };

                                db.Insert(subCategoria);
                            }

                        }
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

        private void frmCapCategorias_Load(object sender, EventArgs e)
        {
            // ComboBox Categoria
            var categorias = (new CapDao()).GetCategoriasAtivas();
            cboCategorias.DataSource = categorias;
            cboCategorias.DisplayMember = "descricao";
            cboCategorias.ValueMember = "categoriaid";

            if (_id != "")
            {
                if (_id.Substring(0, 1) == "S")
                {
                    _subCategoria = (new CapDao()).GetSubCategoria(Convert.ToInt32(_id.Substring(1, _id.Length - 1)));

                    cboCategorias.SelectedValue = _subCategoria.CategoriaId;
                    txtDescricao.Text = _subCategoria.Descricao;
                }
                else
                {
                    _categoria = (new CapDao()).GetCategoria(Convert.ToInt32(_id.Substring(1, _id.Length - 1)));

                    cboCategorias.SelectedIndex = -1;
                    txtDescricao.Text = _categoria.Descricao;
                    ckCategoriaPrincipal.Checked = true;
                    cboCategorias.Enabled = false;
                }
            }
        }

        private void ckCategoriaPrincipal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCategoriaPrincipal.CheckState == CheckState.Checked)
            {
                cboCategorias.Enabled = false;
                cboCategorias.SelectedIndex = -1;
            }
            else
            {
                cboCategorias.Enabled = true;
                cboCategorias.SelectedIndex = 0;
            }
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
