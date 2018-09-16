using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace ProjetoPDVModel
{
    public class Cliente
    {
        [Column("cliente_id")]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public int TipCli { get; set; }
        [Column("cnpj_cpf")]
        public string CnpjCpf { get; set; }
        //public string CGC { get; set; }
        [Column("insc_est")]
        public string InsCest { get; set; }
        //public string CPF { get; set; }
        public string Email { get; set; }
        [Column("telefone_comercial")]
        public string TelefoneComercial { get; set; }
        [Column("celular")]
        public string Celular { get; set; }
        [Column("celular2")]
        public string Celular2 { get; set; }
        public string Observacao { get; set; }
    }
}
