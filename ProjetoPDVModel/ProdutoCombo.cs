using PetaPoco;
using System;
using System.Collections.Generic;

namespace ProjetoPDVModel
{
    [TableName("Produto_Combo")]
    [PrimaryKey("id")]
    public class ProdutoCombo
    {
        [Column("id")]
        public int ComboId { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        [Column("data_inicio")]
        public DateTime? DataInicio { get; set; }
        [Column("data_atualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        [ResultColumn]
        public decimal ValorCombo { get; set; }

        [Ignore]
        public List<ProdutoComboItem> Itens { get; set; }

        public ProdutoCombo() { }

    }
}
