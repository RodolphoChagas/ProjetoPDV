using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPDVModel;

namespace ProjetoPDVDao
{
    public class ProdutoCategoriaDao
    {

        public List<ProdutoCategoria> GetCategorias()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<ProdutoCategoria>("SELECT * FROM Produto_Categoria ORDER BY id").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a lista de Categorias no banco de dados!");
            }
        }

        public ProdutoCategoria GetCategoriaPorProduto(int produtoId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<ProdutoCategoria>("SELECT Produto_Categoria.id, Produto_Categoria.Descricao FROM Produto_Categoria INNER JOIN Produto ON Produto_Categoria.id = Produto.Categoria_Id WHERE Produto.produto_id=@0", produtoId);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao carregar a Categoria do Produto de código: " + produtoId);
            }
        }

        public ProdutoCategoria GetCategoria(int categoriaId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<ProdutoCategoria>("SELECT Produto_Categoria.id, Descricao FROM Produto_Categoria WHERE id=@0", categoriaId);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao carregar a Categoria do Produto de código: " + categoriaId);
            }
        }

        public int GetQuantidadeDeItensPorCategoria(int categoriaId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<int>("SELECT Count(P.produto_id) FROM Produto_Categoria PC INNER JOIN Produto P ON P.Categoria_Id = PC.Id WHERE PC.Id=@0", categoriaId);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao carregar a quantidade de itens das Categorias: " + categoriaId);
            }
        }




    }
}
