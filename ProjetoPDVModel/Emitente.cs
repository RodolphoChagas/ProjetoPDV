using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVModel
{
    public class Emitente
    {

        private static Emitente _instancia;

        private string _cnpj { get; set; }
        private string _inscest { get; set; }
        private string _nome { get; set; }
        private string _nomefantasia { get; set; }
        private Endereco _endereco { get; set; }


        public static Emitente GetInstancia => _instancia ?? (_instancia = new Emitente());

        public string Cnpj
        {
            get => _cnpj;
            set
            {
                if (_cnpj == null)
                    _cnpj = value;
            }
        }

        public string InsCest
        {
            get => _inscest;
            set
            {
                if (_inscest == null)
                    _inscest = value;
            }
        }

        public string Nome
        {
            get => _nome;
            set
            {
                if (_nome == null)
                    _nome = value;
            }
        }

        public string NomeFantasia
        {
            get => _nomefantasia;
            set
            {
                if (_nomefantasia == null)
                    _nomefantasia = value;
            }
        }

        public Endereco Endereco
        {
            get => _endereco;
            set
            {
                if (_endereco == null)
                    _endereco = value;
            }
        }

    }
}
