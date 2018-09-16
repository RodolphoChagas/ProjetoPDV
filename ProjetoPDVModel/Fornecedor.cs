using PetaPoco;


namespace ProjetoPDVModel
{
    [PrimaryKey("fornecedor_id")]
    public class Fornecedor
    {
        [Column("fornecedor_id")]
        public int FornecedorId { get; set; }

        public string Descricao { get; set; }

        [Column("cnpj_cpf")]
        public string CnpjCpf { get; set; }

        [Column("inscest_rg")]
        public string InscEstRG { get; set; }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Uf { get; set; }

        public string Email { get; set; }
        [Column("telefone_principal")]
        public string TelefonePrincipal { get; set; }
        public string Observacao { get; set; }

    }
}
