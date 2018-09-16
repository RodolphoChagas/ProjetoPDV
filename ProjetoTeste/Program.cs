using PetaPoco;
using ProjetoPDVDao;
using ProjetoPDVModel;
using ProjetoPDVServico;
using ProjetoPDVUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjetoTeste
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                using (var db = new Database("stringConexao"))
                {
                    db.BeginTransaction();

                    try
                    {
                        db.Update("Update Movdb Set data_nfiscal = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' Where NumDoc = 64");

                        db.CompleteTransaction();
                    }
                    catch (Exception)
                    {
                        db.AbortTransaction();
                    }
                }


                return;

                CertificadoDigital.getInstance.Seleciona_Certificado();



                MP2032.ConfiguraModeloImpressora(7); // Bematech MP-4200 TH
                MP2032.IniciaPorta("USB");



                var codigoRetorno = MP2032.Le_Status();
                if (codigoRetorno == 0)
                {
                    //MessageBox.Show("Erro ao se comunicar com a Impressora Bematech MP-4200 TH, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (codigoRetorno == 5)
                {
                    //MessageBox.Show("Impressora com pouco papel, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (codigoRetorno == 9)
                {
                    //MessageBox.Show("Impressora com a tampa aberta, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MP2032.FechaPorta();
                    return;
                }
                else if (codigoRetorno == 32)
                {
                    //MessageBox.Show("Impressora sem papel, verifique por favor.", "** ATENÇÃO **", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }




                MP2032.BematechTX("\x1B\x61\x1"); //Centraliza

                

                //Informações do Cabeçalho
                MP2032.FormataTX(Emitente.GetInstancia.Nome + "\n", 2, 0, 0, 0, 1);
                //MP2032.FormataTX("CNPJ " + String.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToInt64(Emitente.getInstance.cnpj)) + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("CNPJ " + $@"{Convert.ToInt64(Emitente.GetInstancia.Cnpj):00\.000\.000\/0000\-00}" + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("Av. Amaral Peixoto, 507 - LJ05, Centro, Niterói-RJ" + "\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("\n", 2, 0, 0, 0, 0);
                MP2032.FormataTX("Documento Auxiliar da Nota Fiscal de Consumidor Eletronica" + "\n", 1, 0, 0, 0, 0);
                MP2032.FormataTX("\n", 2, 0, 0, 0, 0);



                //Corta o papel parcialmente
                MP2032.AcionaGuilhotina(0);
                MP2032.FechaPorta();



                return;

                GeraXml.AmbienteNFCe = "2";

                CertificadoDigital.getInstance.Seleciona_Certificado();
                (new EmitenteDao()).SelecionaEmitente();

                var control = (new ControleFiscalDao()).getControle();
                if (control != null)
                {
                    ControleFiscal.GetInstance.TokenHomologacao = control.TokenHomologacao;
                    ControleFiscal.GetInstance.TokenProducao = control.TokenProducao;
                    ControleFiscal.GetInstance.CaminhoXmlAutorizado = control.CaminhoXmlAutorizado;
                    ControleFiscal.GetInstance.CaminhoXmlCancelado = control.CaminhoXmlCancelado;
                    ControleFiscal.GetInstance.CaminhoXmlInutilizado = control.CaminhoXmlInutilizado;

                    control = null;
                }


                var pedido = (new PedidoDao()).GetPedido(27);
                pedido.NFiscal = (new ControleFiscalDao()).GetUltimoNumeroNFiscalGerado() + 1;

                pedido.Cliente = (new ClienteDao()).GetClienteConsumidorNaoIdentificado();
                pedido.Operacao = (new OperacaoDao()).GetOperacaoPorPedido(pedido.NumDoc);
                pedido.Pagamentos = (new TipoPagamentoDao()).GetPagametosDoPedido(pedido.NumDoc);

                pedido.ItensDoPedido = (new PedidoItemDao()).GetItensDoPedido(pedido.NumDoc);
                pedido.ItensDoPedido.ForEach(pedidoItem =>
               {
                   pedidoItem.Produto = (new ProdutoDao().GetProduto(pedidoItem.ProdutoId));
                   pedidoItem.Produto.GrupoFiscal = (new ProdutoGrupoFiscalDao()).GetGrupoFiscalPorProduto(pedidoItem.ProdutoId);
               });

                var geraXml = new GeraXml();

                //Gerando XML
                var xml = geraXml.GeraXmlNFCe(pedido);
                var GravaXml = File.CreateText(@"C:\Users\Renan\Desktop\xmlGerado.xml");
                GravaXml.Write(xml.InnerXml);
                GravaXml.Close();

                //Assinando XML
                var xmlAssinado = (new AssinaXml()).AssinaXML(xml.InnerXml, "infNFe", CertificadoDigital.getInstance.oCertificado);
                var GravaXmlAssinado = File.CreateText(@"C:\Users\Renan\Desktop\xmlAssinado.xml");
                GravaXmlAssinado.Write(xmlAssinado.InnerXml);
                GravaXmlAssinado.Close();


                //Validando XML
                try
                {
                    // Validando o XML
                    var retValidar = (new ValidaXml()).Valida(xmlAssinado, "NFe");

                    //Inserindo a URL QRCode no xml já assinado
                    xmlAssinado.LoadXml(xmlAssinado.InnerXml.Replace("</infNFe>", "</infNFe><infNFeSupl><qrCode><![CDATA[" +
                    geraXml.GetUrlQRCode(xmlAssinado, pedido) + "]]></qrCode></infNFeSupl>"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("** Erro ao validar **");
                    Console.WriteLine(ex.Message);
                }

                var GravaXmlAssinadoComQrCode = File.CreateText(@"C:\Users\Renan\Desktop\xmlAssinadoComQrCode.xml");
                GravaXmlAssinadoComQrCode.Write(xmlAssinado.InnerXml);
                GravaXmlAssinadoComQrCode.Close();



                var retornoDaTransmicao = (new TransmiteXml()).XML_NFCe(xmlAssinado, pedido.NFiscal.ToString(), CertificadoDigital.getInstance.oCertificado);

                if (retornoDaTransmicao.Substring(0, 4) != "Erro")
                {
                    var xmlRetorno = new XmlDocument();
                    xmlRetorno.LoadXml(retornoDaTransmicao);

                    var GravaXmlTransmitido = File.CreateText(@"C:\Users\Renan\Desktop\xmlTransmitido.xml");
                    GravaXmlTransmitido.Write(xmlRetorno.InnerText);
                    GravaXmlTransmitido.Close();

                    // Lote processado
                    if (xmlRetorno.GetElementsByTagName("cStat")[0].InnerText == "104")
                    {
                        // Autorizado
                        if (xmlRetorno.GetElementsByTagName("cStat")[1].InnerText == "100")
                        {
                            Console.WriteLine("FOI CARALHOOO!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Erro no lote");
                    }
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }




        }
    }
}
