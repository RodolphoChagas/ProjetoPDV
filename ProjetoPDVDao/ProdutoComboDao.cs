using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVDao
{
    public class ProdutoComboDao
    {

        public ProdutoCombo GetCombo(int comboId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<ProdutoCombo>("SELECT Produto_Combo.*, SUM(valor) AS ValorCombo FROM Produto_Combo INNER JOIN Produto_Combo_Item ON Produto_Combo.id = Produto_Combo_Item.combo_id  WHERE Produto_Combo.id=@0 GROUP BY Produto_Combo.id, Produto_Combo.descricao, Produto_Combo.status, Produto_Combo.data_inicio, Produto_Combo.data_atualizacao ORDER BY Produto_Combo.descricao", comboId);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao carregar o Combo de código: " + comboId);
            }
        }

        public List<ProdutoCombo> GetCombos()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<ProdutoCombo>("SELECT Produto_Combo.*, SUM(valor) AS ValorCombo FROM Produto_Combo INNER JOIN Produto_Combo_Item ON Produto_Combo.id = Produto_Combo_Item.combo_id GROUP BY Produto_Combo.id, Produto_Combo.descricao, Produto_Combo.status, Produto_Combo.data_inicio, Produto_Combo.data_atualizacao ORDER BY Produto_Combo.descricao").ToList();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao carregar todos os Combos");
            }
        }
        public List<ProdutoCombo> GetCombos(string condicao)
        {
            try
            {
                return  (new PetaPoco.Database("stringConexao")).Query<ProdutoCombo>("SELECT Produto_Combo.*, SUM(valor) AS ValorCombo FROM Produto_Combo INNER JOIN Produto_Combo_Item ON Produto_Combo.id = Produto_Combo_Item.combo_id  WHERE " + condicao + " GROUP BY Produto_Combo.id, Produto_Combo.descricao, Produto_Combo.status, Produto_Combo.data_inicio, Produto_Combo.data_atualizacao ORDER BY Produto_Combo.descricao").ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar todos os Combos");
            }
        }

    }
}
