using Microsoft.AspNetCore.Authorization;
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
    public class EstudioController : ControllerBase
    {

        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os Estudios
        /// </summary>
        /// <returns>Status Code Ok</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            // Faz a chamada para o método .ListarEstudios()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_estudioRepository.ListarEstudios());
        }

        /// <summary>
        /// Cadastra um estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        /// <returns>Status code Created</returns>
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            if (novoEstudio.NomeEstudio == null)
            {
                return BadRequest("O nome do novo Estúdio é obrigatório!");
            }
            // Faz a chamada para o método .Cadastrar();
            _estudioRepository.CadastrarEstudio(novoEstudio);

            // Retorna o status code 201 - Created com a URI e o objeto cadastrado
            return Created("http://localhost:5000/api/Estudio", novoEstudio);
        }

        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="id">id do estúdio que será deletado</param>
        /// <returns>Um status code Ok</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionário buscado no banco de dados
            _estudioRepository.DeletarEstudio(id);

            // e retorna um status code 200 - Ok com uma mensagem de sucesso
            return Ok($"O Estúdio {id} foi deletado com sucesso!");
        }
    }
}
