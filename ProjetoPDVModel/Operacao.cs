using PetaPoco;


namespace ProjetoPDVModel
{
    [PrimaryKey("operacao_id")]
    public class Operacao
    {
        [Column("operacao_id")]
        public int OperacaoId { get; set; }
        public string Nome { get; set; }
        [Column("int_inic")]
        public int IntInic { get; set; }
        public int Intervalo { get; set; }
        [Column("num_pagto")]
        public int NumPagto { get; set; }
        public int Caixa { get; set; }
        [Column("abre_caixa")]
        public int AbreCaixa { get; set; }
        public int AVA { get; set; }
        public int ENT { get; set; }
        public int TRO { get; set; }
        public int DIF { get; set; }
        public int STQ { get; set; }
        public int VND { get; set; }
        public int CFFE { get; set; }
        public int CFDE { get; set; }
        [Column("desc_fiscal")]
        public string DescFiscal { get; set; }
        public string Devolucao { get; set; }
        public string TV { get; set; }
        public string NF { get; set; }

        //Construtores
        public Operacao()
        {
        }

        public Operacao(int operacaoId)
        {
            OperacaoId = operacaoId;
        }
    }
}
