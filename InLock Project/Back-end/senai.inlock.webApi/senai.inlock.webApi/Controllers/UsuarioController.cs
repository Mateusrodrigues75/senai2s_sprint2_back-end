using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        [Authorize]
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

        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain usuarioLogin)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(usuarioLogin.Email, usuarioLogin.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioLogin.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioLogin.IdUsuario.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Usuario-Login-Autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "InLock.webApi",                //Emissor do token
                audience: "InLock.webApi",              //Destinatario do token
                claims: claims,                         //Dados que ja foram definidos
                expires: DateTime.Now.AddMinutes(30),   //Tempo até expirar
                signingCredentials: creds               //Credenciais do token
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
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
