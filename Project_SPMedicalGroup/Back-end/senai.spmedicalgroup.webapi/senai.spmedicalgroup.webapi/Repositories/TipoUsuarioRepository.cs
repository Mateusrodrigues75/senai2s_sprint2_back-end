using senai.spmedicalgroup.webapi.Contexts;
using senai.spmedicalgroup.webapi.Domains;
using senai.spmedicalgroup.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto Contexto por onde serão chamados os Métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza um Tipo de Usuário pelo Id
        /// </summary>
        /// <param name="id">Id do Tipo de Usuário que será atualizado</param>
        /// <param name="TipoUsuarioAtt">Objeto TipoUsuarioAtt com as informações atualizadas</param>
        public void Atualizar(int id, TipoUsuario TipoUsuarioAtt)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (TipoUsuarioAtt.TituloTipoUsuario != null)
            {
                TipoUsuarioBuscado.TituloTipoUsuario = TipoUsuarioAtt.TituloTipoUsuario;
            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Tipo de Usuário pelo id 
        /// </summary>
        /// <param name="id">id do Tipo de Usuário que será buscado</param>
        /// <returns>Tipo de Usuário Buscado</returns>
        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        /// <summary>
        /// Método que cadastra uma novo Tipo de Usuario
        /// </summary>
        /// <param name="NovoTipoUsuario">id do Tipo de Usuário que será buscado</param>
        public void Cadastrar(TipoUsuario NovoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(NovoTipoUsuario);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Tipo de Usuário existente
        /// </summary>
        /// <param name="id">Id do Tipo de Usuário que será deletado</param>
        public void Deletar(int id)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
