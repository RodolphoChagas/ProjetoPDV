using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPDVDao
{
    public class FornecedorDao
    {

        public bool isFornecedorCadastrado(string cnpjCpf)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<bool>("SELECT * FROM Fornecedor WHERE cnpj_cpf = @0", cnpjCpf);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o Fornecedor!" + ex.Message);
            }
        }

        public Fornecedor GetFornecedor(int fornecedorId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Fornecedor>("SELECT * FROM Fornecedor WHERE fornecedor_id=@0", fornecedorId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o Fornecedor!" + ex.Message);
            }
        }


        /// <summary>Retorna uma lista com todos os Fornecedores.
        /// </summary>
        public List<Fornecedor> GetFornecedores()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<Fornecedor>("SELECT * FROM Fornecedor").ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Retorna uma lista com todos os Fornecedores com uma condição.
        /// </summary>
        public List<Fornecedor> GetFornecedores(string condicao)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Query<Fornecedor>("SELECT * FROM Fornecedor WHERE " + condicao).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
