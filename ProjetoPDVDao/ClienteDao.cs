using ProjetoPDVModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVDao
{
    public class ClienteDao
    {

        private string query;



        public bool isClienteCadastrado(string cnpjCpf)
        {
            try
            {
                object ret = (new PetaPoco.Database("stringConexao")).ExecuteScalar<object>("select cliente_id from Cliente where cnpj_cpf = @0", cnpjCpf);

                if (ret == null)
                    return false;

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public object InsertCliente(string cnpjCpf, string nome, string email)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).Insert("Cliente", "cliente_id", new { cnpj_cpf = cnpjCpf, nome = nome, email = email });
            }
            catch (Exception)
            {
                throw;
            }
        }


        public object InsertCliente(Pedido pedido)
        {
            try
            {
                //return (new PetaPoco.Database("stringConexao")).Insert("Movdb", "NumDoc", true, pedido);
                return (new PetaPoco.Database("stringConexao")).Insert(pedido);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente GetClientePorPedido(int numDoc)
        {
            try
            {
                query = "SELECT C.* FROM Cliente C,Movdb WHERE C.cliente_id = Movdb.cliente_id AND NumDoc=@0";

                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Cliente>(query, numDoc);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public Cliente GetCliente(int clienteId)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Cliente>("SELECT * FROM Cliente C WHERE C.cliente_id = @0", clienteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente GetClienteConsumidorNaoIdentificado()
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Cliente>("SELECT * FROM Cliente C WHERE LTRIM(RTRIM(C.Nome)) = 'CONSUMIDOR NÃO IDENTIFICADO'");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente GetCliente(string cnpjCpf)
        {
            try
            {
                return (new PetaPoco.Database("stringConexao")).SingleOrDefault<Cliente>("SELECT * FROM Cliente C WHERE C.cnpj_cpf = @0", cnpjCpf);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
