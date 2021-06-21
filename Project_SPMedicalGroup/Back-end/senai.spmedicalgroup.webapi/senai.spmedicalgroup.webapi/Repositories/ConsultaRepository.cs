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
    public class ConsultaRepository : IConsultaRepository
    {
        /// <summary>
        /// Objeto Contexto por onde serão chamados os Métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza uma consulta pelo Id
        /// </summary>
        /// <param name="id">Id da clinica que será atualizada</param>
        /// <param name="ConsultaAtt">Objeto ClinicaAtt com as informações atualizadas</param>
        public void Atualizar(int id, Consulta ConsultaAtt)
        {
            Consulta ConsultaBuscada = ctx.Consultas.Find(id);

            if (ConsultaAtt.IdProntuario != null && ConsultaAtt.IdMedico != null && ConsultaAtt.DataConsulta != DateTime.Now && ConsultaAtt.Situacao != null)
            {
                ConsultaBuscada.IdProntuario = ConsultaAtt.IdProntuario;
                ConsultaBuscada.IdMedico = ConsultaAtt.IdMedico;
                ConsultaBuscada.DataConsulta = ConsultaAtt.DataConsulta;
                ConsultaBuscada.Situacao = ConsultaAtt.Situacao;
            }

            ctx.Consultas.Update(ConsultaBuscada);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma Consulta pelo id 
        /// </summary>
        /// <param name="id">id da clinica que será buscada</param>
        /// <returns>Clinica Buscada</returns>
        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas.FirstOrDefault(c => c.IdConsulta == id);
        }

        /// <summary>
        /// Método que cadastra uma nova Consulta
        /// </summary>
        public void Cadastrar(Consulta NovaConsulta)
        {
            ctx.Consultas.Add(NovaConsulta);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma consulta existente
        /// </summary>
        /// <param name="id">Id da clinica que será deletada</param>
        public void Deletar(int id)
        {
            Consulta ConsultaBuscada = ctx.Consultas.Find(id);

            ctx.Consultas.Remove(ConsultaBuscada);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as consultas do SPMedical Group 
        /// </summary>
        /// <returns>Lista com as clinicas</returns>
        public List<Consulta> Listar()
        {
            return ctx.Consultas
                 .Include(c => c.IdProntuarioNavigation)
                 .Include(c => c.IdMedicoNavigation)
                 .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)
                 .ToList();
        }

        /// <summary>
        /// Atualiza a situação da Consulta
        /// </summary>
        /// <param name="id">Id da consulta que sua situação será atualizada</param>
        /// <param name="SituacaoAtt">Objeto com Situação atualizada</param>
        public void AtualizarSituacao(int id, string SituacaoAtt)
        {
            Consulta ConsultaBuscada = ctx.Consultas.Find(id);

            ConsultaBuscada.Situacao = SituacaoAtt;

            ctx.Consultas.Update(ConsultaBuscada);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza a descricao da Consulta
        /// </summary>
        /// <param name="id">Id da consulta que sua descrição será atualizada</param>
        /// <param name="DescricaoAtt">Objeto Descricao com a descrição com novas informações</param>
        public void AtualizarDescricao(int id, string DescricaoAtt)
        {
            Consulta ConsultaBuscada = ctx.Consultas.Find(id);

            ConsultaBuscada.Descricao = DescricaoAtt;

            ctx.Consultas.Update(ConsultaBuscada);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista as consultas associadas ao id passado no token jwt
        /// </summary>
        /// <returns>Lista com as consultas</returns>
        public List<Consulta> ListarMinhasConsultas(int id)
        {
            return ctx.Consultas
                 .Include(c => c.IdProntuarioNavigation)
                 .Include(c => c.IdMedicoNavigation)
                 .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)

                 .Where(c => c.IdProntuarioNavigation.IdUsuario == id || c.IdMedicoNavigation.IdUsuario == id)
                 .ToList();
        }
    }
}
