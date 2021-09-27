using ProjetoPDVDao;
using ProjetoPDVModel;
using System;
using System.Windows.Forms;

namespace ProjetoPDVUI
{
    public partial class frmCap : Form
    {
        public frmCap()
        {
            InitializeComponent();
        }

        private void frmCap_Load(object sender, EventArgs e)
        {

            try
            {
                var categorias = (new CapDao()).GetCategoriasAtivas();

                //if (categorias != null)
                //{
                //    categorias.ForEach(categoria => categoria.SubCategorias = (new CapDao()).GetSubcategoriasPorCategoria(categoria.CategoriaId));
                //}

                foreach (CapCategoria categoria in categorias)
                {
                    var lsGroup = new ListViewGroup(categoria.Descricao);
                    lsGroup.Tag = categoria.CategoriaId;
                    lstVwCategorias.Groups.Add(lsGroup);

                    var subCategorias = (new CapDao()).GetSubcategoriasPorCategoria(categoria.CategoriaId);

                    foreach (CapSubcategoria sub in subCategorias)
                    {
                        var ls = new ListViewItem(sub.SubcategoriaId.ToString(), lsGroup);
                        ls.SubItems.Add(sub.Descricao);
                        //ls.ForeColor = Color.DarkBlue;

                        lstVwCategorias.Items.Add(ls);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void lstVwCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstVwCategorias_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstVwCategorias.SelectedItems.Count <= 0)
                return;

            btnExpandirCategoria_Click(sender, e);

            //Item ficará em evidência na lista
            lstVwCategorias.SelectedItems[0].Selected = true;
            lstVwCategorias.EnsureVisible(lstVwCategorias.SelectedItems[0].Index);
        }

        private void btnExpandirCategoria_Click(object sender, EventArgs e)
        {
            if (lstVwCategorias.Height == 105)
                lstVwCategorias.Height = 23;
            else
                lstVwCategorias.Height = 105;
        }

        private void lblSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}
