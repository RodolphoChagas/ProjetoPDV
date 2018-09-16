using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVModel
{
    public class Usuario
    {
        private static Usuario instance;
        private int _codUser;
        private string _nomeUser;
        private string _senha;

        public int codUser
        {
            get { return _codUser; }
            set
            {
                if (_codUser == 0)
                    _codUser = value;
            }
        }
        public string nomeUser
        {
            get { return _nomeUser; }
            set
            {
                if (_nomeUser == null)
                    _nomeUser = value;
            }
        }
        public string senha
        {
            get { return _senha; }
            set
            {
                if (_senha == null)
                    _senha = value;
            }
        }

        public Usuario(int codUser, string nomeUser)
        {
            this._codUser = codUser;
            this._nomeUser = nomeUser;
        }

        public static Usuario getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Usuario();
                }
                return instance;
            }
        }

        private Usuario() { }

    }
}
