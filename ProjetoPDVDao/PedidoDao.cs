using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPDVDao
{
    public class PedidoDao
    {
        public Pedido GetPedidoAberturaDeCaixa(DateTime? dataDoDia)
        {
            try
            {
                var dia = dataDoDia?.Day;
                var mes = dataDoDia?.Month;
                var ano = dataDoDia?.Year;

                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Pedido>("SELECT numdoc, data_digitacao, valor_total, observacao FROM Movdb INNER JOIN Operacao on Movdb.operacao_id = Operacao.operacao_id WHERE abre_caixa = 1 AND (DAY(data_digitacao)=@0 AND MONTH(data_digitacao)=@1 AND YEAR(data_digitacao)=@2)", dia, mes, ano);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a Abertura de Caixa do dia!" + ex.Message);
            }
        }


        public Pedido GetPedido (int pedidoId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Pedido>("SELECT * FROM Movdb WHERE numdoc=@0", pedidoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar a Abertura de Caixa do dia!" + ex.Message);
            }
        }

        public Pedido GetPedido(string nfiscal)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Pedido>("SELECT * FROM Movdb WHERE nfiscal=@0 And modelo = '65' order by NumDoc desc", nfiscal);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>Retorna uma lista com todos os pedidos já EMITIDOS dentro do período.
        /// </summary>
        public List<Pedido> GetPedidos(DateTime? dtInicial, DateTime? dtFinal)
        {
            try
            {
                //dtInicial = string.Format("{0:yyyy-MM-dd 00:00:00}", dtInicial.to);
                
                

                return (new PetaPoco.Database("stringConexao")).Query<Pedido>("SELECT * FROM Movdb WHERE CondDoc in('F') And (data_digitacao Between '" + dtInicial?.ToString("yyyy-MM-dd 00:00:00") + "' And '" + dtFinal?.ToString("yyyy-MM-dd 23:59:59") + "') ORDER BY numdoc").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Retorna uma lista com todos os pedidos já EMITIDOS dentro do período.
        /// </summary>
        public List<Pedido> GetPedidosDoCaixa(string dtInicial, string dtFinal)
        {
            try
            {
                //dtInicial = string.Format("{0:yyyy-MM-dd 00:00:00}", dtInicial.to);



                return (new PetaPoco.Database("stringConexao")).Query<Pedido>("SELECT Movdb.* FROM Movdb INNER JOIN Operacao ON Movdb.operacao_id = Operacao.operacao_id WHERE VND <> 0 AND CondDoc in('F') And (data_digitacao Between '" + dtInicial + "' And '" + dtFinal + "') ORDER BY data_digitacao").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Retorna uma lista com todos os pedidos já EMITIDOS dentro do período.
        /// </summary>
        public List<Pedido> GetPedidosDoCaixa(DateTime dtInicial, DateTime dtFinal)
        {
            try
            {
                //dtInicial = string.Format("{0:yyyy-MM-dd 00:00:00}", dtInicial.to);



                return (new PetaPoco.Database("stringConexao")).Query<Pedido>("SELECT Movdb.* FROM Movdb INNER JOIN Operacao ON Movdb.operacao_id = Operacao.operacao_id WHERE VND <> 0 AND CondDoc in('F') And (data_digitacao Between '" + dtInicial.ToString("yyyy-MM-dd 00:00:00") + "' And '" + dtFinal.ToString("yyyy-MM-dd 23:59:59") + "') ORDER BY data_digitacao").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Retorna uma lista com todos os pedidos já EMITIDOS dentro do período e condição.
        /// </summary>
        public List<Pedido> GetPedidos(int usuarioId, string dataInicial, string dataFinal, string condicao)
        {
            try
            {
                string query = string.Empty;

                if (!string.IsNullOrEmpty(condicao.Trim()))
                {
                    query = " AND " + condicao.Trim();
                }

                string usuario;
                string vendedor;


                if (usuarioId.Equals(0))
                    usuario = string.Empty;
                else
                    usuario = "Movdb.usuario_id = " + usuarioId + " AND ";


                return (new PetaPoco.Database("stringConexao")).Query<Pedido>("SELECT * FROM Movdb INNER JOIN Operacao ON Movdb.operacao_id = Operacao.operacao_id INNER JOIN Usuario ON Movdb.usuario_id = Usuario.CodUser WHERE " + usuario + " modelo = '65' And (DataDigitacao Between '" + dataInicial + "' And '" + dataFinal + "') " + query + " order by data_nfiscal desc").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Atualiza a tabela 'Movdb' com a Chave, Protocolo, e o status do pedido.
        /// </summary>
        //public bool Update_ChaveProtocolo_condDoc_StatNFCe(int numdoc, string chave, string protocolo, string statNFCe)
        public bool AtualizaChaveProtocoloStatusStatusNFCe(int numdoc, string chave, string protocolo, string statNFCe)
        {
            try
            {
                if ((new PetaPoco.Database("stringConexao")).Update("Update Movdb Set Chave='" + chave + "' ,Protocolo='" + protocolo + "', status_nfce = '" + statNFCe + "' Where NumDoc=" + numdoc) != 1)
                    return false;
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }


    }
}
