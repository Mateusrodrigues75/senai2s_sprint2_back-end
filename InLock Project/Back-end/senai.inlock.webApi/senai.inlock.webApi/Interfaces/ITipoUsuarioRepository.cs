using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        void CadastrarTipoUsuario(TipoUsuarioDomain NovoEstudio);

        List<TipoUsuarioDomain> ListarTipoUsuario();

        void Deletar(int id);
    }
}
