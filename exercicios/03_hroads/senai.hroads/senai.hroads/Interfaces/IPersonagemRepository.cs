using senai.hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto personagem</param>
        void Create(Personagem novoPersonagem);

        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de objetos cadastrados</returns>
        List<Personagem> ReadAll();

        /// <summary>
        /// Lê o objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser retornado</param>
        Personagem ReadById(int id);

        /// <summary>
        /// Atualiza as informações do objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="novoPersonagem">Objeto com as novas informações</param>
        void Update(int id, Personagem novoPersonagem);

        /// <summary>
        /// Deleta o objeto com o id especificado
        /// </summary>
        /// <param name="novoPersonagem">Objeto a ser excluído</param>
        void Delete(Personagem novoPersonagem);
    }
}
