using senai.spmedicalgroup.webapi.Contexts;
using senai.spmedicalgroup.webapi.Domains;
using senai.spmedicalgroup.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto Contexto por onde serão chamados os Métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza um Usuário pelo Id
        /// </summary>
        /// <param name="id">Id do Usuário que será atualizado</param>
        /// <param name="UsuarioAtt">Objeto UsuarioAtt com as informações atualizadas</param>
        public void Atualizar(int id, Usuario UsuarioAtt)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            if (UsuarioAtt.IdTipoUsuario != null && UsuarioAtt.NomeUsuario != null && UsuarioAtt.Email != null && UsuarioAtt.Senha != null)
            {
                UsuarioBuscado.IdTipoUsuario = UsuarioAtt.IdTipoUsuario;
                UsuarioBuscado.NomeUsuario = UsuarioAtt.NomeUsuario;
                UsuarioBuscado.Email = UsuarioAtt.Email;
                UsuarioBuscado.Senha = UsuarioAtt.Senha;
            }

            ctx.Usuarios.Update(UsuarioBuscado);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Usuário pelo id 
        /// </summary>
        /// <param name="id">id do Usuário que será buscado</param>
        /// <returns>Usuário Buscado</returns>
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(t => t.IdUsuario == id);
        }

        /// <summary>
        /// Método que cadastra uma novo Usuario
        /// </summary>
        /// <param name="NovoUsuario">id do Usuario que será cadastrado</param>
        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Usuário existente
        /// </summary>
        /// <param name="id">Id do Usuário que será deletado</param>
        public void Deletar(int id)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi buscado</returns>
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(l => l.Email == email && l.Senha == senha);
        }

    }
}
