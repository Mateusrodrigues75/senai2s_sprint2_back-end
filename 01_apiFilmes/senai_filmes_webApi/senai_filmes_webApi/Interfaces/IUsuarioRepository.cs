using senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// valida o usuario    
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Objeto UsuarioDomain que foi buscado</returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
