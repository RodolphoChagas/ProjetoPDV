using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPDVModel;

namespace ProjetoPDVDao
{
    public class EnderecoDao
    {
        public Endereco GetEnderecoEmitente()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Endereco>("SELECT * FROM Controle");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
