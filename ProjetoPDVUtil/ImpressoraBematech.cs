using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPDVModel;

namespace ProjetoPDVUtil
{
    public class ImpressoraBematech
    {
        private string Chr(int asc)
        {
            var ret = "";
            ret += (char)asc;
            return ret;
        }

        public static void Aciona_Gaveta()
        {
            const int charCode = 27;
            const int charCode2 = 118;
            const int charCode3 = 140;
            var specialChar = Convert.ToChar(charCode);
            var specialChar2 = Convert.ToChar(charCode2);
            var specialChar3 = Convert.ToChar(charCode3);

            var sCmdTx = "" + specialChar + specialChar2 + specialChar3;
            MP2032.ComandoTX(sCmdTx, sCmdTx.Length);
        }


        public static bool isImprimeDanfeNFCe(Pedido p, string urlQRCode)
        {
            decimal valDesc = 0;

            try
            {


                //CADA LINHA DO CUPOM CONTEM 50 COLUNAS COM LETRA NORMAL

                MP2032.BematechTX("\x1B\x61\x1"); //Centraliza

                //Informações do Cabeçalho
                MP2032.FormataTX(Emitente.GetInstancia.Nome + "\n", 2, 0, 0, 0, 1);
                //MP2032.FormataTX("CNPJ " + String.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToInt64(Emitente.getInstance.cnpj)) + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("CNPJ " + $@"{Convert.ToInt64(Emitente.GetInstancia.Cnpj):00\.000\.000\/0000\-00}" + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("R. Coronel Moreira Cesar, 26 - LJ 149, Icaraí, Niterói-RJ" + "\n", 1, 0, 0, 0, 0);
                MP2032.FormataTX("\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("Documento Auxiliar da Nota Fiscal de Consumidor Eletronica" + "\n", 1, 0, 0, 0, 0);
                MP2032.FormataTX("\n", 2, 0, 0, 0, 0);

                //Informações de detalhes de produtos/serviços
                MP2032.FormataTX("Codigo  Descricao        Qtd Un   Vl.Unit    Total" + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("-------------------------------------------------------------------", 1, 0, 0, 0, 0);

                //string strCodpro = string.Empty;
                string strDescricao = string.Empty;
                int totalItens = 0;
                for (int i = 0; i <= p.ItensDoPedido.Count - 1; i++)
                {

                    //if (p.ItensDoPedido[i].Produto.produto_loja.desconto > 0)// || p.lstPedidoItem[i].valitens > 0)
                    //{
                    //    //valDesc += (p.lstPedidoItem[i].prcitens * p.lstPedidoItem[i].qtditens) - p.lstPedidoItem[i].valitens;
                    //    //valDesc += p.lstPedidoItem[i].valDesc;
                    //    valDesc += decimal.Round(((p.ItensDoPedido[i].Produto.ValorDeVenda * p.ItensDoPedido[i].Quantidade) - p.ItensDoPedido[i].ValorTotal), 2);
                    //}


                    var codPro = p.ItensDoPedido[i].ProdutoId.ToString("00000");
                    totalItens += 1;

                    //var descricaoProduto = "";
                    //if (p.ItensDoPedido[i].Produto.Descricao.Length > 16)
                    //{
                    //    descricaoProduto = StringUtil.RemoverAcentos(p.ItensDoPedido[i].Produto.Descricao.Substring(0, 17));
                    //}
                    //else
                    //    descricaoProduto = StringUtil.RemoverAcentos(p.ItensDoPedido[i].Produto.Descricao.PadLeft(17, ' '));


                    var descricaoProduto = StringUtil.RemoverAcentos(p.ItensDoPedido[i].Produto.Descricao.Length > 16
                        ? p.ItensDoPedido[i].Produto.Descricao.Substring(0, 17)
                        : p.ItensDoPedido[i].Produto.Descricao.PadLeft(17, ' '));


                    MP2032.FormataTX(codPro + "   " + descricaoProduto.PadRight(17, ' ') +
                                     p.ItensDoPedido[i].Quantidade.ToString().PadLeft(3) + " UN" +
                                     p.ItensDoPedido[i].ValorOriginalItem.ToString("######0.00").Replace(".", ",").PadLeft(10, ' ') +
                                     p.ItensDoPedido[i].ValorTotal.ToString("######0.00").Replace(".", ",").PadLeft(9, ' '), 2, 0, 0, 0, 0);
                }
                //valDesc += p.dscdoc;


                MP2032.FormataTX("-------------------------------------------------------------------", 1, 0, 0, 0, 0);

                //Informações de Totais do DANFE NFC-e
                MP2032.FormataTX("QTD. TOTAL DE ITENS" + totalItens.ToString().PadLeft(31, ' '), 2, 0, 0, 0, 1);
                MP2032.FormataTX("VALOR TOTAL R$" + p.ValorPedido.ToString("######0.00").Replace(".", ",").PadLeft(36, ' '), 2, 0, 0, 0, 1);

                //Desconto
                if (valDesc > 0)
                    MP2032.FormataTX("DESCONTO R$" + valDesc.ToString("######0.00").Replace(".", ",").PadLeft(39, ' '), 2, 0, 0, 0, 1);

                
                //FORMA DE PAGAMENTO ==========================================================================================================

                MP2032.FormataTX("FORMA DE PAGAMENTO" + "VALOR PAGO R$".PadLeft(32, ' '), 2, 0, 0, 0, 1);

                p.Pagamentos.ForEach( pagamento => MP2032.FormataTX(pagamento.Descricao.PadRight(17, ' ') + pagamento.ValorPago.ToString("0.00").PadLeft(33, ' '), 2, 0, 0, 0, 0));

                if (p.Troco > 0)
                    MP2032.FormataTX("Troco".PadRight(17, ' ') + p.Troco.ToString().PadLeft(33, ' '), 2, 0, 0, 0, 0);

                MP2032.FormataTX("-------------------------------------------------------------------", 1, 0, 0, 0, 0);

                //=============================================================================================================================

                //Informações da consulta via chave de acesso
                MP2032.FormataTX("Consulte pela chave de acesso em" + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("http://nfce.fazenda.rj.gov.br/consulta" + "\n", 2, 0, 0, 0, 0);

                //* chave de acesso impressa em 11 blocos de quatro dígitos, com um espaço entre cada bloco
                int count = 0;
                string chavefinal = string.Empty;

                for (int x = 1; x <= 11; x++)
                {
                    chavefinal += p.Chave.Substring(count, 4).PadLeft(5, ' ');
                    count += 4;
                }
                MP2032.FormataTX(chavefinal.Trim() + "\n", 1, 0, 0, 0, 0);


                //Informações sobre o Consumidor
                MP2032.FormataTX("-------------------------------------------------------------------", 1, 0, 0, 0, 0);
                MP2032.FormataTX((p.Cliente.Nome.Trim() == "CONSUMIDOR NÃO IDENTIFICADO" ? p.Cliente.Nome : (p.Cliente.CnpjCpf.Trim().Length == 14 ? "CNPJ: " : "CPF: ") + p.Cliente.CnpjCpf.Trim()) + "\n", 2, 0, 0, 0, 1);
                MP2032.FormataTX("-------------------------------------------------------------------", 1, 0, 0, 0, 0);

                //Informações de Identificação da NFC-e e do Protocolo de Autorização
                //MP2032.FormataTX("NFC-e " + p.NFiscal.ToString().PadLeft(7, '0') + " Serie: 001 " + p.DataNFiscal?.ToString("dd/MM/yyyy HH:mm:ss") + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("NFC-e " + p.NFiscal.ToString().PadLeft(7, '0') + " Serie: 001 " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("Protocolo de Autorizacao: " + p.Protocolo + "\n", 2, 0, 0, 0, 0);

                //Informações da consulta via QR Code
                //MP2032.ImprimeCodigoQRCODE(1, 5, 0, 10, 1, "http://www4.fazenda.rj.gov.br/consultaNFCe/QRCode?chNFe=33171111500080000160650010000000301581809781&nVersao=100&tpAmb=2&dhEmi=323031372D31312D31345431313A30363A35342D30323A3030&vNF=151.92&vICMS=0.00&digVal=6B56723030544A4A59634F36534231595A62626D4C4230673561343D&cIdToken=000001&cHashQRCode=8576B480E0BDFFA96A064F65DBC977DCE0FB91B8");
                MP2032.ImprimeCodigoQRCODE(1, 5, 0, 10, 1, urlQRCode);
            

                //Área de Mensagem Fiscal
                MP2032.FormataTX("\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("Volte sempre!", 2, 0, 0, 0, 0);

                //Corta o papel parcialmente
                MP2032.AcionaGuilhotina(0);
                MP2032.FechaPorta();

            }
            catch (Exception)
            {
                return false;
            }


            return true;
        }




        public static bool isImprimeComprovante(Pedido pedido, decimal valorPagoEmDinheiro = 0)
        {

            var valorDesconto = 0;


            try
            {

                //CADA LINHA DO CUPOM CONTEM 50 COLUNAS COM LETRA NORMAL

                MP2032.BematechTX("\x1B\x61\x1"); //Centraliza

                //Informações do Cabeçalho
                MP2032.FormataTX(Emitente.GetInstancia.Nome + "\n", 2, 0, 0, 0, 1);
                //MP2032.FormataTX("CNPJ " + String.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToInt64(Emitente.GetInstancia.Cnpj)) + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("CNPJ " + $@"{Convert.ToInt64(Emitente.GetInstancia.Cnpj):00\.000\.000\/0000\-00}" + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("R. Coronel Moreira Cesar, 26 - LJ 149, Icaraí, Niterói-RJ" + "\n", 1, 0, 0, 0, 0);
                MP2032.FormataTX("\n", 2, 0, 0, 0, 0);
                //MP2032.FormataTX("Documento Auxiliar da Nota Fiscal de Consumidor Eletronica" + "\n", 1, 0, 0, 0, 0);
                MP2032.FormataTX("CUPOM  NAO  FISCAL" + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("\n", 2, 0, 0, 0, 0);

                //Informações de detalhes de produtos/serviços
                MP2032.FormataTX("Codigo  Descricao        Qtd Un   Vl.Unit    Total" + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("-------------------------------------------------------------------", 1, 0, 0, 0, 0);

                var totalItens = 0;
                for (var i = 0; i <= pedido.ItensDoPedido.Count - 1; i++)
                {

                    //if (Usuario.getInstance.loja.Equals(0))
                    //{
                    //    if (p.lstPedidoItem[i].produto.produto_loja.desconto > 0 || p.lstPedidoItem[i].valitens > 0)
                    //    {
                    //        //valDesc += (p.lstPedidoItem[i].prcitens * p.lstPedidoItem[i].qtditens) - p.lstPedidoItem[i].valitens;
                    //        //valDesc += p.lstPedidoItem[i].valDesc;
                    //        valDesc += decimal.Round(((p.lstPedidoItem[i].produto.prcvenda * p.lstPedidoItem[i].qtditens) - p.lstPedidoItem[i].valitens), 2);
                    //    }
                    //}

                    var codpro = pedido.ItensDoPedido[i].ProdutoId.ToString("00000");
                    totalItens += 1;

                    var descricaoProduto = StringUtil.RemoverAcentos(pedido.ItensDoPedido[i].Produto.Descricao.Length > 16
                        ? pedido.ItensDoPedido[i].Produto.Descricao.Substring(0, 17)
                        : pedido.ItensDoPedido[i].Produto.Descricao.PadLeft(17, ' '));


                    MP2032.FormataTX(codpro + "   " + descricaoProduto.PadRight(17, ' ') +
                                     pedido.ItensDoPedido[i].Quantidade.ToString().PadLeft(3) + " UN" +
                                     pedido.ItensDoPedido[i].ValorOriginalItem.ToString("######0.00").Replace(".", ",").PadLeft(10, ' ') +
                                     pedido.ItensDoPedido[i].ValorTotal.ToString("######0.00").Replace(".", ",").PadLeft(9, ' '), 2, 0, 0, 0, 0);
                }
                //valDesc += p.dscdoc;


                MP2032.FormataTX("-------------------------------------------------------------------", 1, 0, 0, 0, 0);


                //Informações de Totais do DANFE NFC-e
                MP2032.FormataTX("QTD. TOTAL DE ITENS" + totalItens.ToString().PadLeft(31, ' '), 2, 0, 0, 0, 1);
                MP2032.FormataTX("VALOR TOTAL R$" + pedido.ValorPedido.ToString("######0.00").Replace(".", ",").PadLeft(36, ' '), 2, 0, 0, 0, 1);


                //DESCONTO
                if (valorDesconto > 0)
                    MP2032.FormataTX("DESCONTO R$" + valorDesconto.ToString("######0.00").Replace(".", ",").PadLeft(39, ' '), 2, 0, 0, 0, 1);



                //FORMA DE PAGAMENTO ==========================================================================================================

                MP2032.FormataTX("FORMA DE PAGAMENTO" + "VALOR PAGO R$".PadLeft(32, ' '), 2, 0, 0, 0, 1);

                pedido.Pagamentos.ForEach(pagamento => MP2032.FormataTX(pagamento.Descricao.PadRight(17, ' ') + pagamento.ValorPago.ToString("0.00").PadLeft(33, ' '), 2, 0, 0, 0, 0));

                if (pedido.Troco > 0)
                    MP2032.FormataTX("Troco".PadRight(17, ' ') + pedido.Troco.ToString().PadLeft(33, ' '), 2, 0, 0, 0, 0);

                MP2032.FormataTX("-------------------------------------------------------------------", 1, 0, 0, 0, 0);

                //=============================================================================================================================



                //Área de Mensagem Fiscal
                MP2032.FormataTX("\n\n\n\n\n\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("Volte sempre! \n", 2, 0, 0, 0, 0);

                //Corta o papel parcialmente
                MP2032.AcionaGuilhotina(0);
                MP2032.FechaPorta();

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
