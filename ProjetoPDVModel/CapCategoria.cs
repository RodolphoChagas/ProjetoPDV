using PetaPoco;
using System.Collections.Generic;

namespace ProjetoPDVModel
{

    [TableName("Cap_Categoria")]
    [PrimaryKey("categoria_id")]
    public class CapCategoria
    {
        [Column("categoria_id")]
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }

        [Ignore]
        public List<CapSubcategoria> SubCategorias { get; set; }

    }
}
