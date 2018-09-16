using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVDao
{
    public class OperacaoDao
    {

        public Operacao GetOperacaoPorPedido(int numDoc)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Operacao>("SELECT Operacao.* FROM Operacao,Movdb WHERE Operacao.operacao_id = Movdb.operacao_id AND NumDoc=@0", numDoc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Operacao GetOperacao(int operacaoId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Operacao>("SELECT * FROM Operacao WHERE operacao_id=@0", operacaoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
