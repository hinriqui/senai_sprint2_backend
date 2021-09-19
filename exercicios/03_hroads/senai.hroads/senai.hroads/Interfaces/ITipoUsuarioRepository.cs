using senai.hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto tipo de usuário</param>
        void Create(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de objetos cadastrados</returns>
        List<TipoUsuario> ReadAll();

        /// <summary>
        /// Lê o objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser retornado</param>
        TipoUsuario ReadById(int id);

        /// <summary>
        /// Atualiza as informações do objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="novoTipoUsuario">Objeto com as novas informações</param>
        void Update(int id, TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Deleta o objeto com o id especificado
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto a ser excluído</param>
        void Delete(TipoUsuario novoTipoUsuario);
    }
}
