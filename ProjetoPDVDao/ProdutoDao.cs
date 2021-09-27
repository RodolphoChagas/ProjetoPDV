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





        //GAMBIARRA
        public List<Produto> GetProdutosVendidos(string dataInicial, string dataFinal)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<Produto>("select movitens.produto_id, produto.descricao, sum(quantidade) as estoque, sum(valor) as preco_venda from movitens inner join produto on movitens.produto_id = produto.produto_id inner join movdb on movdb.numdoc = movitens.numdoc inner join operacao on movdb.operacao_id = operacao.operacao_id where vnd <> 0 and conddoc = 'F' And (data_digitacao Between '" + dataInicial + "' And '" + dataFinal + "') group by movitens.produto_id, produto.descricao order by estoque desc").ToList();
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
                return (new PetaPoco.Database("stringConexao")).Query<Produto>("SELECT * FROM Produto WHERE " + condicao + " AND status = 0 ORDER BY Descricao").ToList();
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
                return (new PetaPoco.Database("stringConexao")).Query<Produto>("SELECT * FROM Produto WHERE Categoria_id=@0 AND Produto.status = 0 ORDER BY Descricao", categoriaId).ToList();
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
