using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmedicalgroup.webApi.Domains;
using senai.spmedicalgroup.webApi.Interfaces;
using senai.spmedicalgroup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultumRepository _Repository { get; set; }

        public ConsultasController()
        {
            _Repository = new ConsultumRepository();
        }

        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de todos os objetos</returns>
        [HttpGet]
        public IActionResult LerTudo()
        {
            return Ok(_Repository.ListarTodos());
        }

        /// <summary>
        /// Lê todas as consultas cadastrados para esse médico
        /// </summary>
        /// <returns>Lista de todos os objetos</returns>
        [HttpGet("med/{email}")]
        public IActionResult LerMed(string email)
        {
            Repositories.MedicoRepository m = new Repositories.MedicoRepository();
            return Ok(_Repository.ListarPorMed(m.BuscarPorEmail(email).IdMedico));
        }

        /// <summary>
        /// Lê todas as consultas cadastrados para esse médico
        /// </summary>
        /// <returns>Lista de todos os objetos</returns>
        [HttpGet("pac/{email}")]
        public IActionResult LerPac(string email)
        {
            Repositories.PacienteRepository p = new Repositories.PacienteRepository();
            return Ok(_Repository.ListarPorPac(p.BuscarPorEmail(email).IdPaciente));
        }

        /// <summary>
        /// Busca objeto atráves do ID
        /// </summary>
        /// <returns>Lista apenas o objeto selecionado</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_Repository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um objeto
        /// </summary>
        /// <returns>Cadastra o objeto solicitado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Consultum obj)
        {
            _Repository.Cadastrar(obj);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um objeto
        /// </summary>
        /// <returns>Atualiza o objeto solicitado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Consultum obj)
        {
            _Repository.Atualizar(id, obj);
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um objeto
        /// </summary>
        /// <returns>Deleta o objeto solicitado</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _Repository.Deletar(id);
            return StatusCode(204);
        }
    }
}
