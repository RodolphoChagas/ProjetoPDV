using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVDao
{
    public class ControleFiscalDao
    {
        public int GetUltimoNumeroNFiscalGerado()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).ExecuteScalar<int>("select NFiscal from Controle where ChvControle = 1");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ControleFiscal getControle()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<ControleFiscal>("select * from Controle where ChvControle = 1");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
