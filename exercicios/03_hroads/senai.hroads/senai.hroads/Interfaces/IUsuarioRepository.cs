using senai.hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto usuário</param>
        void Create(Usuario novoUsuario);

        /// <summary>
        /// Busca por um usuário com respectivos email e senha
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>O objeto usuário</returns>
        Usuario SearchAccount(string email, string senha);


        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de objetos cadastrados</returns>
        List<Usuario> ReadAll();

        /// <summary>
        /// Lê o objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser retornado</param>
        Usuario ReadById(int id);

        /// <summary>
        /// Atualiza as informações do objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="novoUsuario">Objeto com as novas informações</param>
        void Update(int id, Usuario novoUsuario);

        /// <summary>
        /// Deleta o objeto com o id especificado
        /// </summary>
        /// <param name="novoUsuario">Objeto a ser excluído</param>
        void Delete(int id);
    }
}
