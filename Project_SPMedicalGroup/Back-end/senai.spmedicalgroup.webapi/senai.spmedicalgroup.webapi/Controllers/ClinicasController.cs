using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using senai.spmedicalgroup.webapi.Domains;
using senai.spmedicalgroup.webapi.Interfaces;
using senai.spmedicalgroup.webapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace senai.spmedicalgroup.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Lista todas as clinicas do SPMedicalGroup
        /// </summary>
        /// <returns>Status Code Ok com lista das clinicas cadastradas</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clinicaRepository.Listar());
        }

        /// <summary>
        /// Busca uma clinica específica pelo id passado pela URL
        /// </summary>
        /// <param name="id">Id da clinica que será buscada</param>
        /// <returns>Status Code Ok com clinica Buscada</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_clinicaRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova Clinica
        /// </summary>
        /// <param name="NovaClinica">Objeto NovaClinica com os dados da clinica que será cadastrada</param>
        /// <returns>Status Code 201</returns>
        [Authorize(Roles="1")]
        [HttpPost]
        public IActionResult Post(Clinica NovaClinica)
        {
            _clinicaRepository.Cadastrar(NovaClinica);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma Clinica ja cadastrada
        /// </summary>
        /// <param name="id">Id da clinica que será atualizada</param>
        /// <param name="NovaClinica">Objeto NovaClinica que contém os novos dados da clinica </param>
        /// <returns>Status Code 204</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica NovaClinica)
        {
            // Faz a chamada para o método
            _clinicaRepository.Atualizar(id,NovaClinica );

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta o registro de uma Clinica
        /// </summary>
        /// <param name="id">Id da clinica que será deletada</param>
        /// <returns>Status Code 204</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clinicaRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
