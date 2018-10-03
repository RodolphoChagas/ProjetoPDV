using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProjetoPDVModel;
using System.Windows.Forms;
using ProjetoPDVDao;

namespace ProjetoPDVUI
{
    public partial class frmVisualizaPedido : Form
    {
        private readonly Pedido _pedido;



        public frmVisualizaPedido(Pedido pedido)
        {

            _pedido = pedido;

            InitializeComponent();       
        }

        private void frmVisualizaPedido_Load(object sender, EventArgs e)
        {
            lblPedido.Text = "Pedido " + _pedido.NumDoc.ToString("000");
            lblTroco.Text = _pedido.Troco.ToString("0.00");
            lblTotal.Text = _pedido.ValorPedido.ToString("0.00");

            ListaProdutos();
            ListaPagamentos();
        }

        private void ListaPagamentos()
        {
            _pedido.Pagamentos = (new TipoPagamentoDao()).GetPagametosDoPedido(_pedido.NumDoc);

            var totalDinheiro = 0m;
            var totalCredito = 0m;
            var totalDebito = 0m;
            var totalOutros = 0m;

            foreach (var pagamento in _pedido.Pagamentos)
            {
                if (pagamento.CodigoNFCe.Equals(1))
                    totalDinheiro += pagamento.ValorPago;
                else if (pagamento.CodigoNFCe.Equals(3))
                    totalCredito += pagamento.ValorPago;
                else if (pagamento.CodigoNFCe.Equals(4))
                    totalDebito += pagamento.ValorPago;
                else if (pagamento.CodigoNFCe.Equals(99))
                    totalOutros += pagamento.ValorPago;
            }

            lblDinheiro.Text = totalDinheiro.ToString("0.00");
            lblCartaoCredito.Text = totalCredito.ToString("0.00");
            lblCartaoDebito.Text = totalDebito.ToString("0.00");
            lblOutros.Text = totalOutros.ToString("0.00");

            lblObservacao.Text = "Observação: " + _pedido.Pagamentos[0].Observacao; 
        }

        private void ListaProdutos()
        {

            try
            {
                _pedido.ItensDoPedido = (new PedidoItemDao()).GetItensDoPedido(_pedido.NumDoc);
                
                foreach (var item in _pedido.ItensDoPedido)
                {
                    item.Produto = (new ProdutoDao()).GetProduto(item.ProdutoId);

                    var ls = new ListViewItem(item.Produto.ProdutoId.ToString());
                    ls.SubItems.Add(item.Produto.Descricao);
                    ls.SubItems.Add(item.Quantidade.ToString("00"));
                    ls.SubItems.Add(item.ValorOriginalItem.ToString("0.00"));
                    ls.SubItems.Add(item.ValorTotal.ToString("0.00"));

                    lstVwProdutos.Items.Add(ls);                
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro inesperado ao listar os Produtos, tente novamente.");
            }
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVisualizaPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }
    }
}
