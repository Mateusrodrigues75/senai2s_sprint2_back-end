using senai.hroads.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webapi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();
        TipoUsuario BuscarPorId(int id);
        void Cadastrar(TipoUsuario novoTipoUsuario);
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);
        void Deletar(int id);
    }
}
