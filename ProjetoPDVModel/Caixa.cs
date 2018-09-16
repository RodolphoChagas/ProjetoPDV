using PetaPoco;
using System;

namespace ProjetoPDVModel
{

    [TableName("FechaCaixa")]
    [PrimaryKey("id")]
    public class Caixa
    {
        [Column("id")]
        public int CaixaId { get; set; }
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        [Column("nome_usuario")]
        public string NomeUsuario { get; set; }
        public DateTime Data { get; set; }
        [Column("saldo_inicial")]
        public decimal SaldoInicial { get; set; }
        [Column("venda_dinheiro")]
        public decimal VendaEmDinheiro { get; set; }
        public decimal Sangria { get; set; }
        [Column("saldo_final_sistema")]
        public decimal SaldoFinalSistema { get; set; }
        [Column("saldo_final_caixa")]
        public decimal SaldoFinalCaixa { get; set; }
        public decimal Diferenca { get; set; }

        public Caixa() { }        
    }
}
