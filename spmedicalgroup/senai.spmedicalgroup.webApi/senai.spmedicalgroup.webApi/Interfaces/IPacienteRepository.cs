using senai.spmedicalgroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Retorna todos os objetos cadastrados
        /// </summary>
        /// <returns>Uma lista de objetos</returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Retorna o objeto com respectivo email
        /// </summary>
        /// <param name="email">Email do objeto</param>
        /// <returns>O objeto com respectivo email</returns>
        Paciente BuscarPorEmail(string email);

        /// <summary>
        /// Retorna o objeto com respectivo id
        /// </summary>
        /// <param name="id">Id do objeto</param>
        /// <returns>O objeto com respectivo id</returns>
        Paciente BuscarPorId(int id);

        /// <summary>
        /// Deleta o objeto com respectivo id
        /// </summary>
        /// <param name="id">Id do objeto</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza o objeto com respectivo id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="objAtualizado">Objeto atualizado</param>
        void Atualizar(int id, Paciente objAtualizado);

        /// <summary>
        /// Cadastra um novo objeto
        /// </summary>
        /// <param name="objAtualizado">Novo objeto</param>
        void Cadastrar(Paciente objAtualizado);
    }
}
