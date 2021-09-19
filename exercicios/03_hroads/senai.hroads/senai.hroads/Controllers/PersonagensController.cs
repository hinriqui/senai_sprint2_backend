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
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult LerTudo()
        {
            return Ok(_personagemRepository.ReadAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_personagemRepository.ReadById(id));
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem Personagem)
        {
            _personagemRepository.Create(Personagem);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(int id, Personagem Personagem)
        {
            _personagemRepository.Update(id, Personagem);
            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            _personagemRepository.Delete(_personagemRepository.ReadById(id));
            return StatusCode(204);
        }
    }
}
