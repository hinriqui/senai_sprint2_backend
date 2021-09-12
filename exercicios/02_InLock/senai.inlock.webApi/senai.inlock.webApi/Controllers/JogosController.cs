using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class JogosController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }

        public JogosController()
        {
            _JogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Retorna todos os jogos
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _JogoRepository.ListarTodos();
            return Ok(listaJogos);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain jogoBuscado = _JogoRepository.BuscarPorId(id);
            if (jogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado!");
            }
            return Ok(jogoBuscado);
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            _JogoRepository.Cadastrar(novoJogo);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult PutBody(JogoDomain jogoAtualizado)
        {
            if (jogoAtualizado.nomeJogo == null || jogoAtualizado.idJogo == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Nome ou id do jogo não foi informado!"
                    }
                );
            }

            JogoDomain jogoBuscado = _JogoRepository.BuscarPorId(jogoAtualizado.idJogo);
            
            if (jogoBuscado != null)
            {
                try
                {
                    _JogoRepository.AtualizarIdCorpo(jogoAtualizado);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

            return NotFound(
                    new
                    {
                        mensagemErro = "Cliente não encontrado!",
                        codErro = true
                    }
                );
        }

        [Authorize(Roles = "1")]
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _JogoRepository.Deletar(id);
            return StatusCode(204);
        }

    }
}
