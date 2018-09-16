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
    public partial class frmMovimento : Form
    {
        private List<Pedido> _pedidos;
        private string _statustNFCe;

        decimal val_Dinheiro = 0;
        decimal val_CCredito = 0;
        decimal val_CDebito = 0;
        decimal val_Outros = 0;



        public frmMovimento()
        {
            InitializeComponent();
        }

        private void frmMovimento_Load(object sender, EventArgs e)
        {

        }

        private void frmMovimento_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void frmMovimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }

        private void cmdLocalizar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            lstvwPedidos.Items.Clear();
            lstItens.Items.Clear();
            _pedidos.Clear();

            lblAutorizado.Text = "000";
            lblCancelado.Text = "000";


            if (cboProcurar.SelectedIndex != 0 & txtProcurar.Text == string.Empty)
            {
                MessageBox.Show("Digite o (" + cboProcurar.Text + ") por favor.", "Mensagem - Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                return;
            }

            if (cboProcurar.SelectedIndex == 0 & (dtInicial.Checked == false || dtFinal.Checked == false))
            {
                MessageBox.Show("Entre com a (" + cboProcurar.Text + ") por favor.", "Mensagem - Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                return;
            }

            string strWhere = string.Empty;

            try
            {
                switch (cboProcurar.Text)
                {
                    case "Data da Nota Fiscal":

                        //if (cboFormaPagamento.Text != "Todos")
                        //{
                        //    strWhere = "TipoPgto = " + cboFormaPagamento.SelectedValue;
                        //}

                        if (cboStatus.Text != "Todos")
                        {
                            if (strWhere != string.Empty)
                            {
                                strWhere += " And status_nfce = " + _statustNFCe;
                            }
                            else
                                strWhere += "status_nfce = " + _statustNFCe;
                        }


                        _pedidos = (new PedidoDao()).GetPedidos(Convert.ToInt32(cboUsuario.SelectedValue), string.Format("{0:yyyy-MM-dd 00:00:00}", dtInicial.Value), string.Format("{0:yyyy-MM-dd 23:59:59}", dtFinal.Value), strWhere);


                        break;


                    case "N° da Nota Fiscal":
                        _pedidos.Add((new PedidoDao()).GetPedido(txtProcurar.Text));
                        break;
                    case "N° do Pedido":
                        _pedidos.Add((new PedidoDao()).GetPedido(Convert.ToInt32(txtProcurar.Text)));
                        break;
                }


                if (_pedidos.Count == 0)
                {
                    MessageBox.Show("Pedido(s) não encontrado(s)!", "Mensagem - Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _pedidos.Clear();
                    lstItens.Items.Clear();
                    cmdExportaXML.Enabled = false;
                    TxtChaveNFe.Text = string.Empty;
                    TxtNumProtocolo.Text = string.Empty;
                    Cursor = Cursors.Default;
                    return;
                }

                if (_pedidos[0] == null)
                {
                    MessageBox.Show("Pedido(s) não encontrado(s)!", "Mensagem - Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _pedidos.Clear();
                    lstItens.Items.Clear();
                    cmdExportaXML.Enabled = false;
                    TxtChaveNFe.Text = string.Empty;
                    TxtNumProtocolo.Text = string.Empty;
                    this.Cursor = Cursors.Default;
                    return;
                }


                ListaPedidos();
                cmdExportaXML.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }



        private void ListaPedidos()
        {
            try
            {
                int iPendentes = 0;

                val_Dinheiro = 0;
                val_CCredito = 0;
                val_CDebito = 0;
                val_Outros = 0;

                timer1.Enabled = false;
                lblPendente.Text = "";
                lbl.Text = "";

                foreach (Pedido pedido in _pedidos)
                {
                    pedido.Operacao = (new OperacaoDao()).GetOperacaoPorPedido(pedido.NumDoc);
                    pedido.ItensDoPedido = (new PedidoItemDao()).GetItensDoPedido(pedido.NumDoc);
                    //pedido.tipoPgto = (new TipoPagamentoDAO()).getTipoPagamento(pedido.numdoc.ToString());
                    pedido.Cliente = (new ClienteDao()).GetClientePorPedido(pedido.NumDoc);
                    pedido.ClienteId = pedido.Cliente.ClienteId;
                    pedido.Xml = (new XmlDao()).GetArquivoXml(pedido.NumDoc);



                    foreach (PedidoItem pedidoitem in pedido.ItensDoPedido)
                    {
                        pedidoitem.Produto = (new ProdutoDao()).GetProduto(pedidoitem.ProdutoId);

                        //if (pedidoitem.produto.codgrupo.Equals(0))
                        //{
                        //    ploja = plDao.getProduto_Loja(pedidoitem.produto.codpro);
                        //}
                        //else
                        //{
                        //    ploja.codpro = pedidoitem.produto.codpro;
                        //    ploja.desconto = 0;
                        //    ploja.estatus = 0;
                        //    ploja.site = 1;
                        //}

                        //pedidoitem.produto.produto_loja = ploja;
                        //ploja = new Produto_Loja();

                        pedidoitem.Produto.GrupoFiscal = (new ProdutoGrupoFiscalDao()).GetGrupoFiscalPorProduto(pedidoitem.Produto.ProdutoId);
                    }

                    ListViewItem ls = new ListViewItem(pedido.NumDoc.ToString());
                    ls.SubItems.Add(pedido.NFiscal.ToString());
                    ls.SubItems.Add(pedido.DataDigitacao.ToString());
                    ls.SubItems.Add(pedido.DataNFiscal.ToString());
                    ls.SubItems.Add(pedido.Operacao.Nome);
                    ls.SubItems.Add(pedido.ValorPedido.ToString("0.00"));
                    //ls.SubItems.Add(pedido.tipoPgto.descTipoPgto);
                    ls.SubItems.Add("TIPO DE PAGAMENTO");


                    //if (pedido.StatusNFCe == null || pedido.StatusNFCe.Trim().Equals("0"))
                    //{
                    //    ls.SubItems.Add("NFC-e Pendente");

                    //    lblPendente.Text = "Pendentes (" + (iPendentes += 1) + ")";
                    //    lbl.Text = "!";
                    //    lblPendente.Visible = true;
                    //    lbl.Visible = true;
                    //    timer1.Enabled = true;
                    //}
                    //else if (pedido.StatusNFCe.Trim().Equals("102"))
                    //{
                    //    ls.SubItems.Add("NFC-e Inutilizada");
                    //    Colore_itemListView(ls, Color.Silver);
                    //}
                    //else if (pedido.StatusNFCe.Trim().Equals("100"))
                    //{
                    //    ls.SubItems.Add("NFC-e Autorizada");
                    //    Colore_itemListView(ls, Color.OliveDrab);

                    //    lblAutorizado.Text = (Convert.ToInt16(lblAutorizado.Text) + 1).ToString("000");
                    //}
                    //else if (pedido.StatusNFCe.Trim().Equals("135"))
                    //{
                    //    ls.SubItems.Add("NFC-e Cancelada");
                    //    Colore_itemListView(ls, Color.Brown);

                    //    lblCancelado.Text = (Convert.ToInt16(lblCancelado.Text) + 1).ToString("000");
                    //}

                    ls.SubItems.Add(pedido.Chave);
                    ls.SubItems.Add(pedido.Protocolo);
                    //ls.SubItems.Add(pedido.codvendedor == 104 ? "LIVRARIA" : "CAFETERIA");
                    ls.SubItems.Add("TIPO VENDEDOR");
                    ls.UseItemStyleForSubItems = false;


                    //if (ls.SubItems[10].Text == "CAFETERIA")
                    //    ls.SubItems[10].ForeColor = System.Drawing.Color.SaddleBrown;
                    //else
                    //    ls.SubItems[10].ForeColor = System.Drawing.Color.Chocolate;


                    Calcula_Totais(pedido);
                    lstvwPedidos.Items.Add(ls);
                }

                lblVal_Dinheiro.Text = val_Dinheiro.ToString("0.00");
                lblVal_CDebito.Text = val_CDebito.ToString("0.00");
                lblVal_CCredito.Text = val_CCredito.ToString("0.00");
                lblVal_Outros.Text = val_Outros.ToString("0.00");

                lblval_Total.Text = (val_Dinheiro + val_CDebito + val_CCredito + val_Outros).ToString("0.00");
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void Calcula_Totais(Pedido p)
        {
            ////Dinheiro
            //if (p.tipoPgto.codTipoPgto.Equals(9))
            //{
            //    val_Dinheiro += p.valdoc;
            //}
            //else if (p.tipoPgto.codFormaPgtoNFCe.Equals(3))
            //{
            //    val_CCredito += p.valdoc;
            //}
            //else if (p.tipoPgto.codFormaPgtoNFCe.Equals(4))
            //{
            //    val_CDebito += p.valdoc;
            //}
            //else
            //{
            //    val_Outros += p.valdoc;
            //}
        }


        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.Text == "Autorizadas")
            {
                _statustNFCe = "100";
            }
            else if (cboStatus.Text == "Canceladas")
            {
                _statustNFCe = "135";
            }
            else if (cboStatus.Text == "Inutilizadas")
            {
                _statustNFCe = "102";
            }
            else if (cboStatus.Text == "Pendentes")
            {
                _statustNFCe = "0";
            }
        }
    }
}
