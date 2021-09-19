using senai.hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.Interfaces
{
    interface ITipoHabRepository
    {
        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHab">Objeto tipo de habilidade</param>
        void Create(TipoHab novoTipoHabilidade);

        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de objetos cadastrados</returns>
        List<TipoHab> ReadAll();

        /// <summary>
        /// Lê o objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser retornado</param>
        TipoHab ReadById(int id);

        /// <summary>
        /// Atualiza as informações do objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="novoTipoHab">Objeto com as novas informações</param>
        void Update(int id, TipoHab novoTipoHabilidade);

        /// <summary>
        /// Deleta o objeto com o id especificado
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto a ser excluído</param>
        void Delete(TipoHab novoTipoHabilidade);
    }
}
