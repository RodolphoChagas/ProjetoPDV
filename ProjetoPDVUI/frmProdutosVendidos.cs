using ProjetoPDVDao;
using ProjetoPDVModel;
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
    public partial class frmProdutosVendidos : Form
    {
        private List<Produto> _produtos;




        public frmProdutosVendidos()
        {
            InitializeComponent();
        }

        private void ListaProdutos(List<Produto> produtos)
        {

            lstVwProdutos.Items.Clear();


            foreach (var produto in produtos)
            {

                var ls = new ListViewItem(produto.ProdutoId.ToString());
                ls.SubItems.Add(produto.Descricao);
                ls.SubItems.Add(produto.Estoque.ToString());
                ls.SubItems.Add(produto.PrecoDeVenda.ToString("0.00"));


                lstVwProdutos.Items.Add(ls);
            }

        }


        private void lblPesquisar_Click(object sender, EventArgs e)
        {
            _produtos = (new ProdutoDao()).GetProdutosVendidos(dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));


            ListaProdutos(_produtos);
        }

        private void frmProdutosVendidos_Load(object sender, EventArgs e)
        {
            var dataAtual = DateTime.Now;

            _produtos = (new ProdutoDao()).GetProdutosVendidos(dataAtual.ToString("yyyy-MM-dd 00:00:00"), dataAtual.ToString("yyyy-MM-dd 23:59:59"));


            ListaProdutos(_produtos);
        }
    }
}
