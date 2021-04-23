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
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>StatusCode 200 e Lista de usuarios</returns>
        [HttpGet]
        public ActionResult Get()
        {
            List<UsuarioDomain> ListaDeUsuario = _usuarioRepository.ListarUsuarios();

            return Ok(ListaDeUsuario);
        }

        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="novoUsuarioDomain"></param>
        /// <returns>StatusCode Created</returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuarioDomain)
        {
            _usuarioRepository.CadastrarUsuario(novoUsuarioDomain);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta o usuario que for buscado pelo Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>StatusCode No Content</returns>
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _usuarioRepository.Deletar(Id);

            return StatusCode(204);
        }

    }
}
