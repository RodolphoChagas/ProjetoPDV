using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;

namespace ProjetoPDVModel
{
    public class Endereco
    {
        public Endereco() { }

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Cep { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Uf { get; set; }
    }
}
