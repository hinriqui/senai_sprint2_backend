using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ClienteRepository
    /// </summary>
    interface IClienteRepository
    {
        /// <summary>
        /// Retorna todos os clientes
        /// </summary>
        /// <returns>Uma lista de clientes</returns>
        List<ClienteDomain> ListarTodos();

        /// <summary>
        /// Retorna o cliente com respectivo id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Um objeto da classe cliente</returns>
        ClienteDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta o cliente com respectivo id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza o cliente com respectivo id
        /// </summary>
        /// <param name="clienteAtualizado">Objeto cliente atualizado</param>
        void AtualizarIdCorpo(ClienteDomain clienteAtualizado);

        /// <summary>
        /// Cadastra o novo objeto cliente
        /// </summary>
        /// <param name="novoCliente">Novo objeto cliente</param>
        void Cadastrar(ClienteDomain novoCliente);
    }
}
