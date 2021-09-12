using Microsoft.AspNetCore.Http;
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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Loga o usuário e retorna o código de autenticação
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado != null)
            {
                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("shaolinmatadordeporco"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "InLock.webAPI",               // emissor do token
                        audience: "InLock.webAPI",             // destinatário do token
                        claims: minhasClaims,                  // dados definidos acima (linha 38)
                        expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                        signingCredentials: creds              // credenciais do token
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }

            return NotFound("Email ou senha inválidos");
        }
    }
}
