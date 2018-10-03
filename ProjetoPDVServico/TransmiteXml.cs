using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ProjetoPDVServico
{
    public class TransmiteXml
    {


        private XmlDocument xmlLote;
        private XmlNode xmlDados;
        private string TextoXML;


        public TransmiteXml()
        {
        }


        private void ServicePoint()
        {
            ServicePointManager.ServerCertificateValidationCallback
            += new RemoteCertificateValidationCallback(AllwaysGoodCertificate);
        }

        private static bool AllwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }


        public string XML_NFCe4(XmlDocument xmlAssinado, string nfiscal, X509Certificate2 _X509Cert)
        {
            try
            {
                var geraXml = new GeraXml();

                //Gerando o xml de Lote
                xmlLote = geraXml.GeraXmlDeLote(xmlAssinado, nfiscal);

                xmlDados = xmlLote.DocumentElement;


                ServicePoint();

                if (GeraXml.AmbienteNFCe == "1")
                {
                    //NFCeRecepcaoP - PRODUCAO  /  NFCeRecepcaoH - HOMOLOGACAO
                    NFCeAutorizacao4P.NFeAutorizacao4 WsHRecepcao = new NFCeAutorizacao4P.NFeAutorizacao4();

                    WsHRecepcao.ClientCertificates.Add(_X509Cert);
                    WsHRecepcao.Timeout = Convert.ToInt32(240000);
                    WsHRecepcao.InitializeLifetimeService();

                    //NFCeAutorizacaoP.nfeCabecMsg cabec = new NFCeAutorizacaoP.nfeCabecMsg();
                    //cabec.cUF = "33";
                    //cabec.versaoDados = "3.10";
                    //WsHRecepcao.nfeCabecMsgValue = cabec;
                    TextoXML = WsHRecepcao.nfeAutorizacaoLote(xmlDados).OuterXml;
                    WsHRecepcao.Dispose();

                }
                else
                {
                    //NFeRecepcaoP - PRODUCAO  /  NFeRecepcaoH - HOMOLOGACAO
                    //NFCeAutorizacao4H.NFeAutorizacao4 WsHRecepcao = new NFCeAutorizacao4H.NFeAutorizacao4();
                    NFCeAutorizacao4H.NFeAutorizacao4 WsHRecepcao = new NFCeAutorizacao4H.NFeAutorizacao4();

                    WsHRecepcao.ClientCertificates.Add(_X509Cert);
                    WsHRecepcao.Timeout = Convert.ToInt32(240000);
                    WsHRecepcao.InitializeLifetimeService();

                    //NFCeAutorizacaoH.nfeCabecMsg cabec = new NFCeAutorizacaoH.nfeCabecMsg();
                    //cabec.cUF = "33";
                    //cabec.versaoDados = "3.10";
                    //WsHRecepcao.nfeCabecMsgValue = cabec;
                    TextoXML = WsHRecepcao.nfeAutorizacaoLote(xmlDados).OuterXml;
                    WsHRecepcao.Dispose();
                }


                return TextoXML;
            }
            catch (Exception ex)
            {
                return "Erro de conexão na recepção...! " + ex.Message;
            }

        }
        //------------------------------------------------------------------------------

        public string XML_InutilizacaoNFCe(XmlDocument xmlAssinado, X509Certificate2 _X509Cert)
        {
            try
            {
                //Transmitindo em ambiente de homologação
                xmlDados = xmlAssinado.DocumentElement;

                ServicePoint();

                if (GeraXml.AmbienteNFCe == "1")
                {
                    //NFCeRecepcaoP - PRODUCAO  /  NFCeRecepcaoH - HOMOLOGACAO
                    NFCeInutilizacao4P.NFeInutilizacao4 WsHInutilizacao = new NFCeInutilizacao4P.NFeInutilizacao4();

                    WsHInutilizacao.ClientCertificates.Add(_X509Cert);
                    WsHInutilizacao.Timeout = Convert.ToInt32(240000);
                    WsHInutilizacao.InitializeLifetimeService();

                    //NFCeInutilizacao2P.nfeCabecMsg cabec = new NFCeInutilizacao2P.nfeCabecMsg();
                    //cabec.cUF = "33";
                    //cabec.versaoDados = "3.10";
                    //WsHInutilizacao.nfeCabecMsgValue = cabec;
                    TextoXML = WsHInutilizacao.nfeInutilizacaoNF(xmlDados).OuterXml;
                    WsHInutilizacao.Dispose();

                }
                else
                {
                    //NFCeRecepcaoP - PRODUCAO  /  NFCeRecepcaoH - HOMOLOGACAO
                    NFCeInutilizacao4H.NFeInutilizacao4 WsHInutilizacao = new NFCeInutilizacao4H.NFeInutilizacao4();

                    WsHInutilizacao.ClientCertificates.Add(_X509Cert);
                    WsHInutilizacao.Timeout = Convert.ToInt32(240000);
                    WsHInutilizacao.InitializeLifetimeService();

                    //NFCeInutilizacao2H.nfeCabecMsg cabec = new NFCeInutilizacao2H.nfeCabecMsg();
                    //cabec.cUF = "33";
                    //cabec.versaoDados = "3.10";
                    //WsHInutilizacao.nfeCabecMsgValue = cabec;
                    TextoXML = WsHInutilizacao.nfeInutilizacaoNF(xmlDados).OuterXml;
                    WsHInutilizacao.Dispose();
                }


                return TextoXML;

            }
            catch (Exception ex)
            {
                return "Erro de conexão na recepção...! " + ex.Message;
            }
        }
        //------------------------------------------------------------------------------

        public string XML_CancelamentoNFCe(XmlDocument xmlAssinado, string nfiscal, X509Certificate2 _X509Cert)
        {
            try
            {
                var geraxml = new GeraXml();

                //Gerando o xml de Lote
                xmlLote = geraxml.GeraXmlDeLoteEvento(xmlAssinado, nfiscal);

                xmlDados = xmlLote.DocumentElement;

                ServicePoint();

                if (GeraXml.AmbienteNFCe == "1")
                {
                    //NFCeRecepcaoEventoP - PRODUCAO  /  NFCeRecepcaoEventoH - HOMOLOGACAO
                    NFCeRecepcaoEvento4P.NFeRecepcaoEvento4 WsHRecepcao = new NFCeRecepcaoEvento4P.NFeRecepcaoEvento4();

                    WsHRecepcao.ClientCertificates.Add(_X509Cert);
                    WsHRecepcao.Timeout = Convert.ToInt32(120000);
                    WsHRecepcao.InitializeLifetimeService();

                    //NFCeRecepcaoEventoP.nfeCabecMsg cabec = new NFCeRecepcaoEventoP.nfeCabecMsg();
                    //cabec.cUF = "33";
                    //cabec.versaoDados = "1.00";
                    //WsHRecepcao.nfeCabecMsgValue = cabec;
                    TextoXML = WsHRecepcao.nfeRecepcaoEvento(xmlDados).OuterXml;
                    WsHRecepcao.Dispose();
                }
                else
                {
                    //NFCeRecepcaoEventoP - PRODUCAO  /  NFCeRecepcaoEventoH - HOMOLOGACAO
                    NFCeRecepcaoEvento4H.NFeRecepcaoEvento4 WsHRecepcao = new NFCeRecepcaoEvento4H.NFeRecepcaoEvento4();

                    WsHRecepcao.ClientCertificates.Add(_X509Cert);
                    WsHRecepcao.Timeout = Convert.ToInt32(120000);
                    WsHRecepcao.InitializeLifetimeService();

                    //NFCeRecepcaoEventoH.nfeCabecMsg cabec = new NFCeRecepcaoEventoH.nfeCabecMsg();
                    //cabec.cUF = "33";
                    //cabec.versaoDados = "1.00";
                    //WsHRecepcao.nfeCabecMsgValue = cabec;
                    TextoXML = WsHRecepcao.nfeRecepcaoEvento(xmlDados).OuterXml;
                    WsHRecepcao.Dispose();
                }


                return TextoXML;
            }
            catch (Exception ex)
            {
                //Log_Exception.Monta_ArquivoLog(ex);

                return "Erro de conexão na recepção...! " + ex.Message;
            }
        }

    }
}
