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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }
        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Status Code OK com Lista dos Tipos de Usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        /// <summary>
        /// Cadastra novo Tipo de Usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com informações do novo Tipo de Usuário</param>
        /// <returns>Status Code 201</returns>
                [Authorize(Roles ="1")]

        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Busca um Tipo de Usuário pelo Id passado na URL
        /// </summary>
        /// <param name="id">Id do Tipo Usuário que será buscada</param>
        /// <returns>Tipo Usuario Buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Deleta um Tipo de Usuário existente
        /// </summary>
        /// <param name="id">Id do Tipo de Usuário que será deleteado</param>
        /// <returns>Status Code 201</returns>
        [Authorize(Roles ="1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoUsuarioRepository.Deletar(id);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um Tipo de Usuário existente
        /// </summary>
        /// <param name="id">Id do Tipo de Usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado com novos dados </param>
        /// <returns>Status Code 204</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            // Faz a chamada para o método
            _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }
    }
}
