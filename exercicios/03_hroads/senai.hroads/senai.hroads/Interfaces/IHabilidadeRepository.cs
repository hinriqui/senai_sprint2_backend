using senai.hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.Interfaces
{
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novoHabilidade">Objeto habilidade</param>
        void Create(Habilidade novaHabilidade);

        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de objetos cadastrados</returns>
        List<Habilidade> ReadAll();

        /// <summary>
        /// Lê o objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser retornado</param>
        Habilidade ReadById(int id);

        /// <summary>
        /// Atualiza as informações do objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="novoHabilidade">Objeto com as novas informações</param>
        void Update(int id, Habilidade novaHabilidade);

        /// <summary>
        /// Deleta o objeto com o id especificado
        /// </summary>
        /// <param name="novaHabilidade">Objeto a ser excluído</param>
        void Delete(Habilidade novaHabilidade);
    }
}
