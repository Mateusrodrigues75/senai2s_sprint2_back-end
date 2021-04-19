using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints (URLs) referentes aos gêneros
/// </summary>
namespace senai_filmes_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Generos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros e um status code</returns>
        /// dominio/api/generos
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaGeneros para receber os dados
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
            return Ok(listaGeneros);
        }

        /// <summary>
        /// Busca um gênero através do id   
        /// </summary>
        /// <param name="id">id do gênero que será buscado</param>
        /// <returns>Um gênero buscado ou notFound caso nenhum gênero seja encontrado</returns>
        /// http://localhost:5000/api/generos/1
        [Authorize(Roles ="administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound("Nenhum gênero foi encontrado!");
            }
            return Ok(generoBuscado);
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        /// http://localhost:5000/api/generos
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // Faz a chamada para o método .Cadastrar()
            _generoRepository.Cadastrar(novoGenero);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um gênero existente passando o id no pela URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="generoAtualizado"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, GeneroDomain generoAtualizado)
        {
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            if (generoBuscado == null)
            {
                return NotFound
                    (new
                        {
                            mensagem = "Gênero não encontrado!",
                            erro = true
                        }
                    );
            }
            try
            {
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                return NoContent();
            }
            //Caso ocorra algum erro
            catch (Exception erro)
            {
                
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/generos/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _generoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }
}
