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

        [Authorize]
        [HttpGet]
        public IActionResult LerTudo()
        {
            return Ok(_tipoHabRepository.ReadAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_tipoHabRepository.ReadById(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoHab TipoHab)
        {
            _tipoHabRepository.Create(TipoHab);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(int id, TipoHab TipoHab)
        {
            _tipoHabRepository.Update(id, TipoHab);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            _tipoHabRepository.Delete(_tipoHabRepository.ReadById(id));
            return StatusCode(204);
        }
    }
}
