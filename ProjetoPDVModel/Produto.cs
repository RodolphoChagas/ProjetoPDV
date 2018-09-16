using System;
using PetaPoco;

namespace ProjetoPDVModel
{
    [PrimaryKey("produto_id")]
    public class Produto
    {
        [Column("produto_id")]
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        [Column("data_inicio")]
        public DateTime? DataInicio { get; set; }
        [Column("data_atualizacao")]
        public DateTime? DataUltAtualizacao { get; set; }
        [Column("preco_venda")]
        public decimal PrecoDeVenda { get; set; }
        [Column("preco_custo")]
        public decimal PrecoDeCusto { get; set; }
        public int Status { get; set; }
        public int Peso { get; set; }

        [Column("categoria_id")]
        public int CategoriaId { get; set; }
        [Ignore]
        public ProdutoCategoria Categoria { get; set; }
        [Column("grupo_id")]
        public int GrupoId { get; set; }
        [Ignore]
        public ProdutoGrupoFiscal GrupoFiscal { get; set; }

        //Construtores
        public Produto() { }
    }
}
