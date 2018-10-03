using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace ProjetoPDVServico
{
    public class ValidaXml
    {

        private string Erro;
        private string caminhoShema;

        private XmlSchema schema;
        private XmlReader validatingReader;


        /// <summary>
        /// Valida o XML conforme o schema designado.
        /// <para>Valores a serem passados no parametro 'tipoNfe':</para>
        /// <para>"NFe" - Nota Fiscal Eletronica.</para>
        /// <para>"Canc" - Nota de Cancelamento.</para>
        /// <para>"CCe" - Nota de Carta de Correção.</para>
        /// <para>"Inut" - Nota de Inutilização.</para>
        /// </summary>
        public string Valida(XmlDocument doc, string tipoNfe)
        {
            Erro = string.Empty;
            caminhoShema = string.Empty;

            try
            {
                switch (tipoNfe)
                {
                    case "NFe":
                        //caminhoShema = @"E:\Documents and Settings\Renan\Meus documentos\Visual Studio 2010\Projects\ProjetoPDVUI\ESQUEMA\NFe\nfe_v3.10.xsd";
                        caminhoShema = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\ESQUEMA\NFe4\nfe_v4.00.xsd";
                        break;
                    case "Canc":
                        //caminhoShema = @"E:\Documents and Settings\Renan\Meus documentos\Visual Studio 2010\Projects\ProjetoPDVUI\ESQUEMA\Evento_Canc\eventoCancNFe_v1.00.xsd";
                        caminhoShema = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\ESQUEMA\Evento_Canc\eventoCancNFe_v1.00.xsd";
                        break;
                    case "Inut":
                        //caminhoShema = @"E:\Documents and Settings\Renan\Meus documentos\Visual Studio 2010\Projects\ProjetoPDVUI\ESQUEMA\NFe\inutNFe_v3.10.xsd";
                        caminhoShema = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\ESQUEMA\NFe\inutNFe_v3.10.xsd";
                        break;
                    case "CCe":
                        //caminhoShema = @"E:\Documents and Settings\Renan\Meus documentos\Visual Studio 2010\Projects\ProjetoPDVUI\ESQUEMA\Evento_CCe\CCe_v1.00.xsd";
                        caminhoShema = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\ESQUEMA\Evento_CCe\CCe_v1.00.xsd";
                        break;
                    case "infLote":
                        //caminhoShema = @"E:\Documents and Settings\Renan\Meus documentos\Visual Studio 2010\Projects\ProjetoPDVUI\ESQUEMA\NFe\enviNFe_v3.10.xsd";
                        caminhoShema = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\ESQUEMA\NFe\enviNFe_v3.10.xsd";
                        break;
                }
                //N:\Sistemas\PDV_CSharp\ProjetoPDV\ProjetoPDVUI\bin\Debug\ESQUEMA\NFe
                schema = XmlSchema.Read(new XmlTextReader(caminhoShema), null);
                //schema = XmlSchema.Read(new XmlTextReader(@"N:\Sistemas\PDV_CSharp\ProjetoPDV\ProjetoPDVUI\bin\Debug\ESQUEMA\NFe\nfe_v3.10.xsd"), null);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add(schema);

                validatingReader = XmlReader.Create(new StringReader(doc.InnerXml), settings);

                try
                {
                    while (validatingReader.Read()) { };
                }
                catch (Exception ex)
                {
                    Erro += (ex.Message + validatingReader.Name + Environment.NewLine);
                }

            }
            catch (Exception)
            {
                //Log_Exception.Monta_ArquivoLog(ex);
                //return "Erro inesperado: " + ex.Message;
                throw;
            }
            finally
            {
                validatingReader.Close();
            }

            return Erro;
        }

    }
}
