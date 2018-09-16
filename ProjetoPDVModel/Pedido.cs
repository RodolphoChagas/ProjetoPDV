using System;
using System.Collections.Generic;
using PetaPoco;

namespace ProjetoPDVModel
{
    [TableName("Movdb")]
    [PrimaryKey("NumDoc")]
    public class Pedido
    {
        public int NumDoc { get; set; }
        [Column("cliente_id")]
        public int ClienteId { get; set; }
        [Ignore]
        public Cliente Cliente { get; set; }
        [Column("operacao_id")]
        public int OperacaoId { get; set; }
        [Ignore]
        public Operacao Operacao { get; set; }
        [Ignore]
        public Xml Xml { get; set; }
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public int NFiscal { get; set; }
        [Column("CondDoc")]
        public string StatusPedido { get; set; }
        [Column("subtotal")]
        public decimal SubTotal { get; set; }
        [Column("valor_total")]
        public decimal ValorPedido { get; set; }
        public decimal Troco { get; set; }
        [Column("data_digitacao")]
        public DateTime DataDigitacao { get; set; }
        [Column("data_vencimento")]
        public DateTime? DataVencimento { get; set; }
        [Column("data_nfiscal")]
        public DateTime? DataNFiscal { get; set; }
        [Column("dscdoc")]
        public decimal Desconto { get; set; }
        [Column("valor_desconto")]
        public decimal ValorDesconto { get; set; }
        [Column("Modelo")]
        public string ModeloNFiscal { get; set; }
        [Column("serie_nfiscal")]
        public int SerieNFiscal { get; set; }
        public string Chave { get; set; }
        public string Protocolo { get; set; }
        //public int cartao_codautorizacao { get; set; }
        [Column("status_nfce")]
        public string StatusNFCe { get; set; }
        public string Observacao { get; set; }

        [Ignore]
        public int TotalDeItens { get; set; }
        [Ignore]
        public int TotalDeExemplares { get; set; }

        [ResultColumn]
        public List<TipoPagamento> Pagamentos { get; set; }
        //public List<TipoPagamento> pagamentos { get; set; }
        [ResultColumn]
        public List<PedidoItem> ItensDoPedido { get; set; }
    }
}
