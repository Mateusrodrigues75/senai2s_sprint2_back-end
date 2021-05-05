using senai.spmedicalgroup.webapi.Contexts;
using senai.spmedicalgroup.webapi.Domains;
using senai.spmedicalgroup.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        /// <summary>
        /// Objeto Contexto por onde serão chamados os Métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza uma Especialidade pelo Id
        /// </summary>
        /// <param name="id">Id da especialidade que será atualizada</param>
        /// <param name="EspecialidadeAtt">Objeto EspecialidadeAtt com as informações atualizadas</param>
        public void Atualizar(int id, Especialidade EspecialidadeAtt)
        {
            Especialidade EspecialidadeBuscada = ctx.Especialidades.Find(id);

            if (EspecialidadeAtt.NomeEspecialidade != null && EspecialidadeAtt.Medicos != null)
            {
                EspecialidadeBuscada.NomeEspecialidade = EspecialidadeAtt.NomeEspecialidade;
                EspecialidadeBuscada.Medicos = EspecialidadeAtt.Medicos;

            }

            ctx.Especialidades.Update(EspecialidadeBuscada);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma especialidade pelo id 
        /// </summary>
        /// <param name="id">id da especialidade que será buscada</param>
        /// <returns>Especialidade Buscada</returns>
        public Especialidade BuscarPorId(int id)
        {
            return ctx.Especialidades.FirstOrDefault(t => t.IdEspecialidade == id);
        }

        /// <summary>
        /// Método que cadastra uma nova Especialidade
        /// </summary>
        public void Cadastrar(Especialidade NovaEspecialidade)
        {
            ctx.Especialidades.Add(NovaEspecialidade);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Especialidade existente
        /// </summary>
        /// <param name="id">Id da clinica que será deletada</param>
        public void Deletar(int id)
        {
            Especialidade EspecialidadeBuscada = ctx.Especialidades.Find(id);

            ctx.Especialidades.Remove(EspecialidadeBuscada);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as Especialidades do SPMedical Group 
        /// </summary>
        /// <returns>Lista com as Especialidades</returns>
        public List<Especialidade> Listar()
        {
            return ctx.Especialidades.ToList();
        }
    }
}
