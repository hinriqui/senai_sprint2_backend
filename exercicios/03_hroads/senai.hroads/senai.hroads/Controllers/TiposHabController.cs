using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.Domains;
using senai.hroads.Interfaces;
using senai.hroads.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposHabController : ControllerBase
    {
        private ITipoHabRepository _tipoHabRepository { get; set; }

        public TiposHabController()
        {
            _tipoHabRepository = new TipoHabRepository();
        }

        /// <summary>
        /// Lê tudo
        /// </summary>
        /// <returns>Lista de todos os objetos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult LerTudo()
        {
            return Ok(_tipoHabRepository.ReadAll());
        }

        /// <summary>
        /// Busca objeto atráves do ID
        /// </summary>
        /// <returns>Lista apenas o objeto selecionado</returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_tipoHabRepository.ReadById(id));
        }

        /// <summary>
        /// Cadastra um objeto
        /// </summary>
        /// <returns>Cadastra o objeto solicitado</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoHab TipoHab)
        {
            _tipoHabRepository.Create(TipoHab);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um objeto
        /// </summary>
        /// <returns>Atualiza o objeto solicitado</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoHab TipoHab)
        {
            _tipoHabRepository.Update(id, TipoHab);
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um objeto
        /// </summary>
        /// <returns>Deleta o objeto solicitado</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _tipoHabRepository.Delete(_tipoHabRepository.ReadById(id));
            return StatusCode(204);
        }
    }
}
