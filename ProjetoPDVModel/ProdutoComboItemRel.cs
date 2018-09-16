using PetaPoco;


namespace ProjetoPDVModel
{
    [TableName("Produto_Combo_Item_Rel")]
    [PrimaryKey("id")]
    public class ProdutoComboItemRel
    {
        public int Id { get; set; }
        [Column("combo_id")]
        public int ComboId { get; set; }
        [Column("combo_item_id")]
        public int ComboItemId { get; set; }
        [Column("produto_id")]
        public int ProdutoId { get; set; }


        public ProdutoComboItemRel(int comboId, int comboItemId, int produtoId)
        {
            ComboId = comboId;
            ComboItemId = comboItemId;
            ProdutoId = produtoId;
        }
    }
}
