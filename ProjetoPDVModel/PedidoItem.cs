using PetaPoco;

namespace ProjetoPDVModel
{
    [TableName("MovItens")]
    public class PedidoItem
    {
        public int NumDoc { get; set; }
        [Ignore]
        public Pedido Pedido { get; set; }
        [Column("produto_id")]
        public int ProdutoId { get; set; }
        [Column("combo_id")]
        public int ComboId { get; set; }
        [Ignore]
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        [Column("combo_desconto")]
        public decimal ValorComboDesconto { get; set; }
        [Column("valor_desconto")]
        public decimal ValorDescontoItem { get; set; }
        [Column("valor_original_item")]
        public decimal ValorOriginalItem { get; set; }
        [Column("valor")]
        public decimal ValorTotal { get; set; }

        //[Ignore]
        //public decimal valDesc { get; set; }


        //[Ignore]
        //public int qtditens_Acumulado { get; set; }




        public PedidoItem(Pedido p, int codpro, Produto produto, int qtditens, decimal valorDescontoItem, decimal prcitens, decimal valitens, int comboId)
        {
            Pedido = p;
            Produto = produto;
            ProdutoId = codpro;
            Quantidade = qtditens;
            ValorDescontoItem = valorDescontoItem;
            ValorOriginalItem = prcitens;
            ValorTotal = valitens;
            ComboId = comboId;
        }

        //Construtores
        public PedidoItem()
        {
        }

    }
}
