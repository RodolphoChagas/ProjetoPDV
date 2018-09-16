using PetaPoco;

namespace ProjetoPDVModel
{
    [TableName("Produto_GrupoFiscal")]
    [PrimaryKey("id")]
    public class ProdutoGrupoFiscal
    {
        [Column("id")]
        public int GrupoId { get; set; }
        public string Descricao { get; set; }
        public string Ncm { get; set; }
        public string Cest { get; set; }
        public int ST { get; set; }
        public decimal picms { get; set; }
        public decimal pis { get; set; }
        public decimal Cofins { get; set; }
        public decimal Csll { get; set; }
        public decimal Irpj { get; set; }

        public string CSOSN { get; set; }
        [Column("pis_cst")]
        public string PISCST { get; set; }
        [Column("icms_cst")]
        public string COFINSCST { get; set; }
    }
}
