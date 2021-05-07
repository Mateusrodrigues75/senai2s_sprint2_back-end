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
    [Produces("applicarion/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Lista todas as especialidades do SPMedicalGroup
        /// </summary>
        /// <returns>Status Code Ok com a lista das especialidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_especialidadeRepository.Listar());
        }

        /// <summary>
        /// Busca uma especialidade específica pelo Id passado na URL
        /// </summary>
        /// <param name="id">Id da especialidade que será Buscada</param>
        /// <returns>Status Code Ok com a especialidade buscada</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_especialidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova Especialidade 
        /// </summary>
        /// <param name="NovaEspecialidade">Objeto com os dados da especialidade</param>
        /// <returns>Status Code 201</returns>
        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(Especialidade NovaEspecialidade)
        {
            _especialidadeRepository.Cadastrar(NovaEspecialidade);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma Especialidade cadastrada
        /// </summary>
        /// <param name="id">Id da especialidade que será atualizada</param>
        /// <param name="EspecialidadeAtt">Objeto com os novos dados da Especialidade</param>
        /// <returns>Status Code 204</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Especialidade EspecialidadeAtt)
        {
            _especialidadeRepository.Atualizar(id, EspecialidadeAtt);

            return StatusCode(204);
        }

        /// <summary>
        /// Deleta o registro de uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade que será deletda</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _especialidadeRepository.Deletar(id);
            return StatusCode(204);
        }
    }
}
