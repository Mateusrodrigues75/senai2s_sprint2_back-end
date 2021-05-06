using Microsoft.EntityFrameworkCore;
using senai.spmedicalgroup.webapi.Contexts;
using senai.spmedicalgroup.webapi.Domains;
using senai.spmedicalgroup.webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        /// <summary>
        /// Objeto Contexto por onde serão chamados os Métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza uma clinica pelo Id
        /// </summary>
        /// <param name="id">Id da clinica que será atualizada</param>
        /// <param name="ClinicaAtt">Objeto ClinicaAtt com as informações atualizadas</param>
        public void Atualizar(int id, Clinica ClinicaAtt)
        {
            Clinica ClinicaBuscada = ctx.Clinicas.Find(id);

            if (ClinicaAtt.NomeClinica != null && ClinicaAtt.RazaoSocial != null && ClinicaAtt.Cnpj != null && ClinicaAtt.EnderecoClinica != null && ClinicaAtt.Medicos != null)
            {
                ClinicaBuscada.NomeClinica = ClinicaAtt.NomeClinica;
                ClinicaBuscada.RazaoSocial = ClinicaAtt.RazaoSocial;
                ClinicaBuscada.Cnpj = ClinicaAtt.Cnpj;
                ClinicaBuscada.EnderecoClinica = ClinicaAtt.EnderecoClinica;
                ClinicaBuscada.Medicos = ClinicaAtt.Medicos;
            }

            ctx.Clinicas.Update(ClinicaBuscada);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma Clinica pelo id 
        /// </summary>
        /// <param name="id">id da clinica que será buscada</param>
        /// <returns>Clinica Buscada</returns>
        public Clinica BuscarPorId(int id)
        {
            // Retorna a usuario buscada
            return ctx.Clinicas.FirstOrDefault(t => t.IdClinica == id);
        }

        /// <summary>
        /// Método que cadastra uma nova Clinica
        /// </summary>
        public void Cadastrar(Clinica NovaClinica)
        {
            ctx.Clinicas.Add(NovaClinica);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta o cadastro de uma clinica existente
        /// </summary>
        /// <param name="id">Id da clinica que será deletada</param>
        public void Deletar(int id)
        {
            Clinica ClinicaBuscada = ctx.Clinicas.Find(id);

            ctx.Clinicas.Remove(ClinicaBuscada);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as clinicas do SPMedical Group 
        /// </summary>
        /// <returns>Lista com as clinicas</returns>
        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
