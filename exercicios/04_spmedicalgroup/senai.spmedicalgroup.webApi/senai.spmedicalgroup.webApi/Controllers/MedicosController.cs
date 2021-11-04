﻿using Microsoft.AspNetCore.Authorization;
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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _Repository { get; set; }

        public MedicosController()
        {
            _Repository = new MedicoRepository();
        }

        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de todos os objetos</returns>
        [Authorize(Roles = "ADM")]
        [HttpGet]
        public IActionResult LerTudo()
        {
            return Ok(_Repository.ListarTodos());
        }

    }
}
