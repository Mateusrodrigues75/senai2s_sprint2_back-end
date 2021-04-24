using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IUsuarioRepository
    {

        void CadastrarUsuario(UsuarioDomain NovoUsuario);

        List<UsuarioDomain> ListarUsuarios();

        void Deletar(int id);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
