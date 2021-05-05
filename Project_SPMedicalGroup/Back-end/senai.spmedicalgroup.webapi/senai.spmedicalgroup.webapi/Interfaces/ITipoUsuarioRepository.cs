using senai.spmedicalgroup.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Método que cadastra uma novo Tipo de Usuario
        /// </summary>
        /// <param name="NovoTipoUsuario">id do Tipo de Usuário que será buscado</param>
        public void Cadastrar(TipoUsuario NovoTipoUsuario);

        /// <summary>
        /// Lista todos os Tipos de Usuários do SPMedical Group 
        /// </summary>
        /// <returns>Lista com os Tipos de Usuários</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Busca um Tipo de Usuário pelo id 
        /// </summary>
        /// <param name="id">id do Tipo de Usuário que será buscado</param>
        /// <returns>Tipo de Usuário Buscado</returns>
        TipoUsuario BuscarPorId(int id);

        /// <summary>
        /// Atualiza um Tipo de Usuário pelo Id
        /// </summary>
        /// <param name="id">Id do Tipo de Usuário que será atualizado</param>
        /// <param name="TipoUsuarioAtt">Objeto TipoUsuarioAtt com as informações atualizadas</param>
        void Atualizar(int id, TipoUsuario TipoUsuarioAtt);

        /// <summary>
        /// Deleta um Tipo de Usuário existente
        /// </summary>
        /// <param name="id">Id do Tipo de Usuário que será deletado</param>
        void Deletar(int id);
    }
}
