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

                GeraXml.AmbienteNFCe = "1";

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

                var dataInicial = new DateTime(2018, 10, 03);
                var dataFinal = new DateTime(2018, 10, 03);

                var pedidos = (new PedidoDao()).GetPedidosDoCaixa(dataInicial, dataFinal);

                foreach (var pedido in pedidos)
                {


                    pedido.DataDigitacao = DateTime.Now;


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
                    var GravaXml = File.CreateText(@"C:\Users\Succo\Desktop\xmlGerado.xml");
                    GravaXml.Write(xml.InnerXml);
                    GravaXml.Close();

                    //Assinando XML
                    var xmlAssinado = (new AssinaXml()).AssinaXML(xml.InnerXml, "infNFe", CertificadoDigital.getInstance.oCertificado);
                    var GravaXmlAssinado = File.CreateText(@"C:\Users\Succo\Desktop\xmlAssinado.xml");
                    GravaXmlAssinado.Write(xmlAssinado.InnerXml);
                    GravaXmlAssinado.Close();


                    //Validando XML
                    try
                    {
                        // Validando o XML
                        var retValidar = (new ValidaXml()).Valida(xmlAssinado, "NFe");

                        //Inserindo a URL QRCode no xml já assinado
                        xmlAssinado.LoadXml(xmlAssinado.InnerXml.Replace("</infNFe>", "</infNFe><infNFeSupl><qrCode><![CDATA[" +
                        geraXml.GetUrlQRCode(xmlAssinado, pedido) + "]]></qrCode><urlChave>http://www4.fazenda.rj.gov.br/consultaNFCe/QRCode</urlChave></infNFeSupl>"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("** Erro ao validar **");
                        Console.WriteLine(ex.Message);
                    }

                    var GravaXmlAssinadoComQrCode = File.CreateText(@"C:\Users\Succo\Desktop\xmlAssinadoComQrCode.xml");
                    GravaXmlAssinadoComQrCode.Write(xmlAssinado.InnerXml);
                    GravaXmlAssinadoComQrCode.Close();



                    var retornoDaTransmicao = (new TransmiteXml()).XML_NFCe4(xmlAssinado, pedido.NFiscal.ToString(), CertificadoDigital.getInstance.oCertificado);

                    if (retornoDaTransmicao.Substring(0, 4) != "Erro")
                    {
                        var xmlRetorno = new XmlDocument();
                        xmlRetorno.LoadXml(retornoDaTransmicao);

                        var GravaXmlTransmitido = File.CreateText(@"C:\Users\Succo\Desktop\xmlTransmitido.xml");
                        GravaXmlTransmitido.Write(xmlRetorno.InnerXml);
                        GravaXmlTransmitido.Close();

                        // Lote processado
                        if (xmlRetorno.GetElementsByTagName("cStat")[0].InnerText == "104")
                        {
                            // Autorizado
                            if (xmlRetorno.GetElementsByTagName("cStat")[1].InnerText == "100")
                            {
                                pedido.Chave = xmlRetorno.GetElementsByTagName("chNFe")[0].InnerText;
                                pedido.Protocolo = xmlRetorno.GetElementsByTagName("nProt")[0].InnerText;

                                // Separar somente o conteúdo a partir da tag <protNFe> até </protNFe>
                                var nPosI = retornoDaTransmicao.IndexOf("<protNFe");
                                var nPosF = retornoDaTransmicao.Length - (nPosI + 13);
                                var strProc = retornoDaTransmicao.Substring(nPosI, nPosF);


                                // XML pronto para salvar
                                var strXmlProcNfe = @"<?xml version=""1.0"" encoding=""utf-8"" ?><nfeProc xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""4.00"">" + xmlAssinado.InnerXml + strProc + "</nfeProc>";

                                pedido.Xml = new Xml()
                                {
                                    NumDoc = pedido.NumDoc,
                                    ArquivoXml = strXmlProcNfe,
                                    Data = DateTime.Now,
                                    Modelo = pedido.ModeloNFiscal,
                                    StatNFCe = "100"
                                };



                                using (var db = new Database("stringConexao"))
                                {
                                    db.BeginTransaction();

                                    try
                                    {
                                        db.Update("Update Controle Set NFiscal=" + pedido.NFiscal + " Where ChvControle = 1");
                                        db.Update("Update Movdb Set data_nfiscal = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', NFiscal= " + pedido.NFiscal + ", Chave='" + pedido.Chave + "' ,Protocolo='" + pedido.Protocolo + "', status_nfce = '" + pedido.Xml.StatNFCe + "' Where NumDoc = " + pedido.NumDoc);

                                        db.CompleteTransaction();
                                    }
                                    catch (Exception)
                                    {
                                        db.AbortTransaction();
                                    }

                                    if (!string.IsNullOrEmpty(ControleFiscal.GetInstance.CaminhoXmlAutorizado))
                                    {
                                        //Salvando o arquivo XML na pasta
                                        var Grava = File.CreateText(ControleFiscal.GetInstance.CaminhoXmlAutorizado.Remove(ControleFiscal.GetInstance.CaminhoXmlAutorizado.Length - 1) + DateTime.Now.Month + @"\" + pedido.Chave + "-procNfe.xml");
                                        Grava.Write(pedido.Xml.ArquivoXml);
                                        Grava.Close();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Erro no lote");
                        }
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
