using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
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
        /// Lista todos os tipos de usuarios
        /// </summary>
        /// <returns>StatusCode 200 e Lista de tipos de usuarios</returns>
        [HttpGet]
        public IActionResult ListarTipoUsuario()
        {
            List<TipoUsuarioDomain> ListaTipoDeUsuario = _tipoUsuarioRepository.ListarTipoUsuario();

            return Ok(ListaTipoDeUsuario);
        }

        /// <summary>
        /// Cadastra um tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuarioDomain"></param>
        /// <returns>StatusCode Created</returns>
        [HttpPost]
        public IActionResult CadastrarTipoUsuario(TipoUsuarioDomain novoTipoUsuarioDomain)
        {
            _tipoUsuarioRepository.CadastrarTipoUsuario(novoTipoUsuarioDomain);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta o TipoUsuario que for buscado pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>StatusCode No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult DeletarTipoUsuario(int Id)
        {
            _tipoUsuarioRepository.Deletar(Id);

            return StatusCode(204);
        }
    }
}
