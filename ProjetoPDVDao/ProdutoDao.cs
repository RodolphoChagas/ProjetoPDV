using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPDVModel;

namespace ProjetoPDVDao
{
    public class ProdutoDao
    {
        /// <summary>
        /// Retorna uma lista de todos os Produtos cadastrados.
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        public List<Produto> GetProdutos()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<Produto>("SELECT * FROM Produto ORDER BY descricao").ToList();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar a lista de Produtos no banco de dados!");
            }
        }


        /// <summary>
        /// Retorna uma lista de todos os Produtos cadastrados.
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        public List<Produto> GetProdutos(string condicao)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<Produto>("SELECT * FROM Produto WHERE " + condicao + " ORDER BY Descricao").ToList();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar a lista de Produtos no banco de dados!");
            }
        }

        public List<Produto> GetProdutosPorCategoria(int categoriaId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<Produto>("SELECT * FROM Produto WHERE Categoria_id=@0 ORDER BY Descricao", categoriaId).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar a lista de Produtos no banco de dados!");
            }
        }
        
        public Produto GetProduto(int produtoId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Produto>("SELECT * FROM Produto WHERE produto_id=@0", produtoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar o Produto de código: " + produtoId + Environment.NewLine + ex.Message);
            }
        }

    }
}
