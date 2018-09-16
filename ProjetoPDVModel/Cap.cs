using PetaPoco;
using System;

namespace ProjetoPDVModel
{
    [PrimaryKey("cap_id")]
    public class Cap
    {
        [Column("cap_id")]
        public int CapId { get; set; }

        [Column("fornecedor_id")]
        public int FornecedorId { get; set; }
        [Ignore]
        public Fornecedor Fornecedor { get; set; }

        [Column("categoria_id")]
        public int CategoriaId { get; set; }
        [Ignore]
        public CapCategoria Categoria { get; set; }

        public int NFiscal { get; set; }

        public decimal Valor { get; set; }

        public int Parcela { get; set; }

        [Column("data_nfiscal")]
        public DateTime? DataNFiscal { get; set; }
        [Column("data_vencimento")]
        public DateTime? DataVencimento { get; set; }
        [Column("data_pagamento")]
        public DateTime? DataPagamento { get; set; }

        [Column("tipo_pagamento")]
        public string TipoPagamento { get; set; }

        [Column("status_pagamento")]
        public int StatusPagamento { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }
    }
}
