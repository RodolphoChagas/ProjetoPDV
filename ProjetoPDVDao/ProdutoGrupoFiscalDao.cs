using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPDVModel;

namespace ProjetoPDVDao
{
    public class ProdutoGrupoFiscalDao
    {
        public List<ProdutoGrupoFiscal> GetGruposFiscais()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<ProdutoGrupoFiscal>("SELECT * FROM Produto_GrupoFiscal ORDER BY Descricao").ToList();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar a lista de Grupo NCM no banco de dados!");
            }
        }

        public ProdutoGrupoFiscal GetGrupoFiscalPorProduto(int produtoId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<ProdutoGrupoFiscal>("SELECT Produto_GrupoFiscal.* FROM Produto_GrupoFiscal INNER JOIN Produto ON Produto_GrupoFiscal.Id = Produto.Grupo_Id WHERE Produto.produto_id=@0", produtoId);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao carregar a Categoria do Produto de código: " + produtoId);
            }
        }







    }
}
