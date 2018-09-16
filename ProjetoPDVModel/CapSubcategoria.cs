using PetaPoco;


namespace ProjetoPDVModel
{
    [TableName("Cap_Subcategoria")]
    [PrimaryKey("subcategoria_id")]
    public class CapSubcategoria
    {
        [Column("subcategoria_id")]
        public int SubcategoriaId { get; set; }
        [Column("categoria_id")]
        public int CategoriaId { get; set; }
        [Ignore]
        public CapCategoria Categoria { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }

    }
}
