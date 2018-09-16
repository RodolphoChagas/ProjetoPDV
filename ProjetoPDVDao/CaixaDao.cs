using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVDao
{
    public class CaixaDao
    {
        public bool isCaixaFechado(DateTime? data)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<bool>("SELECT * FROM FechaCaixa WHERE DAY(data)=@0 AND MONTH(data)=@1 AND YEAR(data)=@2", data?.Day, data?.Month, data?.Year);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o Fornecedor!" + ex.Message);
            }
        }

    }
}
