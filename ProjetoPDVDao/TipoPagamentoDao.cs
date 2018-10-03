using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPDVModel;

namespace ProjetoPDVDao
{
    public class TipoPagamentoDao
    {

        public TipoPagamento GetTipoPagamento(int pagamentoId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<TipoPagamento>("SELECT * FROM TipoPagamento WHERE id=@0", pagamentoId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoPagamento GetTipoPagamento(string numDoc)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<TipoPagamento>("SELECT * FROM TipoPagamento tp INNER JOIN Movdb m ON tp.CodPagamento = m.CodPagamento WHERE numdoc =@0", numDoc);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoPagamento> GetPagametosDoPedido(int numDoc)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<TipoPagamento>("SELECT p.*, valor as valorPago, observacao FROM Movdb_Pagamento_Rel m INNER JOIN TipoPagamento p ON m.pagamento_id = p.id WHERE NumDoc=@0", numDoc).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoPagamento> GetTiposDePagamentos()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<TipoPagamento>("SELECT * FROM TipoPagamento WHERE is_available = 0 order by DescTipoPgto").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
