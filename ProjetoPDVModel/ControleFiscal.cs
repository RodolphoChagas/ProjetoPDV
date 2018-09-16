using PetaPoco;

namespace ProjetoPDVModel
{
    [TableName("Controle")]
    public class ControleFiscal
    {
        [Column("CSC_Producao")]
        public string TokenProducao { get; set; }
        [Column("CSC_Homologacao")]
        public string TokenHomologacao { get; set; }
        [Column("Caminho_XMLCancelado")]
        public string CaminhoXmlCancelado { get; set; }
        [Column("Caminho_XMLInutilizado")]
        public string CaminhoXmlInutilizado { get; set; }
        [Column("Caminho_XMLAutorizado")]
        public string CaminhoXmlAutorizado { get; set; }
        private static ControleFiscal _instance;

        [Column("NFiscal_NFCe")]
        public int UltimaNfCe { get; set; }

        public static ControleFiscal GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new ControleFiscal();
                }

                return _instance;
            }
        }


    }
}
