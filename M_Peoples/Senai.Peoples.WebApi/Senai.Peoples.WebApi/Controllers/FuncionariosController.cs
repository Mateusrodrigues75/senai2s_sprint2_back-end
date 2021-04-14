using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    // ex: http://localhost:5000/api/Funcionarios
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class FuncionariosController : ControllerBase
    {

        private IFuncionariosRepository _funcionariosRepository { get; set; }

        public FuncionariosController()
        {
            _funcionariosRepository = new FuncionariosRepositoty();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FuncionariosDomain> listaFuncionarios = _funcionariosRepository.ListarTodos();

            return Ok(listaFuncionarios);
        }

        [HttpPost]
        public IActionResult Post(FuncionariosDomain novoFuncionario)
        {
            _funcionariosRepository.Cadastrar(novoFuncionario);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

            if (funcionarioBuscado == null)
            {
                return NotFound("Nenhum registro foi encontrado!");
            }

            return Ok(funcionarioBuscado);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionariosDomain funcionarioAtualizado)
        {
            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

            if (funcionarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Registro não encontrado!",
                        erro = true
                    }
                    );
            }

            try
            {
                _funcionariosRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionário buscado no banco de dados
            FuncionariosDomain funcionarioBuscado = _funcionariosRepository.BuscarPorId(id);

            // Verifica se o funcionário foi encontrado
            if (funcionarioBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                _funcionariosRepository.Deletar(id);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O funcionário {id} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum funcionário encontrado para o identificador informado");
        }

        /// <summary>
        /// Lista todos os funcionários através de uma palavra-chave
        /// </summary>
        /// <param name="busca">Palavra-chave que será utilizada na busca</param>
        /// <returns>Retorna uma lista de funcionários encontrados</returns>
        /// dominio/api/Funcionarios/pesquisar/palavra-chave
        [HttpGet("buscar/{busca}")]
        public IActionResult GetByName(string busca)
        {
            // Faz a chamada para o método .BuscarPorNome()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_funcionariosRepository.BuscarPorNome(busca));
        }

        /// <summary>
        /// Lista todos os funcionários com os nomes completos
        /// </summary>
        /// <returns>Retorna uma lista de funcionários</returns>
        /// dominio/api/Funcionarios/nomescompletos
        [HttpGet("nomescompletos")]
        public IActionResult GetFullName()
        {
            // Faz a chamada para o método .ListarNomeCompleto            
            // Retorna a lista e um status code 200 - Ok
            return Ok(_funcionariosRepository.ListarNomeCompleto());
        }

        /// <summary>
        /// Lista todos os funcionários de maneira ordenada pelo nome
        /// </summary>
        /// <param name="ordem">String que define a ordenação (crescente ou descrescente)</param>
        /// <returns>Retorna uma lista ordenada de funcionários</returns>
        /// dominio/api/Funcionarios/ordenacao/asc
        [HttpGet("ordenacao/{ordem}")]
        public IActionResult GetOrderBy(string ordem)
        {
            // Verifica se a ordenação atende aos requisitos
            if (ordem != "ASC" && ordem != "DESC")
            {
                // Caso não, retorna um status code 404 - BadRequest com uma mensagem de erro
                return BadRequest("Não é possível ordenar da maneira solicitada. Por favor, ordene por 'ASC' ou 'DESC'");
            }

            // Retorna a lista ordenada com um status code 200 - OK
            return Ok(_funcionariosRepository.ListarOrdenado(ordem));
        }
    }
}

    
