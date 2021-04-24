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
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os Jogos cadastrados
        /// </summary>
        /// <returns>Status Code Ok</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogoRepository.ListarJogos());
        }

        /// <summary>
        /// Cadastra um novo Jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        /// <returns>Status code Created</returns>
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            //

            // Faz a chamada para o método .Cadastrar();
            _jogoRepository.CadastrarJogo(novoJogo);

            // Retorna o status code 201 - Created com a URI e o objeto cadastrado
            return Created("http://localhost:5000/api/Jogo", novoJogo);
        }

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">id do jogo que será deletado</param>
        /// <returns>Um status code Ok - No Content</returns>
        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _jogoRepository.Deletar(id);

            return Ok($"O Jogo {id} foi deletado com sucesso!");
        }
    }
}
