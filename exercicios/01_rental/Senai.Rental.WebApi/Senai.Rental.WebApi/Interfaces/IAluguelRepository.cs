using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        /// <summary>
        /// Retorna todos os aluguéis
        /// </summary>
        /// <returns>Uma lista de aluguéis</returns>
        List<AluguelDomain> ListarTodos();

        /// <summary>
        /// Retorna o aluguel com respectivo id
        /// </summary>
        /// <param name="id">Id do aluguel</param>
        /// <returns>Um objeto da classe aluguel</returns>
        AluguelDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta o aluguel com respectivo id
        /// </summary>
        /// <param name="id">Id do aluguel</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza o aluguel com respectivo id
        /// </summary>
        /// <param name="AluguelAtualizado">Objeto aluguel atualizado</param>
        void AtualizarIdCorpo(AluguelDomain aluguelAtualizado);

        /// <summary>
        /// Cadastra o novo objeto aluguel
        /// </summary>
        /// <param name="novoAluguel">Novo objeto aluguel</param>
        void Cadastrar(AluguelDomain novoAluguel);
    }
}
