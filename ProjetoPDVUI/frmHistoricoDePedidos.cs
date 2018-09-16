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
    public partial class frmHistoricoDePedidos : Form
    {
        private List<Pedido> _pedidos;


        public frmHistoricoDePedidos()
        {
            InitializeComponent();
        }
        

        private void frmHistoricoDePedidos_Load(object sender, EventArgs e)
        {
            try
            {
                var dataAtual = DateTime.Now;

                _pedidos = (new PedidoDao()).GetPedidosDoCaixa(dataAtual, dataAtual);

                ListaPedidos(_pedidos);            
            }
            catch (Exception)
            {

            }
        }

        private void ListaPedidos(List<Pedido> pedidos)
        {
            lstVwPedidos.Items.Clear();

            foreach (var pedido in pedidos)
            {
                pedido.Cliente = (new ClienteDao()).GetClientePorPedido(pedido.NumDoc);
                var usuarioPedido = (new UsuarioDao()).GetUsuario(pedido.UsuarioId);
                                             

                var ls = new ListViewItem(pedido.NumDoc.ToString());
                ls.SubItems.Add(pedido.Cliente.Nome);
                ls.SubItems.Add(usuarioPedido.nomeUser);
                ls.SubItems.Add("Caixa");
                ls.SubItems.Add(pedido.DataDigitacao.ToString());
                ls.SubItems.Add(pedido.DataNFiscal.ToString());
                ls.SubItems.Add(pedido.ValorPedido.ToString("0.00"));

                if (pedido.NFiscal != 0)
                {
                    ls.ForeColor = Color.OliveDrab;
                }

                lstVwPedidos.Items.Add(ls);
            }
        }



        private void lblSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblVisualizarPedido_Click(object sender, EventArgs e)
        {
            if(lstVwPedidos.FocusedItem == null)
                return;

            var frmVisualizaPedido = new frmVisualizaPedido(_pedidos[lstVwPedidos.FocusedItem.Index]);
            frmVisualizaPedido.ShowDialog();
        }

        private void lblPesquisar_Click(object sender, EventArgs e)
        {
            _pedidos = (new PedidoDao()).GetPedidosDoCaixa(dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));

            ListaPedidos(_pedidos);
        }

        private void lstVwPedidos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstVwPedidos.FocusedItem == null)
                return;

            var frmVisualizaPedido = new frmVisualizaPedido(_pedidos[lstVwPedidos.FocusedItem.Index]);
            frmVisualizaPedido.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void frmHistoricoDePedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }
    }
}
