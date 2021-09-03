using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculoRepository
    {
        /// <summary>
        /// Retorna todos os veículos
        /// </summary>
        /// <returns>Uma lista de veículos</returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// Retorna o veículo com respectivo id
        /// </summary>
        /// <param name="id">Id do veículo</param>
        /// <returns>Um objeto da classe veículo</returns>
        VeiculoDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta o veículo com respectivo id
        /// </summary>
        /// <param name="id">Id do veículo</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza o veículo com respectivo id
        /// </summary>
        /// <param name="veiculoAtualizado">Objeto veículo atualizado</param>
        void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado);

        /// <summary>
        /// Cadastra o novo objeto veículo
        /// </summary>
        /// <param name="novoVeiculo">Novo objeto veículo</param>
        void Cadastrar(VeiculoDomain novoVeiculo);
    }
}
