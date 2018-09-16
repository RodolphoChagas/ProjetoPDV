using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVModel
{
    public class Email
    {

        public void Email_ConferenciaCaixa(List<PedidoItem> lstProdutosdoMes, Caixa caixa, decimal totalDinheiroDoDia, decimal totalDebitoDoDia, decimal totalCreditoDoDia, decimal totalOutrosDoDia, List<Pedido> pedidosDoMes, int countPedidosDoDia) //, Movimentacao movimentacao)
        {

            MailMessage mail = new MailMessage();
            StringBuilder cabecalho = new StringBuilder();
            StringBuilder produto = new StringBuilder();
            StringBuilder itens = new StringBuilder();
            StringBuilder perdas = new StringBuilder();
            StringBuilder total = new StringBuilder();

            int iTotalqtd = 0;
            int iTotalqtdAcumulado = 0;
            decimal totalValor = 0;

            try
            {

                cabecalho.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
                cabecalho.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
                cabecalho.Append("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>");
                cabecalho.Append("<style> h4, h3, p, table, td, tr {margin:0px; padding:0px;}");
                cabecalho.Append("p, table, td, tr {color:#333333; font:10px Verdana, Arial, Helvetica, sans-serif ;}");
                cabecalho.Append("table {background:#e9e9e6; border-collapse:collapse;}");
                cabecalho.Append("td {padding:4px;} table.produtos td {border:2px solid #FFFFFF; background-color:#eeeee8;}");
                cabecalho.Append("table.produtos tr.topo td {background-color:#CCCCCC; color:#FFFFFF;}");
                cabecalho.Append("td.branc {background-color:#FFFFFF;} table#estado td {font-size:9px;}</style>");
                cabecalho.Append("<body><table width='650' align='center' bgcolor='#e9e9e6'>");
                cabecalho.Append("<tr><td width='149'><h4>Succo</h4></td><td width='200'>&nbsp;</td><td width='119'>Data:" + DateTime.Now + "</td></tr>");
                cabecalho.Append("<tr><td height='60' colspan='3'><center><h2>Relatório de Conferência de Caixa</h2></center></td></tr></table><br />");


                produto.Append("<table width='650' align='center' bgcolor='#e9e9e6'><tr><td width='30'><b>Loja:</b></td><td width='452'>Succo</td><td width='131'>&nbsp;</td>");
                produto.Append("<tr><td height='30' colspan='3'><center><h3>Lista de itens vendidos do dia</h3></center></td></tr></table>");

                produto.Append("<table width='650' class='produtos' align='center' bgcolor='#CCCCCC'>");
                produto.Append("<tr class='topo'><td width='429'><b>Descrição</b></td>");
                produto.Append("<td width='46'><center><b>Qtd.</b></center></td>");
                produto.Append("<td width='100'><center><b>Acumulado do Mês(Qtd)</b></center></td>");
                produto.Append("<td width='100'><center><b>Acumulado do Mês(R$)</b></center></td>");

                for (int i = 0; i <= lstProdutosdoMes.Count - 1; i++)
                {
                    //lstPItem[i].produto = pdao.getProduto(lstPItem[i].codpro);
                    itens.Append("<tr bgcolor='#eeeee8'><td>" + lstProdutosdoMes[i].Produto.Descricao + "</td><td><center>" + lstProdutosdoMes[i].Quantidade + "</center></td><td><center>" + lstProdutosdoMes[i].NumDoc + "</center></td><td><center>" + lstProdutosdoMes[i].ValorTotal.ToString("0.00") + "</center></td></tr>");
                }
                itens.Append("</table><br />");



                perdas.Append("<table width='650' align='center' bgcolor='#e9e9e6'><tr><td width='30'><b>Loja:</b></td><td width='452'>Succo</td><td width='131'>&nbsp;</td>");
                perdas.Append("<tr><td height='30' colspan='3'><center><h3>Fechamento do Caixa</h3></center></td></tr></table>");

                perdas.Append("<table width='650' class='produtos' align='center' bgcolor='#CCCCCC'>");
                perdas.Append("<tr class='topo'><td width='575'><b>Descrição</b></td>");
                perdas.Append("<td width='100'><center><b>Valor</b></center></td>");
                //perdas.Append("<tr class='topo'><td width='429'><b>Descrição</b></td>");
                //perdas.Append("<td width='46'><center><b>Qtd.</b></center></td>");
                //perdas.Append("<td width='100'><center><b>Acumulado do Mês(Qtd)</b></center></td>");
                //perdas.Append("<td width='100'><center><b>Acumulado do Mês(R$)</b></center></td>");

                perdas.Append("<tr bgcolor='#eeeee8'><td>SALDO INICIAL</td><td><center>" + caixa.SaldoInicial.ToString("0.00") + "</center></td></tr>");
                perdas.Append("<tr bgcolor='#eeeee8'><td>Total de vendas em dinheiro</td><td><center>" + caixa.VendaEmDinheiro.ToString("0.00") + "</center></td></tr>");
                perdas.Append("<tr bgcolor='#eeeee8'><td>Total de Sangrias</td><td><center>" + caixa.Sangria.ToString("0.00") + "</center></td></tr>");
                perdas.Append("<tr bgcolor='#eeeee8'><td>SALDO FINAL do caixa no sistema</td><td><center>" + caixa.SaldoFinalSistema.ToString("0.00") + "</center></td></tr>");
                perdas.Append("<tr bgcolor='#eeeee8'><td>SALDO FINAL do caixa informado pelo usuário</td><td><center>" + caixa.SaldoFinalCaixa.ToString("0.00") + "</center></td></tr>");
                perdas.Append("<tr bgcolor='#eeeee8'><td>Diferença</td><td><center>" + caixa.Diferenca.ToString("0.00") + "</center></td></tr>");


                perdas.Append("</table><br />");

                

                total.Append("<table width='650' align='center' bgcolor='#e9e9e6'><tr><td height='30' colspan='3'><center><h3>Total Geral</h3></center></td></tr></table>");

                total.Append("<table width='650' class='produtos' align='center' bgcolor='#CCCCCC'>");
                total.Append("<tr class='topo'><td width='350'><b>Tipo de Pagamento</b></td>");
                total.Append("<td width='100'><center><b>Vendas do Dia(R$)</b></center></td>");
                total.Append("<td width='100'><center><b>Acumulado do Mês(R$)</b></center></td>");
                total.Append("<td width='100'><center><b>%</b></center></td>");


                var totalDinheiroDoMes = 0m;
                var totalDebitoDoMes = 0m;
                var totalCreditoDoMes = 0m;
                var totalOutrosDoMes = 0m;

                var countPedidosDoMes = 0;

                foreach (var pedido in pedidosDoMes)
                {
                    foreach (TipoPagamento pagamento in pedido.Pagamentos)
                    {
                        if (pedido.Operacao.VND == 1)
                        {
                            if (pagamento.CodigoNFCe.Equals(1))
                                totalDinheiroDoMes += (pagamento.ValorPago - pedido.Troco);
                            else if (pagamento.CodigoNFCe.Equals(3))
                                totalCreditoDoMes += pagamento.ValorPago;
                            else if (pagamento.CodigoNFCe.Equals(4))
                                totalDebitoDoMes += pagamento.ValorPago;
                            else if (pagamento.CodigoNFCe.Equals(99))
                                totalOutrosDoMes += pagamento.ValorPago;

                            countPedidosDoMes += 1;
                        }
                    }
                }

                var totalDoMes = (totalDinheiroDoMes + totalDebitoDoMes + totalCreditoDoMes + totalOutrosDoMes);
                var totalDoDia = (totalDinheiroDoDia + totalDebitoDoDia + totalCreditoDoDia + totalOutrosDoDia);

                total.Append("<tr bgcolor='#eeeee8'><td>Dinheiro</td><td><center>" + totalDinheiroDoDia.ToString("0.00") + "</center></td><td><center>" + totalDinheiroDoMes.ToString("0.00") + "</center></td><td><center>" + Math.Round(((totalDinheiroDoMes * 100) / totalDoMes), 2) + "% </center></td></tr>");
                total.Append("<tr bgcolor='#eeeee8'><td>Cartão de Débito</td><td><center>" + totalDebitoDoDia.ToString("0.00") + "</center></td><td><center>" + totalDebitoDoMes.ToString("0.00") + "</center></td><td><center>" + Math.Round(((totalDebitoDoMes * 100) / totalDoMes), 2) + "% </center></td></tr>");
                total.Append("<tr bgcolor='#eeeee8'><td>Cartão de Crédito</td><td><center>" + totalCreditoDoDia.ToString("0.00") + "</center></td><td><center>" + totalCreditoDoMes.ToString("0.00") + "</center></td><td><center>" + Math.Round(((totalCreditoDoMes * 100) / totalDoMes), 2) + "% </center></td></tr>");
                total.Append("<tr bgcolor='#eeeee8'><td>Outros</td><td><center>" + totalOutrosDoDia.ToString("0.00") + "</center></td><td><center>" + totalOutrosDoMes.ToString("0.00") + "</center></td><td><center>" + Math.Round(((totalOutrosDoMes * 100) / totalDoMes), 2) + "% </center></td></tr>");

                total.Append("<tr bgcolor='#eeeee8'><td><b>Total</b></td><td><b><center>" + totalDoDia + "</center></b></td><td><b><center>" + totalDoMes.ToString("0.00") + "</center></b></td><td><b><center>100 %</center></b></td></tr>");
                total.Append("<tr bgcolor='#eeeee8'><td><b>Ticket Médio</b></td><td><b><center>" + (totalDoDia / countPedidosDoDia).ToString("0.00") + "</center></b></td><td><b><center>" + (totalDoMes / countPedidosDoMes).ToString("0.00") + "</center></b></td><td><b><center>---</center></b></td></tr>");

                total.Append("</table><br />");



                cabecalho.Append(produto.Append(itens).Append(perdas).Append(total));



                var fromAddress = new MailAddress("programacao@impetus.com.br", "Succo (Fechamento de Caixa)");
                //var toAddress = new MailAddress("rodolphochagas@hotmail.com", "Rodolpho");
                const string fromPassword = "impetus456";
                const string subject = "Relatório de fechamento e conferência de caixa";
                string body = cabecalho.ToString();

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                using (var message = new MailMessage() { Priority = MailPriority.High, IsBodyHtml = true, Subject = subject, Body = body })
                {
                    message.To.Add(new MailAddress("ingrid@impetus.com.br", "Ingrid Ney"));
                    message.To.Add(new MailAddress("marcelo.fargnoli@globo.com", "Marcelo"));
                    message.To.Add(new MailAddress("rodolphochagas@hotmail.com", "Rodolpho"));
                    message.From = fromAddress;

                    smtp.Send(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cabecalho = null;
                produto = null;
                itens = null;
                total = null;
                mail = null;
            }
        }
    }
}
