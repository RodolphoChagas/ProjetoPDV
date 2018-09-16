using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVModel
{
    public class TipoPagamento
    {
        [Column("id")]
        public int PagamentoId { get; set; }
        public string Descricao { get; set; }
        [Column("is_credito")]
        public int IsCredito { get; set; }
        public int Status { get; set; }
        [Column("maximo_parcelas")]
        public int MaximoDeParcelas { get; set; }
        [Column("valor_minimo_parcelas")]
        public decimal ValorMinimoParaParcelas { get; set; }
        [Column("codigo_nfce")]
        public int CodigoNFCe { get; set; }

        [ResultColumn]
        public decimal ValorPago { get; set; }
        [Ignore]
        public string NumeroDeAutorizacaoDoCartao { get; set; }
        [Ignore]
        public string Observacao { get; set; }

        public TipoPagamento()
        {
        }
    }
}
