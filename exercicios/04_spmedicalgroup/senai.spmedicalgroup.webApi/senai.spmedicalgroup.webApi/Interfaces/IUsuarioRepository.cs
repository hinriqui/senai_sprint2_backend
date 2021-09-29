using senai.spmedicalgroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Retorna todos os objetos cadastrados
        /// </summary>
        /// <returns>Uma lista de objetos</returns>
        List<UsuarioRepository> ListarTodos();

        /// <summary>
        /// Retorna o objeto com respectivo email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>O objeto com respectivo email</returns>
        UsuarioRepository Buscar(string email);

        /// <summary>
        /// Deleta o objeto com respectivo email
        /// </summary>
        /// <param name="id">Id do objeto</param>
        void Deletar(string email);

        /// <summary>
        /// Atualiza o objeto a partir do email
        /// </summary>
        /// <param name="objAtualizado">Objeto atualizado</param>
        void Atualizar(UsuarioRepository objAtualizado);

        /// <summary>
        /// Cadastra um novo objeto
        /// </summary>
        /// <param name="objAtualizado">Novo objeto</param>
        void Cadastrar(UsuarioRepository objAtualizado);
    }
}
