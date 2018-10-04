using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVDao
{
    public class PedidoItemDao
    {

        /// <summary>
        /// Retorna uma lista com todos os itens do pedido passado por parametro.
        /// </summary>
        /// <param name="numDoc"></param>
        /// <returns></returns>
        public List<PedidoItem> getlst_Itens_AcumuladodoMes(DateTime data)
        {
            try
            {
                string strAno = data.Year.ToString();
                string strMes = data.Month.ToString();
                string strDia = data.Day.ToString();

                string queryDia = "(YEAR(data_digitacao) = '" + strAno + "' and MONTH(data_digitacao) = '" + strMes + "' and DAY(data_digitacao) = '" + strDia + "') ";
                string queryMes = "(YEAR(data_digitacao) = '" + strAno + "' and MONTH(data_digitacao) = '" + strMes + "') ";
                
                return (new PetaPoco.Database("stringConexao")).Query<PedidoItem>("SELECT mi.produto_id, descricao, CASE WHEN (SELECT SUM(quantidade) FROM Movdb INNER JOIN Movitens ON Movdb.NumDoc = MovItens.NumDoc " +
                                                                                    "WHERE(Movitens.produto_id = mi.produto_id and modelo = '65' AND CondDoc = 'F') AND " + queryDia +
                                                                                    "group by mi.produto_id) IS NULL THEN 0 ELSE(SELECT SUM(quantidade) " +
                                                                                    "FROM Movdb INNER JOIN Movitens ON Movdb.NumDoc = MovItens.NumDoc " +
                                                                                    "WHERE(Movitens.produto_id = mi.produto_id and modelo = '65' AND CondDoc = 'F') AND " + queryDia +
                                                                                    "group by mi.produto_id) END AS quantidade, SUM(quantidade) as numdoc, SUM(valor) as Valor " +
                                                                                    "FROM Movdb INNER JOIN Movitens mi ON Movdb.NumDoc = mi.NumDoc " +
                                                                                    "INNER JOIN Produto ON mi.produto_id = Produto.produto_id " +
                                                                                    "WHERE(modelo = '65' AND CondDoc = 'F') AND " + queryMes +
                                                                                    "group by descricao, mi.produto_id " +
                                                                                    "order by descricao").ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// Retorna uma lista com todos os itens do pedido passado por parametro.
        /// </summary>
        /// <param name="numDoc"></param>
        /// <returns></returns>
        public List<PedidoItem> GetItensDoPedido(int pedidoId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<PedidoItem>("SELECT MI.* FROM MovItens MI Inner Join Produto P On MI.produto_id = P.produto_id WHERE NumDoc =@0 Order by descricao", pedidoId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
