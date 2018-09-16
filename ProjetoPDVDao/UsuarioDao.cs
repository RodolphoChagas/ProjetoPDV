using ProjetoPDVModel;

namespace ProjetoPDVDao
{
    public class UsuarioDao
    {
        public bool SelecionaUsuario(string nomeUsuario, string senha)
        {
            var user = (new PetaPoco.Database("stringConexao")).SingleOrDefault<Usuario>("SELECT CodUser, NomeUser, Senha FROM Usuario WHERE NomeUser=@0 AND Senha=@1", nomeUsuario, senha);

            if (user == null) return false;

            Usuario.getInstance.codUser = user.codUser;
            Usuario.getInstance.nomeUser = user.nomeUser;
            Usuario.getInstance.senha = user.senha;

            return true;
        }

        public Usuario GetUsuario(int usuarioId)
        {
            var user = (new PetaPoco.Database("stringConexao")).SingleOrDefault<Usuario>("SELECT CodUser, NomeUser, Senha FROM Usuario WHERE coduser=@0", usuarioId);

            return user;
        }
    }
}