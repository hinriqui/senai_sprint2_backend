using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Retorna todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Retorna o jogo com respectivo id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <returns>Um objeto da classe jogo</returns>
        JogoDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta o jogo com respectivo id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza o jogo com respectivo id
        /// </summary>
        /// <param name="jogoAtualizado">Objeto jogo atualizado</param>
        void AtualizarIdCorpo(JogoDomain jogoAtualizado);

        /// <summary>
        /// Cadastra o novo objeto jogo
        /// </summary>
        /// <param name="novoJogo">Novo objeto jogo</param>
        void Cadastrar(JogoDomain novoJogo);
    }
}
