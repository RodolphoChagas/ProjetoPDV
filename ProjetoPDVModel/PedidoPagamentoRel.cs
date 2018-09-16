using PetaPoco;
using System.Collections.Generic;

namespace ProjetoPDVModel
{
    [TableName("Movdb_Pagamento_Rel")]
    public class PedidoPagamentoRel
    {
        public int NumDoc { get; set; }
        [Column("pagamento_id")]
        public int PagamentoId { get; set; }
        [Column("valor")]
        public decimal ValorPago { get; set; }
        public string Observacao { get; set; }

        [Ignore]
        public TipoPagamento TipoPagamento { get; set; }

        public PedidoPagamentoRel() { }
    }
}
