using senai.spmedicalgroup.webapi.Contexts;
using senai.spmedicalgroup.webapi.Domains;
using senai.spmedicalgroup.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        /// <summary>
        /// Objeto Contexto por onde serão chamados os Métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza um Prontuario pelo Id
        /// </summary>
        /// <param name="id">Id do Prontuario que será atualizado</param>
        /// <param name="ProntuarioAtt">Objeto ProntuarioAtt com as informações atualizadas</param>
        public void Atualizar(int id, Prontuario ProntuarioAtt) {
            Prontuario ProntuarioBuscado = ctx.Prontuarios.Find(id);

            if (ProntuarioAtt.IdUsuario != null && ProntuarioAtt.NomePaciente != null && ProntuarioAtt.Rg != null && ProntuarioAtt.Cpf != null && ProntuarioAtt.TelefonePaciente != null && ProntuarioAtt.EnderecoPaciente != null && ProntuarioAtt.DataNascimento != DateTime.UtcNow)
            {
                ProntuarioBuscado.IdUsuario = ProntuarioAtt.IdUsuario;
                ProntuarioBuscado.NomePaciente = ProntuarioAtt.NomePaciente;
                ProntuarioBuscado.Rg = ProntuarioAtt.Rg;
                ProntuarioBuscado.Cpf = ProntuarioAtt.Cpf;
                ProntuarioBuscado.TelefonePaciente = ProntuarioAtt.TelefonePaciente;
                ProntuarioBuscado.EnderecoPaciente = ProntuarioAtt.EnderecoPaciente;
                ProntuarioBuscado.DataNascimento = ProntuarioAtt.DataNascimento;
            }

            ctx.Prontuarios.Update(ProntuarioBuscado);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Prontuario pelo id 
        /// </summary>
        /// <param name="id">id do Prontuario que será buscado</param>
        /// <returns>Prontuario Buscado</returns>
        public Prontuario BuscarPorId(int id)
        {
            return ctx.Prontuarios.FirstOrDefault(t => t.IdProntuario == id);
        }

        /// <summary>
        /// Método que cadastra uma novo Prontuario
        /// </summary>
        public void Cadastrar(Prontuario NovoProntuario)
        {
            ctx.Prontuarios.Add(NovoProntuario);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Prontuario existente
        /// </summary>
        /// <param name="id">Id do Prontuario que será deletado</param>
        public void Deletar(int id)
        {
            Prontuario ProntuarioBuscado = ctx.Prontuarios.Find(id);

            ctx.Prontuarios.Remove(ProntuarioBuscado);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Prontuario do SPMedical Group 
        /// </summary>
        /// <returns>Lista com os Prontuarios</returns>
        public List<Prontuario> Listar()
        {
            return ctx.Prontuarios.ToList();
        }
    }
}
