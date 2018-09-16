using PetaPoco;

namespace ProjetoPDVModel
{
    [TableName("Produto_Categoria")]
    [PrimaryKey("id")]
    public class ProdutoCategoria
    {
        [Column("id")]
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }

        public ProdutoCategoria() { }

        public ProdutoCategoria(int categoriaId, string descricao)
        {
            CategoriaId = categoriaId;
            Descricao = descricao;
        }
    }
}
