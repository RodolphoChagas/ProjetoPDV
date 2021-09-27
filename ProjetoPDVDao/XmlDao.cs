using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVDao
{
    public class XmlDao
    {

        public Xml GetXml(int numDoc)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Xml>("SELECT top 1 * FROM XML_NFe WHERE NumDoc=@0", numDoc);
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>Retorna uma lista com todos os pedidos já EMITIDOS dentro do período.
        /// </summary>
        public List<Xml> GetXmls()
        {
            try
            {
                //dtInicial = string.Format("{0:yyyy-MM-dd 00:00:00}", dtInicial.to);



                return (new PetaPoco.Database("stringConexao")).Query<Xml>("select xmlnfe.*, chave from xmlnfe inner join movdb on xmlnfe.numdoc = movdb.numdoc where nfiscal >= 1 and nfiscal <= 150 and conddoc = 'F' order by nfiscal").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        /// <summary>
        /// Retorna uma lista com todos os arquivos XML do pedido passado por parametro.
        /// </summary>
        public List<string> getlistXML(int numDoc) 
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<string>("SELECT arquivoXML FROM XML_NFe WHERE NumDoc=" + numDoc).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return (new PetaPoco.Database("stringConexao")).Query<string>("SELECT arquivoXML FROM XML_NFe WHERE NumDoc=" + numDoc).ToList();
        }
         * */

        public string GetArquivoXmlEmTexto(int numDoc)
        {
            string arquivo;

            try
            {
                arquivo = (new PetaPoco.Database("stringConexao")).SingleOrDefault<string>("SELECT arquivoXML FROM XML_NFe WHERE NumDoc=" + numDoc);
            }
            catch (Exception)
            {
                throw;
            }

            return arquivo;
        }

        public Xml GetArquivoXml(int pedidoId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Xml>("SELECT top 1 * FROM XMLNFe WHERE NumDoc=@0", pedidoId);
            }
            catch (Exception)
            {
                throw;
            }

            /// <summary>
            /// Salva o arquivo de XML na tabela designada.
            /// <para>Valores para o parametro 'tipoNFe'</para>
            /// <para>"NFe" - Nota Fiscal Eletronica.</para>
            /// <para>"Canc" - Nota de Cancelamento.</para>
            /// <para>"CCe" - Nota de Carta de Correção.</para>
            /// <para>"Inut" - Nota de Inutilização.</para>
            /// </summary>
        }

        public bool GravaXml(Xml xml)
        {
            try
            {

                if ((new PetaPoco.Database("stringConexao")).Insert("XMLNFe", "idXML", false, xml) != null)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
