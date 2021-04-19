using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Controllers
{
    //Define que o tipo de resposta sa API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Usuarios
    [Route("api/[controller]")]

    [ApiController]
    public class UsuarioController : ControllerBase
    {

        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Intancia o objeto para que haja referencia aos metodos do repositorio
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository =  new UsuarioRepository();
        }

        /// <summary>
        /// Faz a manutenção do usuario
        /// </summary>
        /// <param name="login">objeto com os dados de email e senha</param>
        /// <returns>Um status code e, em caso de sucesso, os dados do usuario buscado</returns>
        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.permissao),
                new Claim("Claim Personalizada", "Valor Teste")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                    issuer: "Filmes.webApi",                    // emissor do token
                    audience: "Filmes.webApi",                  // destinatário do token
                    claims: claims,                             // dados definidos acima (linha 59)
                    expires: DateTime.Now.AddMinutes(30),       // tempo de expiração
                    signingCredentials: creds                   // credenciais do token
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }
        
    }
}
