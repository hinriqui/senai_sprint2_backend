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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult LerTudo()
        {
            return Ok(_habilidadeRepository.ReadAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_habilidadeRepository.ReadById(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade Habilidade)
        {
            _habilidadeRepository.Create(Habilidade);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(int id, Habilidade Habilidade)
        {
            _habilidadeRepository.Update(id, Habilidade);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            _habilidadeRepository.Delete(_habilidadeRepository.ReadById(id));
            return StatusCode(204);
        }
    }
}
