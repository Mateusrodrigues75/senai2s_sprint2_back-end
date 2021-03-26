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
            _funcionariosRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}

    
