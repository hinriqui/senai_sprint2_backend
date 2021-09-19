using senai.hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        /// <summary>
        /// Cadastra uma nova relação classe-habilidade
        /// </summary>
        /// <param name="novaClasseHabilidade">Objeto classe-habilidade</param>
        void Create(ClasseHabilidade novaClasseHabilidade);

        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de objetos cadastrados</returns>
        List<ClasseHabilidade> ReadAll();

        /// <summary>
        /// Deleta o objeto com o id especificado
        /// </summary>
        /// <param name="novaClasseHabilidade">Objeto a ser excluído</param>
        void Delete(ClasseHabilidade novaClasseHabilidade);
    }
}
