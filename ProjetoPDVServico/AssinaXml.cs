using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace ProjetoPDVServico
{
    public class AssinaXml
    {
        public XmlDocument AssinaXML(string xml, string strUri, X509Certificate2 _X509Cert)
        {
            try
            {
                string x = _X509Cert.GetKeyAlgorithm().ToString();

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = false;
                doc.LoadXml(xml);


                //Verifica se a tag a ser assinada existe e é única
                int qtdeRefUri = doc.GetElementsByTagName(strUri).Count;

                if (qtdeRefUri == 0)
                {
                    //' a URI indicada não existe
                    //Console.WriteLine("A tag de assinatura " + strUri + " não existe no XML. (Código do Erro: 4)");
                    //Throw New Exception("A tag de assinatura " & strUri.Trim() & " não existe no XML. (Código do Erro: 4)")
                    //intResultado = 4;
                }
                else
                {
                    if (doc.GetElementsByTagName("Signature").Count == 0)
                    {
                        
                        SignedXml signedXml = new SignedXml(doc);

                        signedXml.SigningKey = _X509Cert.PrivateKey;


                        Reference reference = new Reference();


                        //pega o uri que deve ser assinada
                        XmlAttributeCollection _Uri = doc.GetElementsByTagName(strUri).Item(0).Attributes;
                        foreach (XmlAttribute _atributo in _Uri)
                        {
                            if (_atributo.Name == "Id")
                            {
                                reference.Uri = "#" + _atributo.InnerText;
                            }
                        }



                        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                        reference.AddTransform(env);

                        XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                        reference.AddTransform(c14);


                        signedXml.AddReference(reference);


                        KeyInfo keyInfo = new KeyInfo();
                        keyInfo.AddClause(new KeyInfoX509Data(_X509Cert));


                        signedXml.KeyInfo = keyInfo;
                        signedXml.ComputeSignature();

                        XmlElement xmlDigitalSignature = signedXml.GetXml();
                        //XmlElement xmlDigitalSignature = SigningHelper.SignDoc(xmlDocument, certificate, "ID", refValue);


                        if (strUri == "infNFe" || strUri == "infInut")
                        {
                            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                        }
                        else if (strUri == "infEvento")
                        {
                            doc.GetElementsByTagName("evento").Item(0).AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                        }


                        /*
                        string caminho = strUri != "infEvento" ? @"C:\Documents and Settings\Renan\Desktop\gerarxmlASSINADO.xml" : @"C:\Documents and Settings\Renan\Desktop\new20Assinada - CCe.xml";
                        using (XmlTextWriter xmlWriter = new XmlTextWriter(caminho, null))
                        {
                            xmlWriter.Formatting = Formatting.None;
                            doc.Save(xmlWriter);
                        }
                        */

                    }
                }

                return doc;


            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
