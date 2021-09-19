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
    public class ClassesHabilidadesController : ControllerBase
    {
        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }

        public ClassesHabilidadesController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult LerTudo()
        {
            return Ok(_classeHabilidadeRepository.ReadAll());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(ClasseHabilidade ClasseHabilidade)
        {
            _classeHabilidadeRepository.Create(ClasseHabilidade);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete]
        public IActionResult Deletar(ClasseHabilidade ClasseHabilidade)
        {
            _classeHabilidadeRepository.Delete(ClasseHabilidade);
            return StatusCode(204);
        }
    }
}
