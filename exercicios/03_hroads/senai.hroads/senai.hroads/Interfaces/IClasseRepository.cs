using senai.hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="novoClasse">Objeto classe</param>
        void Create(Classe novaClasse);

        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de objetos cadastrados</returns>
        List<Classe> ReadAll();

        /// <summary>
        /// Lê o objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser retornado</param>
        Classe ReadById(int id);

        /// <summary>
        /// Atualiza as informações do objeto com o id especificado
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="novaClasse">Objeto com as novas informações</param>
        void Update(int id, Classe novaClasse);

        /// <summary>
        /// Deleta o objeto com o id especificado
        /// </summary>
        /// <param name="novaClasse">Objeto a ser excluído</param>
        void Delete(Classe novaClasse);
    }
}
