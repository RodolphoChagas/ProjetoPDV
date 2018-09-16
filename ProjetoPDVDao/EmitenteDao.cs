using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPDVModel;

namespace ProjetoPDVDao
{
    public class EmitenteDao
    {
        public bool SelecionaEmitente()
        {
            var emitente = (new PetaPoco.Database("stringConexao")).SingleOrDefault<Emitente>("SELECT CNPJ, [Razão Social] as nome, InscEst, [NomeFant] as nomefantasia FROM Controle");
            emitente.Endereco = (new EnderecoDao()).GetEnderecoEmitente();

            if (emitente != null)
            {
                Emitente.GetInstancia.Cnpj = emitente.Cnpj;
                Emitente.GetInstancia.InsCest = emitente.InsCest;
                Emitente.GetInstancia.Endereco = emitente.Endereco;
                Emitente.GetInstancia.Nome = emitente.Nome;
                Emitente.GetInstancia.NomeFantasia = emitente.NomeFantasia;

                return true;
            }
            return false;
        }


    }
}
