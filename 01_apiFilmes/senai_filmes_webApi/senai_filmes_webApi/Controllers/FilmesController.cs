﻿using Microsoft.AspNetCore.Mvc;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Filmes
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

            return Ok(listaFilmes);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _filmeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
