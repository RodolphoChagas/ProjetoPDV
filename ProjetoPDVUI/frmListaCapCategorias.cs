using ProjetoPDVDao;
using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmListaCapCategorias : Form
    {
        private List<CapCategoria> _categorias;


        public frmListaCapCategorias()
        {
            InitializeComponent();
        }

        private void lblNovo_Click(object sender, EventArgs e)
        {
            var frmCategorias = new frmCapCategorias();
            frmCategorias.ShowDialog();

            ListaCategorias();
        }

        private void lblEditar_Click(object sender, EventArgs e)
        {
            if (treeCategorias.SelectedNode.IsSelected)
            {
                var frmCategorias = new frmCapCategorias(treeCategorias.SelectedNode.Tag.ToString());
                frmCategorias.ShowDialog();

                ListaCategorias();
            }
        }

        private void frmListaCapCategorias_Load(object sender, EventArgs e)
        {
            ListaCategorias();
        }

        private void ListaCategorias()
        {
            treeCategorias.Nodes.Clear();

            try
            {

                _categorias = (new CapDao()).GetCategoriasAtivas();

                if (_categorias != null)
                {
                    _categorias.ForEach(categoria => categoria.SubCategorias = (new CapDao()).GetSubcategoriasPorCategoria(categoria.CategoriaId));
                }


                foreach (CapCategoria categoria in _categorias)
                {
                    TreeNode pai = new TreeNode(categoria.Descricao);
                    pai.Tag = "C" + categoria.CategoriaId;

                    foreach (CapSubcategoria subCategoria in categoria.SubCategorias)
                    {
                        TreeNode filho = new TreeNode(subCategoria.Descricao);
                        filho.Tag = "S" + subCategoria.SubcategoriaId;
                        pai.Nodes.Add(filho);
                    }

                    treeCategorias.Nodes.Add(pai);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
