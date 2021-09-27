using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ProjetoPDVModel;
using ProjetoPDVDao;
//using ProjetoP
using System.Security.Cryptography.X509Certificates;
//using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Xml.Schema;
using System.Threading;
using System.Runtime.InteropServices;
using ProjetoPDVUtil;
//using System.Web.Services;
//using System.Web.Services.Protocols;


namespace ProjetoPDVServico
{
    public class GeraXml
    {

        private string _CSCNFCe;

        //Peso total da nota
        private double _pesoTotal;

        //Desconto total da nota
        private decimal _totalDeDescontoNFCe;

        private string _chaveNFCe { get; set; }

        private int _digitoVerificador;

        //private int cNF { get; set; }
        private string cNF;

        //Dados da nota
        private string strXmlProcNfe { get; set; }
        private string numProc { get; set; }
        private string numChave { get; set; }
        private string xMotivo { get; set; }


        //Dados para calculos de imposto
        private decimal vICMS = 0;
        private decimal vPIS = 0;
        private decimal vCOFINS = 0;

        private decimal vBCICMS = 0;
        private decimal vBCPIS = 0;
        private decimal vBCCOFINS = 0;



        private string strNFe_Assinada { get; set; }
        private string strProc { get; set; }

        public string Chave { get; }


        private static string _AmbienteNFCe;

        public static string AmbienteNFCe
        {
            get => _AmbienteNFCe;
            set
            {
                if (value == "1" || value == "2")
                {
                    _AmbienteNFCe = value;
                }
            }
        }


        public string GetUrlQRCode(XmlDocument xmlAssinado, Pedido pedido)
        {
            const string urlSite = "http://www4.fazenda.rj.gov.br/consultaNFCe/QRCode?";
            var urlNfCe = string.Empty;
            var token = ControleFiscal.GetInstance.TokenProducao;

            try
            {

                if (_AmbienteNFCe == "2")
                    token = ControleFiscal.GetInstance.TokenHomologacao;

                //urlNfCe += "chNFe=" + _chaveNFCe;
                urlNfCe += "p=";


                ;// urlNfCe += "&nVersao=" + "100";
                var versaoQrCode = "|" + "2";

                //urlNfCe += "&tpAmb=" + _AmbienteNFCe;
                var ambiente = "|" + _AmbienteNFCe;

                //if (pedido.Cliente.Nome.Trim() != "CONSUMIDOR NÃO IDENTIFICADO")
                //{
                //    urlNfCe += "&cDest=";
                //    urlNfCe += pedido.Cliente.CnpjCpf;
                //}

                //urlNfCe += "&dhEmi=" + BitConverter.ToString(Encoding.Default.GetBytes(xmlAssinado.GetElementsByTagName("dhEmi")[0].InnerText)).Replace("-", "");
                //urlNfCe += "&vNF=" + xmlAssinado.GetElementsByTagName("vNF")[0].InnerText;
                ////url_NFCe += "&vICMS=" + "0.00";
                //urlNfCe += "&vICMS=" + vICMS.ToString("0.00").Replace(",", ".");
                //urlNfCe += "&digVal=" + BitConverter.ToString(Encoding.Default.GetBytes(xmlAssinado.GetElementsByTagName("DigestValue")[0].InnerText)).Replace("-", "");
                //urlNfCe += "&cIdToken=" + "000001";
                //urlNfCe += "&cHashQRCode=" + GetSha1(urlNfCe + token).ToUpper();

                var idToken = "|" + "1";

                var qrCode = _chaveNFCe + versaoQrCode + ambiente + idToken;

                var qrCode_CSC = qrCode + token;

                var SHA1 = GetSha1(qrCode_CSC).ToUpper();

                urlNfCe += qrCode + "|" + SHA1;

            }
            catch (Exception)
            {
                throw;
            }

            return urlSite + urlNfCe;
        }

        private string GetSha1(string texto)
        {
            var sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(Encoding.ASCII.GetBytes(texto));
            var re = sh.Hash;

            var sb = new StringBuilder();
            foreach (var b in re)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }


        public XmlDocument GeraXmlDeLote(XmlDocument xml, string nfiscal)
        {
            var x = new StringBuilder();

            x.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            x.Append(@"<enviNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""4.00"">");
            //x.Append("<idLote>" + nfiscal.ToString("000000000000000") + "</idLote>");
            x.Append("<idLote>" + $@"{Convert.ToInt32(nfiscal):000000000000000}" + "</idLote>");
            x.Append("<indSinc>1</indSinc>");
            x.Append(xml.InnerXml);
            x.Append("</enviNFe>");

            var xmlLote = new XmlDocument();
            xmlLote.LoadXml(x.ToString());

            return xmlLote;
        }

        public XmlDocument GeraXmlDeLoteEvento(XmlDocument xml, string nfiscal)
        {
            var x = new StringBuilder();

            x.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            x.Append(@"<envEvento xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""1.00"">");
            //x.Append("<idLote>" + nfiscal.ToString("000000000000000") + "</idLote>");
            x.Append("<idLote>" + $@"{Convert.ToInt32(nfiscal):000000000000000}" + "</idLote>");
            x.Append(xml.InnerXml);
            x.Append("</envEvento>");


            var xmlLote = new XmlDocument();
            xmlLote.LoadXml(x.ToString());

            return xmlLote;
        }


        //------------------------------------------------------------------------------
        public XmlDocument GeraXmlDeCancelamentoNFCe(Pedido pedido, string justificativa)
        {

            try
            {

                var xml = new XmlDocument();

                XmlNode xmlNohEvento = xml.CreateElement("evento");
                xml.AppendChild(xmlNohEvento);

                xmlNohEvento.Attributes?.Append(atributo(xml, "xmlns", "http://www.portalfiscal.inf.br/nfe"));
                xmlNohEvento.Attributes?.Append(atributo(xml, "versao", "1.00"));

                XmlNode xmlNohInformacoes = xml.CreateElement("infEvento");
                xmlNohEvento.AppendChild(xmlNohInformacoes);


                //A regra de formação do Id é: "ID" + tpEvento + chave da NFe + nSeqEvento
                xmlNohInformacoes.Attributes?.Append(atributo(xml, "Id", "ID110111" + pedido.Chave + "01"));
                xmlNohInformacoes.AppendChild(elemento(xml, "cOrgao", "33"));
                xmlNohInformacoes.AppendChild(elemento(xml, "tpAmb", _AmbienteNFCe));
                xmlNohInformacoes.AppendChild(elemento(xml, "CNPJ", Emitente.GetInstancia.Cnpj));
                xmlNohInformacoes.AppendChild(elemento(xml, "chNFe", pedido.Chave));
                xmlNohInformacoes.AppendChild(elemento(xml, "dhEvento", DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss'-02:00'")));
                xmlNohInformacoes.AppendChild(elemento(xml, "tpEvento", "110111"));
                xmlNohInformacoes.AppendChild(elemento(xml, "nSeqEvento", "1"));
                xmlNohInformacoes.AppendChild(elemento(xml, "verEvento", "1.00"));


                XmlNode xmlNohDetalhes = xml.CreateElement("detEvento");
                xmlNohInformacoes.AppendChild(xmlNohDetalhes);

                xmlNohDetalhes.Attributes?.Append(atributo(xml, "versao", "1.00"));

                xmlNohDetalhes.AppendChild(elemento(xml, "descEvento", "Cancelamento"));
                xmlNohDetalhes.AppendChild(elemento(xml, "nProt", pedido.Protocolo));
                xmlNohDetalhes.AppendChild(elemento(xml, "xJust", justificativa));

                return xml;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //------------------------------------------------------------------------------


        public XmlDocument GeraXmlDeInutilizacaoNFCe(int notaFiscalInicial, int notaFiscalFinal, int serieFiscal, string justificativa, string modeloFiscal)
        {

            var xml = new XmlDocument();

            //doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", null));

            XmlNode xmlNohInutilizacaoNFe = xml.CreateElement("inutNFe");
            xml.AppendChild(xmlNohInutilizacaoNFe);

            xmlNohInutilizacaoNFe.Attributes?.Append(atributo(xml, "xmlns", "http://www.portalfiscal.inf.br/nfe"));
            xmlNohInutilizacaoNFe.Attributes?.Append(atributo(xml, "versao", "4.00"));

            //Emitente em = (new EmitenteDao()).getEmitente();

            XmlNode xmlNohInformacoes = xml.CreateElement("infInut");
            xmlNohInutilizacaoNFe.AppendChild(xmlNohInformacoes);
            // ID = Literal 33 = Código Estado 15 = Ano 00000000000000 = CNPJ 55 = Modelo 001 = Série 000000411 = Número Inicial 000000411 = Número Final 
            xmlNohInformacoes.Attributes?.Append(atributo(xml, "Id", "ID" + "33" + DateTime.Now.Year.ToString().Substring(2, 2) + Emitente.GetInstancia.Cnpj + modeloFiscal + serieFiscal.ToString("000") + notaFiscalInicial.ToString("000000000") + notaFiscalFinal.ToString("000000000")));
            xmlNohInformacoes.AppendChild(elemento(xml, "tpAmb", _AmbienteNFCe));
            xmlNohInformacoes.AppendChild(elemento(xml, "xServ", "INUTILIZAR"));
            xmlNohInformacoes.AppendChild(elemento(xml, "cUF", "33"));
            xmlNohInformacoes.AppendChild(elemento(xml, "ano", DateTime.Now.Year.ToString().Substring(2, 2)));
            xmlNohInformacoes.AppendChild(elemento(xml, "CNPJ", Emitente.GetInstancia.Cnpj));
            xmlNohInformacoes.AppendChild(elemento(xml, "mod", modeloFiscal));
            xmlNohInformacoes.AppendChild(elemento(xml, "serie", serieFiscal.ToString()));
            xmlNohInformacoes.AppendChild(elemento(xml, "nNFIni", notaFiscalInicial.ToString()));
            xmlNohInformacoes.AppendChild(elemento(xml, "nNFFin", notaFiscalFinal.ToString()));
            xmlNohInformacoes.AppendChild(elemento(xml, "xJust", justificativa));

            return xml;
        }


        //------------------------------------------------------------------------------

        public XmlDocument GeraXmlNFCe(Pedido pedido)
        {
            try
            {

                var xml = new XmlDocument();

                XmlNode NFe = XML_NFe(xml);
                XmlNode infNFe = XML_infNFe(xml, pedido);

                XML_Ide(xml, pedido, infNFe);
                XML_Emitente(xml, pedido, infNFe);
                XML_Destinatario(xml, pedido, infNFe);
                XML_Itens(xml, pedido, infNFe);
                XML_Total(xml, pedido, infNFe);
                XML_Transp(xml, pedido, infNFe);

                XML_TPag(xml, pedido, infNFe); //Tipo de pagamento

                XML_InfAdic(xml, pedido, infNFe);

                NFe.AppendChild(infNFe);
                xml.AppendChild(NFe);

                return xml;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void XML_TPag(XmlDocument xml, Pedido p, XmlNode raiz)
        {
            XmlNode pag = xml.CreateElement("pag");



            foreach (TipoPagamento pagamento in p.Pagamentos)
            {
                XmlNode detPag = xml.CreateElement("detPag");
                pag.AppendChild(detPag);

                detPag.AppendChild(elemento(xml, "indPag", p.Operacao.TV.ToString().Trim()));
                //pag.AppendChild(elemento(xml, "tPag", p.tipoPgto.codFormaPgtoNFCe.ToString("00")));
                detPag.AppendChild(elemento(xml, "tPag", pagamento.CodigoNFCe.ToString("00")));


                //if (pagamento.CodigoNFCe.Equals(99))
                //{
                //    detPag.AppendChild(elemento(xml, "xPag", "Cartão alimentação"));
                //}

                detPag.AppendChild(elemento(xml, "vPag", pagamento.ValorPago.ToString("######0.00").Replace(",", ".")));

                if (pagamento.CodigoNFCe.Equals(3) || pagamento.CodigoNFCe.Equals(4))
                {
                    XmlNode card = xml.CreateElement("card");
                    detPag.AppendChild(card);

                    card.AppendChild(elemento(xml, "tpIntegra", "2"));
                }
            }

            //pag.AppendChild(elemento(xml, "tPag", "01"));
            //pag.AppendChild(elemento(xml, "vPag", p.ValorPedido.ToString("######0.00").Replace(",", ".")));

            if (p.Troco > 0)
                pag.AppendChild(elemento(xml, "vTroco", p.Troco.ToString("00")));

            raiz.AppendChild(pag);
        }

        //--------------------------------------------------------------------

        private XmlNode XML_nfeProc(XmlDocument xml)
        {
            XmlNode nfeProc = xml.CreateElement("nfeProc");
            nfeProc.Attributes.Append(atributo(xml, "xmlns", "http://www.portalfiscal.inf.br/nfe"));
            //nfeProc.Attributes.Append(atributo(xml, "versao", "3.10"));
            nfeProc.Attributes.Append(atributo(xml, "versao", "4.0"));

            return nfeProc;
        }

        private XmlNode XML_NFe(XmlDocument xml)
        {
            XmlNode NFe = xml.CreateElement("NFe");
            NFe.Attributes.Append(atributo(xml, "xmlns", "http://www.portalfiscal.inf.br/nfe"));

            return NFe;
        }

        private void Monta_cNF()
        {
            /*
            string a;
            string b;
            string c;
            a = p.cliente.tipcli == 1 ? p.cliente.cpf.Substring(0, 2) : p.cliente.cgc.Substring(0, 2);
            b = p.cliente.tipcli == 1 ? p.cliente.cpf.Substring(10, 1) : p.cliente.cgc.Substring(13, 1);
            c = p.nfiscal.Substring(0, 1);
            cNF = DateTime.Now.Month.ToString("00") + a + b + c + DateTime.Now.Year.ToString().Substring(2, 2);
            */

            Random randNum = new Random();
            cNF = randNum.Next(99999999).ToString("00000000");

            randNum = null;
        }

        private XmlNode XML_infNFe(XmlDocument xml, Pedido p)
        {
            // Regra para montar a chave
            //33 + ano(2) + mes(2) + cnpj(14) + modelo(2) + serie(3) + NF(9) + codigo
            //codigo = mes(2) + cnpj (2 primeiros numeros iniciais) + cnpj (ultimo numero) + NF (1 numero inicial) + ano(2)
            //EXEMPLO:
            //33 16 08 01578493000295 55 002 000001237 10 59 1 0 11 73

            Monta_cNF();

            _chaveNFCe = "33" + p.DataDigitacao.ToString().Substring(8, 2) + p.DataDigitacao.ToString().Substring(3, 2) + Emitente.GetInstancia.Cnpj + p.ModeloNFiscal + (p.SerieNFiscal).ToString("000") + (string.IsNullOrEmpty(p.NFiscal.ToString()) ? "0" : String.Format(@"{0:000000000}", Convert.ToInt32(p.NFiscal))) + "1" + cNF;
            _digitoVerificador = DigitoVerificador.DigitoModulo11(_chaveNFCe);
            _chaveNFCe += _digitoVerificador.ToString();

            XmlNode infNFe = xml.CreateElement("infNFe");
            infNFe.Attributes.Append(atributo(xml, "Id", "NFe" + _chaveNFCe));
            infNFe.Attributes.Append(atributo(xml, "versao", "4.00"));

            return infNFe;
        }


        private void XML_Ide(XmlDocument xml, Pedido p, XmlNode raiz)
        {
            XmlNode ide = xml.CreateElement("ide");
            ide.AppendChild(elemento(xml, "cUF", "33"));


            ide.AppendChild(elemento(xml, "cNF", cNF));
            ide.AppendChild(elemento(xml, "natOp", p.Operacao.DescFiscal.Trim()));
            //O campo foi reposicionado na versão 4.0. Agora os dados de pagamento são obrigatórios para NFe e NFCe e se encontram no grupo pag
            //ide.AppendChild(elemento(xml, "indPag", p.Operacao.TV.ToString().Trim()));
            ide.AppendChild(elemento(xml, "mod", p.ModeloNFiscal));

            //Contingencia -----------------------------------------
            ide.AppendChild(elemento(xml, "serie", p.SerieNFiscal.ToString()));
            //------------------------------------------------------

            ide.AppendChild(elemento(xml, "nNF", p.NFiscal.ToString()));


            ide.AppendChild(elemento(xml, "dhEmi", p.DataDigitacao.ToString("yyyy-MM-dd") + "T" + DateTime.Now.ToString("HH:mm:ss") + ControleFiscal.GetInstance.TZD));
            //ide.AppendChild(elemento(xml, "dhSaiEnt", p.datanfiscal.ToString("yyyy-MM-dd'T'HH:mm:ss'-02:00'")));


            ide.AppendChild(elemento(xml, "tpNF", p.Operacao.STQ.ToString() != "1" ? "1" : "0"));
            ide.AppendChild(elemento(xml, "idDest", "1"));
            ide.AppendChild(elemento(xml, "cMunFG", "3304557"));
            ide.AppendChild(elemento(xml, "tpImp", "5"));

            //Forma da emissao da nota fiscal --------------------
            ide.AppendChild(elemento(xml, "tpEmis", "1"));
            //----------------------------------------------------
            //Digito verificador da chave - modulo 11 ------------
            ide.AppendChild(elemento(xml, "cDV", _digitoVerificador.ToString()));
            //----------------------------------------------------

            // 1:Producao - 2:Homologacao
            ide.AppendChild(elemento(xml, "tpAmb", _AmbienteNFCe));
            ide.AppendChild(elemento(xml, "finNFe", p.Operacao.Devolucao.ToString() == "0" ? "1" : "4"));
            ide.AppendChild(elemento(xml, "indFinal", "1"));
            ide.AppendChild(elemento(xml, "indPres", "1"));
            ide.AppendChild(elemento(xml, "procEmi", "0"));
            ide.AppendChild(elemento(xml, "verProc", "3.10.37"));

            // Devolucao
            //if (p.Operacao.Devolucao == "1")
            //{
            //    List<string> lstChave = (new PedidoDao()).getlstPedidos_Relacionados(p.numdoc);

            //    foreach (string strChave in lstChave)
            //    {
            //        XmlNode NFref = xml.CreateElement("NFref");
            //        NFref.AppendChild(elemento(xml, "refNFe", strChave));
            //        ide.AppendChild(NFref);
            //    }
            //}

            raiz.AppendChild(ide);
        }


        private void XML_Emitente(XmlDocument xml, Pedido p, XmlNode raiz)
        {
            XmlNode emit = xml.CreateElement("emit");
            emit.AppendChild(elemento(xml, "CNPJ", string.IsNullOrEmpty(Emitente.GetInstancia.Cnpj) ? "" : Emitente.GetInstancia.Cnpj.Trim()));

            if (_AmbienteNFCe == "2")
            {
                emit.AppendChild(elemento(xml, "xNome", "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"));
            }
            else
            {
                emit.AppendChild(elemento(xml, "xNome", string.IsNullOrEmpty(Emitente.GetInstancia.Nome) ? "" : Emitente.GetInstancia.Nome.Trim()));
            }

            emit.AppendChild(elemento(xml, "xFant", string.IsNullOrEmpty(Emitente.GetInstancia.NomeFantasia) ? "" : Emitente.GetInstancia.NomeFantasia.Trim()));


            XmlNode enderEmit = xml.CreateElement("enderEmit");

            enderEmit.AppendChild(elemento(xml, "xLgr", string.IsNullOrEmpty(Emitente.GetInstancia.Endereco.Logradouro) ? "" : Emitente.GetInstancia.Endereco.Logradouro.Trim()));
            enderEmit.AppendChild(elemento(xml, "nro", string.IsNullOrEmpty(Emitente.GetInstancia.Endereco.Numero) ? "" : Emitente.GetInstancia.Endereco.Numero.Trim()));
            enderEmit.AppendChild(elemento(xml, "xCpl", string.IsNullOrEmpty(Emitente.GetInstancia.Endereco.Complemento) ? "" : Emitente.GetInstancia.Endereco.Complemento.Trim()));
            enderEmit.AppendChild(elemento(xml, "xBairro", Emitente.GetInstancia.Endereco.Bairro));
            enderEmit.AppendChild(elemento(xml, "cMun", "3304904"));
            enderEmit.AppendChild(elemento(xml, "xMun", string.IsNullOrEmpty(Emitente.GetInstancia.Endereco.Municipio) ? "" : Emitente.GetInstancia.Endereco.Municipio.Trim()));
            enderEmit.AppendChild(elemento(xml, "UF", string.IsNullOrEmpty(Emitente.GetInstancia.Endereco.Uf) ? "" : Emitente.GetInstancia.Endereco.Uf.Trim()));
            enderEmit.AppendChild(elemento(xml, "CEP", string.IsNullOrEmpty(Emitente.GetInstancia.Endereco.Cep) | Emitente.GetInstancia.Endereco.Cep.Trim().Length < 8 ? "" : Emitente.GetInstancia.Endereco.Cep.Trim()));
            enderEmit.AppendChild(elemento(xml, "cPais", "1058"));
            enderEmit.AppendChild(elemento(xml, "xPais", "BRASIL"));
            enderEmit.AppendChild(elemento(xml, "fone", "2137114219"));
            emit.AppendChild(enderEmit);

            emit.AppendChild(elemento(xml, "IE", Emitente.GetInstancia.InsCest));
            emit.AppendChild(elemento(xml, "CRT", "1")); // Simples Nacional

            raiz.AppendChild(emit);

        }


        private void XML_Destinatario(XmlDocument xml, Pedido p, XmlNode raiz)
        {

            if (p.Cliente.Nome.Trim() == "CONSUMIDOR NÃO IDENTIFICADO")
                return;


            XmlNode dest = xml.CreateElement("dest");

            if (p.Cliente.CnpjCpf.Trim().Length <= 11)
            {
                dest.AppendChild(elemento(xml, "CPF", string.IsNullOrEmpty(p.Cliente.CnpjCpf.Trim()) || p.Cliente.CnpjCpf.Trim().Length < 11 ? "" : p.Cliente.CnpjCpf));
            }
            else
            {
                dest.AppendChild(elemento(xml, "CNPJ", string.IsNullOrEmpty(p.Cliente.CnpjCpf.Trim()) || p.Cliente.CnpjCpf.Trim().Length < 14 ? "" : p.Cliente.CnpjCpf.Trim()));
            }

            // 1 - Producao / 2 - Homologacao
            if (_AmbienteNFCe == "1")
            {
                dest.AppendChild(elemento(xml, "xNome", p.Cliente.Nome.Trim()));

            }
            else
            {
                dest.AppendChild(elemento(xml, "xNome", "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"));
            }


            
            if (!string.IsNullOrEmpty(p.Cliente.Endereco.Logradouro.Trim()))
            {
                XmlNode enderDest = xml.CreateElement("enderDest");
                dest.AppendChild(enderDest);

                enderDest.AppendChild(elemento(xml, "xLgr", string.IsNullOrEmpty(p.Cliente.Endereco.Logradouro) ? "" : p.Cliente.Endereco.Logradouro.Trim()));
                enderDest.AppendChild(elemento(xml, "nro", string.IsNullOrEmpty(p.Cliente.Endereco.Numero) ? "" : p.Cliente.Endereco.Numero.Trim()));
                enderDest.AppendChild(elemento(xml, "xBairro", string.IsNullOrEmpty(p.Cliente.Endereco.Bairro) ? "" : p.Cliente.Endereco.Bairro.Trim()));
                enderDest.AppendChild(elemento(xml, "cMun", string.IsNullOrEmpty(p.Cliente.Endereco.CodigoMunicipio) ? "" : p.Cliente.Endereco.CodigoMunicipio.Trim()));
                enderDest.AppendChild(elemento(xml, "xMun", string.IsNullOrEmpty(p.Cliente.Endereco.Municipio) ? "" : p.Cliente.Endereco.Municipio.Trim()));
                enderDest.AppendChild(elemento(xml, "UF", string.IsNullOrEmpty(p.Cliente.Endereco.Uf) ? "" : p.Cliente.Endereco.Uf.Trim()));
                enderDest.AppendChild(elemento(xml, "CEP", string.IsNullOrEmpty(p.Cliente.Endereco.Cep) || p.Cliente.Endereco.Cep.Trim().Length < 8 ? "" : p.Cliente.Endereco.Cep.Trim()));
                enderDest.AppendChild(elemento(xml, "cPais", "1058"));
                enderDest.AppendChild(elemento(xml, "xPais", "Brasil"));
            }
            

            dest.AppendChild(elemento(xml, "indIEDest", "9"));

            raiz.AppendChild(dest);
        }

        private void XML_Itens(XmlDocument xml, Pedido p, XmlNode raiz)
        {
            var n = 1;
            _totalDeDescontoNFCe = 0;

            var calcula_Imposto = 0m;


            foreach (PedidoItem pedidoitem in p.ItensDoPedido)
            {
                //DET
                XmlNode det = xml.CreateElement("det");
                det.Attributes.Append(atributo(xml, "nItem", n.ToString()));

                XmlNode prod = xml.CreateElement("prod");
                prod.AppendChild(elemento(xml, "cProd", pedidoitem.Produto.ProdutoId.ToString()));
                prod.AppendChild(elemento(xml, "cEAN", "SEM GTIN"));


                if (_AmbienteNFCe == "2")
                {
                    prod.AppendChild(elemento(xml, "xProd", "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL"));
                }
                else
                {
                    prod.AppendChild(elemento(xml, "xProd", StringUtil.RemoverAcentos(pedidoitem.Produto.Descricao.Trim()).ToUpper()));
                }



                //prod.AppendChild(elemento(xml, "NCM", "49019900"));
                prod.AppendChild(elemento(xml, "NCM", pedidoitem.Produto.GrupoFiscal.Ncm));

                if (pedidoitem.Produto.GrupoFiscal.CSOSN == "500" || (pedidoitem.Produto.GrupoFiscal.ST.Equals(1) && pedidoitem.Produto.GrupoFiscal.Cest.Trim().Length > 1))
                    prod.AppendChild(elemento(xml, "CEST", pedidoitem.Produto.GrupoFiscal.Cest));


                ////if (pedidoitem.Produto.GrupoFiscal.ST.Equals(1) && pedidoitem.produto.codgrupo != 0)
                //if (pedidoitem.Produto.GrupoFiscal.ST.Equals(1))
                //    prod.AppendChild(elemento(xml, "CFOP", "5405"));
                //else
                //    prod.AppendChild(elemento(xml, "CFOP", p.Operacao.CFDE.ToString()));

                if(pedidoitem.Produto.GrupoFiscal.CSOSN.Equals("500"))
                    prod.AppendChild(elemento(xml, "CFOP", "5405"));
                else
                    prod.AppendChild(elemento(xml, "CFOP", p.Operacao.CFDE.ToString()));


                //prod.AppendChild(elemento(xml, "CFOP", p.operacao.cfde.ToString()));
                //prod.AppendChild(elemento(xml, "CFOP", "5405"));
                //prod.AppendChild(elemento(xml, "CFOP", "5102"));

                prod.AppendChild(elemento(xml, "uCom", "Ex"));
                prod.AppendChild(elemento(xml, "qCom", pedidoitem.Quantidade.ToString(".0000").Replace(",", ".")));
                prod.AppendChild(elemento(xml, "vUnCom", pedidoitem.ValorOriginalItem.ToString("####0.0000").Replace(",", ".")));
                prod.AppendChild(elemento(xml, "vProd", (pedidoitem.ValorOriginalItem * pedidoitem.Quantidade).ToString("####0.00").Replace(",", ".")));

                //Agora informando o codigo GTIN(código de barras) - inserido na versao 4.0
                prod.AppendChild(elemento(xml, "cEANTrib", "SEM GTIN"));


                prod.AppendChild(elemento(xml, "uTrib", "Ex"));
                prod.AppendChild(elemento(xml, "qTrib", prod.SelectSingleNode("qCom").InnerText));
                prod.AppendChild(elemento(xml, "vUnTrib", prod.SelectSingleNode("vUnCom").InnerText));

                //decimal valDscRateado = 0;
                decimal ValDsc = 0;
                string strDsc = "";


                //====================================================================================================
                //VERIFICAR ESSA PARTE DE DESCONTOS, DA PRA MELHORAR
                //====================================================================================================
                if (((pedidoitem.ValorOriginalItem * pedidoitem.Quantidade) != pedidoitem.ValorTotal)) // || p.valdsc > 0)
                {
                    /*
                    if(p.valdsc > 0)
                        ValDsc = pedidoitem.valDesc;
                    else
                    */

                    ValDsc = decimal.Round(((pedidoitem.ValorOriginalItem * pedidoitem.Quantidade) - pedidoitem.ValorTotal), 2);


                    //ValDsc = decimal.Round(ValDsc, 2);
                    strDsc = ValDsc.ToString("####0.00").Replace(",", ".");
                    //strDsc = ValDsc.ToString("####0.00").Replace(",", ".");

                    //Calculando o total de desconto
                    _totalDeDescontoNFCe += ValDsc;

                    prod.AppendChild(elemento(xml, "vDesc", strDsc));
                }

                prod.AppendChild(elemento(xml, "indTot", "1"));
                _pesoTotal = (pedidoitem.Produto.Peso * pedidoitem.Quantidade);





                //IMPOSTOS ===================================================================================================================
                XmlNode imposto = xml.CreateElement("imposto");


                // ICMS =====================================================================================================================
                var CSOSN = pedidoitem.Produto.GrupoFiscal.CSOSN;

                XmlNode ICMS = xml.CreateElement("ICMS");
                XmlNode ICMSSN = xml.CreateElement("ICMSSN" + CSOSN);
                ICMSSN.AppendChild(elemento(xml, "orig", "0"));
                ICMSSN.AppendChild(elemento(xml, "CSOSN", CSOSN));

                //ICMSSN.AppendChild(elemento(xml, "vBCSTRet", "0.00"));
                //ICMSSN.AppendChild(elemento(xml, "vICMSSTRet", "0.00"));


                //if (strICMS_CST.Equals("00"))
                //{
                //    calcula_Imposto = 0;
                //    calcula_Imposto = decimal.Round((pedidoitem.ValorTotal * (pedidoitem.Produto.GrupoFiscal.picms / 100)), 2);

                //    ICMS40.AppendChild(elemento(xml, "modBC", "3"));
                //    ICMS40.AppendChild(elemento(xml, "vBC", pedidoitem.ValorTotal.ToString("0.00").Replace(",", ".")));
                //    ICMS40.AppendChild(elemento(xml, "pICMS", pedidoitem.Produto.GrupoFiscal.picms.ToString("00")));
                //    ICMS40.AppendChild(elemento(xml, "vICMS", calcula_Imposto.ToString("0.00").Replace(",", ".")));

                //    vICMS += calcula_Imposto;
                //    vBCICMS += pedidoitem.ValorTotal;
                //}




                //// PIS =====================================================================================================================
                var PIS = "PISOutr";
                var PIS_CST = "99";
                
                XmlNode NoPIS = xml.CreateElement("PIS");
                XmlNode NoPISNT = xml.CreateElement(PIS);
                NoPISNT.AppendChild(elemento(xml, "CST", PIS_CST));
                NoPISNT.AppendChild(elemento(xml, "vBC", "0.00"));
                NoPISNT.AppendChild(elemento(xml, "pPIS", "0.00"));
                NoPISNT.AppendChild(elemento(xml, "vPIS", "0.00"));

                //if (strPIS.Equals("PISAliq"))
                //{
                //    calcula_Imposto = 0;
                //    calcula_Imposto = decimal.Round((pedidoitem.ValorTotal * (pedidoitem.Produto.GrupoFiscal.pis / 100)), 2);

                //    //PIS
                //    PISNT.AppendChild(elemento(xml, "vBC", pedidoitem.ValorTotal.ToString("0.00").Replace(",", ".")));
                //    PISNT.AppendChild(elemento(xml, "pPIS", pedidoitem.Produto.GrupoFiscal.pis.ToString("0.00").Replace(",", ".")));
                //    PISNT.AppendChild(elemento(xml, "vPIS", calcula_Imposto.ToString("0.00").Replace(",", ".")));

                //    vPIS += calcula_Imposto;
                //    vBCPIS += pedidoitem.ValorTotal;
                //}



                //// COFINS =====================================================================================================================

                var COFINS = "COFINSOutr";
                var COFINS_CST = "99";


                XmlNode NoCOFINS = xml.CreateElement("COFINS");
                XmlNode NoCOFINSNT = xml.CreateElement(COFINS);
                NoCOFINSNT.AppendChild(elemento(xml, "CST", COFINS_CST));
                NoCOFINSNT.AppendChild(elemento(xml, "vBC", "0.00"));
                NoCOFINSNT.AppendChild(elemento(xml, "pCOFINS", "0.00"));
                NoCOFINSNT.AppendChild(elemento(xml, "vCOFINS", "0.00"));


                //if (pedidoitem.Produto.GrupoFiscal.Cofins > 0)
                //{
                //    calcula_Imposto = 0;
                //    calcula_Imposto = decimal.Round((pedidoitem.ValorTotal * (pedidoitem.Produto.GrupoFiscal.Cofins / 100)), 2);

                //    COFINSNT.AppendChild(elemento(xml, "vBC", pedidoitem.ValorTotal.ToString("0.00").Replace(",", ".")));
                //    COFINSNT.AppendChild(elemento(xml, "pCOFINS", pedidoitem.Produto.GrupoFiscal.Cofins.ToString("0.00").Replace(",", ".")));
                //    COFINSNT.AppendChild(elemento(xml, "vCOFINS", calcula_Imposto.ToString("0.00").Replace(",", ".")));

                //    vCOFINS += calcula_Imposto;
                //    vBCCOFINS += pedidoitem.ValorTotal;
                //}





                det.AppendChild(prod);
                det.AppendChild(imposto);

                imposto.AppendChild(ICMS);
                ICMS.AppendChild(ICMSSN);

                imposto.AppendChild(NoPIS);
                NoPIS.AppendChild(NoPISNT);

                imposto.AppendChild(NoCOFINS);
                NoCOFINS.AppendChild(NoCOFINSNT);

                raiz.AppendChild(det);
                n++;
            }
        }


        private void XML_Total(XmlDocument xml, Pedido p, XmlNode raiz)
        {
            XmlNode total = xml.CreateElement("total");

            XmlNode ICMSTot = xml.CreateElement("ICMSTot");
            total.AppendChild(ICMSTot);

            ICMSTot.AppendChild(elemento(xml, "vBC", vBCICMS.ToString("0.00").Replace(",", ".")));
            ICMSTot.AppendChild(elemento(xml, "vICMS", vICMS.ToString("0.00").Replace(",", ".")));
            ICMSTot.AppendChild(elemento(xml, "vICMSDeson", "0.00"));
            ICMSTot.AppendChild(elemento(xml, "vFCPUFDest", "0.00"));
            ICMSTot.AppendChild(elemento(xml, "vICMSUFDest", "0.00"));

            //Valor Total do FCP (Fundo de Combate à Pobreza) retido por substituição tributária - inserido na 4.0
            ICMSTot.AppendChild(elemento(xml, "vFCP", "0.00"));
            //---------------------------------------------------


            ICMSTot.AppendChild(elemento(xml, "vBCST", "0.00"));
            //ICMSTot.AppendChild(elemento(xml, "vICMSUFRemet", "0.00"));
            ICMSTot.AppendChild(elemento(xml, "vST", "0.00"));
            //ICMSTot.AppendChild(elemento(xml, "vFCP", "0.00"));

            //Valor Total do FCP (Fundo de Combate à Pobreza) retido por substituição tributária - inserido na 4.0
            ICMSTot.AppendChild(elemento(xml, "vFCPST", "0.00"));
            //Valor Total do FCP retido anteriormente por Substituição Tributária - inserido na 4.0
            ICMSTot.AppendChild(elemento(xml, "vFCPSTRet", "0.00"));


            ICMSTot.AppendChild(elemento(xml, "vProd", p.SubTotal.ToString("######0.00").Replace(",", ".")));
            ICMSTot.AppendChild(elemento(xml, "vFrete", "0.00"));
            ICMSTot.AppendChild(elemento(xml, "vSeg", "0.00"));

            //---------------------------------------------------
            //---------------------------------------------------
            ICMSTot.AppendChild(elemento(xml, "vDesc", _totalDeDescontoNFCe.ToString("######0.00").Replace(",", ".")));
            //---------------------------------------------------
            //---------------------------------------------------


            ICMSTot.AppendChild(elemento(xml, "vII", "0.00"));
            ICMSTot.AppendChild(elemento(xml, "vIPI", "0.00"));

            //O campo foi adicionado no grupo de total da versão 4.0. Corresponde ao total da soma dos campos de vIPIDevol dos produtos. 
            //É obrigatório, mesmo que zerado - inserido na 4.0
            ICMSTot.AppendChild(elemento(xml, "vIPIDevol", "0.00"));

            ICMSTot.AppendChild(elemento(xml, "vPIS", vPIS.ToString("0.00").Replace(",", ".")));
            ICMSTot.AppendChild(elemento(xml, "vCOFINS", vCOFINS.ToString("0.00").Replace(",", ".")));
            ICMSTot.AppendChild(elemento(xml, "vOutro", "0.00"));
            ICMSTot.AppendChild(elemento(xml, "vNF", p.ValorPedido.ToString("######0.00").Replace(",", ".")));
            ICMSTot.AppendChild(elemento(xml, "vTotTrib", "0.00"));

            raiz.AppendChild(total);

        }


        private void XML_Transp(XmlDocument xml, Pedido p, XmlNode raiz)
        {
            //TRANSP
            XmlNode transp = xml.CreateElement("transp");
            transp.AppendChild(elemento(xml, "modFrete", "9"));
            raiz.AppendChild(transp);
        }


        private void XML_InfAdic(XmlDocument xml, Pedido p, XmlNode raiz)
        {
            XmlNode infAdic = xml.CreateElement("infAdic");
            infAdic.AppendChild(elemento(xml, "infCpl", "Volte Sempre!!"));

            raiz.AppendChild(infAdic);
        }


        private XmlAttribute atributo(XmlDocument xml, string nome, string valor)
        {
            XmlAttribute attr = xml.CreateAttribute(nome);
            attr.Value = valor;
            return attr;
        }

        private XmlNode elemento(XmlDocument xml, string nome, string valor)
        {
            XmlNode no = xml.CreateElement(nome);
            no.InnerText = valor;

            return no;
        }

        private string InfoAdic(Pedido p)
        {
            try
            {
                string info = "Nao incidencia de ICMS conforme art. 40 inciso I da lei n. 2.657/96.";
                info = info + " Data de Vencimento: " + DateTime.Now.AddDays(p.Operacao.IntInic);
                info = info + "  N. de itens: " + p.TotalDeExemplares + "   -   Exemp.: " + p.TotalDeItens + "  -";
                info = info + "  N. do Pedido: " + p.NumDoc + "  -";
                //info = info + "  Desconto: " + p.lstPedidoItem[0].dscitens + "%";
                //info = info + (new DiversosDao()).getDiversos(p.numdoc) + ".";

                return info;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
