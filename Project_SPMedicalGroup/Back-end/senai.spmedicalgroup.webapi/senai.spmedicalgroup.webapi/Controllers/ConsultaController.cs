using Microsoft.AspNetCore.Mvc;
using senai.spmedicalgroup.webapi.Domains;
using senai.spmedicalgroup.webapi.Interfaces;
using senai.spmedicalgroup.webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/controller")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as consultas nas Clinicas SPMedicalGroup
        /// </summary>
        /// <returns>StatusCode Ok com lista das consultas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_consultaRepository.Listar());
        }

        /// <summary>
        /// Busca uma consulta pelo Id
        /// </summary>
        /// <param name="id">Id da consulta que será buscada</param>
        /// <returns>Status Code Ok com a consulta Buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_consultaRepository.BuscarPorId(id));
        } 

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="NovaConsulta">Objeto com os dados da nova Consulta</param>
        /// <returns>Status Code 201</returns>
        [HttpPost]
        public IActionResult Post(Consulta NovaConsulta)
        {
            _consultaRepository.Cadastrar(NovaConsulta);
            return StatusCode(201);        
        }

        /// <summary>
        /// Atualiza uma Consulta cadastrada
        /// </summary>
        /// <param name="id">Id da Consulta que será atualizada</param>
        /// <param name="ConsultaAtt">Objeto com os novos dados da consulta</param>
        /// <returns>Status Code 204</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta ConsultaAtt)
        {
            _consultaRepository.Atualizar(id, ConsultaAtt);
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta o registro de uma consulta
        /// </summary>
        /// <param name="id">Id da cinsulta que será deletada</param>
        /// <returns>Status Code 204</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _consultaRepository.Deletar(id);

            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza a Situação de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que terá a Situação Atualizada</param>
        /// <param name="SituacaoAtt">Objeto com a situação da consulta atualizada</param>
        /// <returns>Status Code 204</returns>
        [HttpPatch("{id}")]
        public IActionResult PatchSituacao(int id, Consulta SituacaoAtt)
        {
            _consultaRepository.AtualizarSituacao(id, SituacaoAtt);

            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza a Descricao de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que terá a descrição atualizada</param>
        /// <param name="DescricaoAtt"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchDescricao(int id, Consulta DescricaoAtt)
        {
            _consultaRepository.AtualizarDescricao(id, DescricaoAtt);

            return StatusCode(204);
        }
    }
}
