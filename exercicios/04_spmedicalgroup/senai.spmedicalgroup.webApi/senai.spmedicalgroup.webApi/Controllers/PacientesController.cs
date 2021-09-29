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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _Repository { get; set; }

        public PacientesController()
        {
            _Repository = new PacienteRepository();
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
        public IActionResult Cadastrar(Paciente obj)
        {
            _Repository.Cadastrar(obj);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um objeto
        /// </summary>
        /// <returns>Atualiza o objeto solicitado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Paciente obj)
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
