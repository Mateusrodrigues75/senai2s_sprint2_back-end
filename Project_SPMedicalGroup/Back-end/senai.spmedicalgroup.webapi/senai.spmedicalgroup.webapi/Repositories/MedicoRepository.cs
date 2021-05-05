using senai.spmedicalgroup.webapi.Contexts;
using senai.spmedicalgroup.webapi.Domains;
using senai.spmedicalgroup.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        /// <summary>
        /// Objeto Contexto por onde serão chamados os Métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza um Medico pelo Id
        /// </summary>
        /// <param name="id">Id do Medico que será atualizado</param>
        /// <param name="MedicoAtt">Objeto MedicoAtt com as informações atualizadas</param>
        public void Atualizar(int id, Medico MedicoAtt)
        {
            Medico MedicoBuscado = ctx.Medicos.Find(id);

            if (MedicoAtt.IdClinica != null && MedicoAtt.IdUsuario != null && MedicoAtt.IdEspecialidade != null && MedicoAtt.NomeMedico != null && MedicoAtt.Crm != null)
            {
                MedicoBuscado.IdClinica = MedicoAtt.IdClinica;
                MedicoBuscado.IdUsuario = MedicoAtt.IdUsuario;
                MedicoBuscado.IdEspecialidade = MedicoAtt.IdEspecialidade;
                MedicoBuscado.NomeMedico = MedicoAtt.NomeMedico;
                MedicoBuscado.Crm = MedicoAtt.Crm;
            }

            ctx.Medicos.Update(MedicoBuscado);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Medico pelo id 
        /// </summary>
        /// <param name="id">id do Medico que será buscado</param>
        /// <returns>Medico Buscado</returns>
        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(t => t.IdMedico == id);
        }

        /// <summary>
        /// Método que cadastra uma novo Medico
        /// </summary>
        public void Cadastrar(Medico NovoMedico)
        {
            ctx.Medicos.Add(NovoMedico);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um cadastro de um Medico existente
        /// </summary>
        /// <param name="id">Id do Medico que será deletado</param>
        public void Deletar(int id)
        {
            Medico MedicoBuscado = ctx.Medicos.Find(id);

            ctx.Medicos.Remove(MedicoBuscado);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Medicos do SPMedical Group 
        /// </summary>
        /// <returns>Lista com os Medicos</returns>
        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }
    }
}
