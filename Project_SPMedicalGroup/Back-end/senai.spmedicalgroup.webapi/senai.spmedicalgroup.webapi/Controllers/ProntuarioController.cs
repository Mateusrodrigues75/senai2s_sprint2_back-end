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
    public class ProntuarioController : ControllerBase
    {
        private IProntuarioRepository _prontuariorepository { get; set; }

        public ProntuarioController()
        {
            _prontuariorepository = new ProntuarioRepository();
        }

        /// <summary>
        /// Lista todos os Prontuarios cadastrados
        /// </summary>
        /// <returns>Status Code Ok com lista de Prontuarios</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_prontuariorepository.Listar());
        }

        /// <summary>
        /// Busca um Prontuario específico pelo Id passado na URL
        /// </summary>
        /// <param name="id">Id do Prontuario que será buscado</param>
        /// <returns>status Code Ok com Protuario buscado</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            return Ok(_prontuariorepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo Prontuario
        /// </summary>
        /// <param name="NovoProntuario">Objeto com os dados do paciente</param>
        /// <returns>Status Code 201</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Prontuario NovoProntuario)
        {
            _prontuariorepository.Cadastrar(NovoProntuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza o cadastro de um paciente
        /// </summary>
        /// <param name="id">id do Prontuario que será atualizado</param>
        /// <param name="ProntuarioAtt">Objeto com os novos dados do paciente</param>
        /// <returns>Status Code 204</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Prontuario ProntuarioAtt)
        {
            _prontuariorepository.Atualizar(id, ProntuarioAtt);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta o prontuario de um paciente 
        /// </summary>
        /// <param name="id">Id do prontuario que será deletado</param>
        /// <returns>Status Code 204</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _prontuariorepository.Deletar(id);

            return StatusCode(204);
        }

    }
}
