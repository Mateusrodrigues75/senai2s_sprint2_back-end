using senai.spmedicalgroup.webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Método que cadastra uma nova Consulta
        /// </summary>
        /// <param name="NovaConsulta">id da consulta que será cadastrada</param>
        public void Cadastrar(Consulta NovaConsulta);

        /// <summary>
        /// Lista todas as consultas do SPMedical Group 
        /// </summary>
        /// <returns>Lista com as clinicas</returns>
        List<Consulta> Listar();

        /// <summary>
        /// Busca uma Consulta pelo id 
        /// </summary>
        /// <param name="id">id da clinica que será buscada</param>
        /// <returns>Clinica Buscada</returns>
        Consulta BuscarPorId(int id);

        /// <summary>
        /// Atualiza uma consulta pelo Id
        /// </summary>
        /// <param name="id">Id da clinica que será atualizada</param>
        /// <param name="ConsultaAtt">Objeto ClinicaAtt com as informações atualizadas</param>
        void Atualizar(int id, Consulta ConsultaAtt);

        /// <summary>
        /// Deleta uma consulta existente
        /// </summary>
        /// <param name="id">Id da clinica que será deletada</param>
        void Deletar(int id);
        
        /// <summary>
        /// Atualiza a situação da Consulta
        /// </summary>
        /// <param name="id">Id da consulta que sua situação será atualizada</param>
        /// <param name="SituacaoAtt">Objeto com Situação atualizada</param>
        public void AtualizarSituacao(int id, string SituacaoAtt);

        /// <summary>
        /// Atualiza a descricao da Consulta
        /// </summary>
        /// <param name="id">Id da consulta que sua descrição será atualizada</param>
        /// <param name="DescricaoAtt">Objeto Descricao com a descrição com novas informações</param>
        public void AtualizarDescricao(int id, string DescricaoAtt);
        /// <summary>
        /// Lista das consultas associadas ao id Passado no token jwt
        /// </summary>
        /// <returns>Lista das consultas</returns>
        List<Consulta> ListarMinhasConsultas(int id);

    }
}
