using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-BHEJL7O\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=sa; pwd=qwerty";
        public void AtualizarIdCorpo(JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE JOGO SET nomeJogo = @novoNome, descricao = @novaDescricao, dataLancamento = @novaDataLancamento, valor = @novoValor, idEstudio = @novoEstudio WHERE idJogo = @idAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@idAtualizado", jogoAtualizado.idJogo);
                    cmd.Parameters.AddWithValue("@novoNome", jogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@novaDescricao", jogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@novaDataLancamento", jogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@novoValor", jogoAtualizado.valor);
                    cmd.Parameters.AddWithValue("@novoEstudio", jogoAtualizado.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM JOGO WHERE idJogo = @idAtualizado";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAtualizado", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            idJogo = Convert.ToInt32(rdr[0]),

                            nomeJogo = rdr[1].ToString(),

                            descricao = rdr[2].ToString(),

                            dataLancamento = Convert.ToDateTime(rdr[3]),

                            valor = Convert.ToInt32(rdr[4]),

                            idEstudio = Convert.ToInt32(rdr[5]),
                        };

                        return jogoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO JOGO (nomeJogo, descricao, dataLancamento, valor, idEstudio) VALUES (@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM JOGO WHERE idJogo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, nomeEstudio FROM JOGO INNER JOIN ESTUDIO ON JOGO.idEstudio = ESTUDIO.idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),

                            nomeJogo = rdr[1].ToString(),

                            descricao = rdr[2].ToString(),

                            dataLancamento = Convert.ToDateTime(rdr[3].ToString()),

                            valor = Convert.ToInt32(rdr[4]),

                            nomeEstudio = rdr[5].ToString(),
                        };

                        listaJogos.Add(jogo);
                    }
                }
            }

            return listaJogos;
        }
    }
}
