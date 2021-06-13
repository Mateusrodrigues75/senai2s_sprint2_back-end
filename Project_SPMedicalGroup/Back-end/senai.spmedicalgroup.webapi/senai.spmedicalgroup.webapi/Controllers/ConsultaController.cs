using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.spmedicalgroup.webapi.Domains;
using senai.spmedicalgroup.webapi.Interfaces;
using senai.spmedicalgroup.webapi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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
        [Authorize]
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
        [Authorize(Roles ="1")]
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
        [Authorize(Roles ="1")]
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
        [Authorize(Roles = "1")]
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
        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult PatchSituacao(int id, string SituacaoAtt)
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
        [Authorize(Roles = "2")]
        [HttpPatch("/attdescricao{id}")]
        public IActionResult PatchDescricao(int id, string DescricaoAtt)
        {
            _consultaRepository.AtualizarDescricao(id, DescricaoAtt);

            return StatusCode(204);
        }

        /// <summary>
        /// Lista das consultas associadas ao id Passado no token jwt
        /// </summary>
        /// <returns>Lista das consultas</returns>
        [Authorize(Roles = "2,3")]
        [HttpGet("minhasconsultas")]
        public IActionResult MinhasConsultas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_consultaRepository.ListarMinhasConsultas(idUsuario));


            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    erro
                });
            }
        }
    }
}
