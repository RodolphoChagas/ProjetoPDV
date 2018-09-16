using PetaPoco;
using System.Collections.Generic;

namespace ProjetoPDVModel
{
    [TableName("Produto_Combo_Item")]
    [PrimaryKey("id")]
    public class ProdutoComboItem
    {
        [Column("id")]
        public int ComboItemId { get; set; }
        [Column("combo_id")]
        public int ComboId { get; set; }
        public string Descricao { get; set; }
        [Column("valor")]
        public decimal ValorItem { get; set; }

        [Ignore]
        public List<Produto> Produtos { get; set; }

        public ProdutoComboItem() { }
    }
}
