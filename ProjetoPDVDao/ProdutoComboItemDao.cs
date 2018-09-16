using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
using ProjetoPDVModel;

namespace ProjetoPDVDao
{
    public class ProdutoComboItemDao
    {

        public Produto GetProdutoDoItem(int comboId, int comboItemId, int produtoId)
        {
            try
            {
                return (new Database("stringConexao")).SingleOrDefault<Produto>("SELECT p.produto_id, p.descricao, p_item.valor as preco_venda FROM Produto p INNER JOIN Produto_Combo_Item_Rel p_rel ON p.produto_id = p_rel.produto_id INNER JOIN Produto_Combo_Item p_item ON p_rel.combo_item_id = p_item.id WHERE p_rel.combo_id=@0 AND combo_item_id=@1 AND p.produto_id=@2", comboId, comboItemId, produtoId);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao carregar o Produto de código: " + produtoId);
            }
        }

        public List<ProdutoComboItem> GetItensDoCombo(int comboId)
        {
            try
            {
                var itens = (new Database("stringConexao")).Query<ProdutoComboItem>("SELECT * FROM Produto_Combo_Item WHERE combo_id=@0 ORDER BY id", comboId).ToList();
                //foreach (ProdutoComboItem item in itens)
                //{
                //    item.Produtos.AddRange(.Produtos = (new ProdutoComboItemDao()).GetProdutosDoItem(_combo.Itens[i].ComboItemId););
                //}
                return itens;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar a lista de Categorias no banco de dados!");
            }
        }

        public List<Produto> GetProdutosDoItem(int itemId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<Produto>("SELECT p.produto_id, p.descricao FROM Produto_Combo_Item_Rel prel INNER JOIN Produto p ON prel.produto_id = p.produto_id WHERE combo_item_id=@0", itemId).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao buscar a lista de Categorias no banco de dados!");
            }
        }

        public void DeletaTodosOsProdutosDoItem(int comboId, int comboItemId)
        {
            using (var db = new Database("stringConexao"))
            {
                try
                {
                    db.BeginTransaction();

                    var sql = @"DELETE [Produto_Combo_Item_Rel] WHERE combo_id = " + comboId + " AND combo_item_id = " + comboItemId;

                    db.Execute(sql);
                    db.CompleteTransaction();
                }
                catch (Exception)
                {
                    db.AbortTransaction();
                    throw new Exception("Erro ao inserir os produtos no Item, tente novamente!");
                }

            }
        }

    }
}
