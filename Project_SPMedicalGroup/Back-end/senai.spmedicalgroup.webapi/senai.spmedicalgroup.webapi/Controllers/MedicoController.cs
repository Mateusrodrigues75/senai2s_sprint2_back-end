using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista com os médico cadastrados no SPMedicalGroup
        /// </summary>
        /// <returns>StatusCode Ok com lista dos Médicos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_medicoRepository.Listar());
        }

        /// <summary>
        /// Busca um Médico Específico pelo Id passado na URL 
        /// </summary>
        /// <param name="id">Id do médico que será buscado</param>
        /// <returns>Status Code Ok com Médico Buscado</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_medicoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo Médico
        /// </summary>
        /// <param name="NovoMedico">Objeto com os dados do Novo Médico</param>
        /// <returns>Status Code 201</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Medico NovoMedico)
        {
            _medicoRepository.Cadastrar(NovoMedico);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza o cadastro de um Médico
        /// </summary>
        /// <param name="id">Id do Médico que será atualizado</param>
        /// <param name="MedicoAtt">Objeto com os novos dados do Médico</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico MedicoAtt)
        {
            _medicoRepository.Atualizar(id, MedicoAtt);
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta o registro de um Médico
        /// </summary>
        /// <param name="id">Id do médico que será deletado</param>
        /// <returns>Status Code 204</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _medicoRepository.Deletar(id);
            return StatusCode(204);
        }




    }
}
