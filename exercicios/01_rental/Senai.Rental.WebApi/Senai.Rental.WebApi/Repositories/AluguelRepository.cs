using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        /// <summary>
        /// String de conexão que recebe os parâmetros do banco de dados
        /// </summary>
        private string stringConexao = @"Data Source=DESKTOP-BHEJL7O\SQLEXPRESS; initial catalog=M_Rental; user Id=sa; pwd=qwerty";

        public void AtualizarIdCorpo(AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.idAluguel != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Aluguel SET idCliente = @novoIdCliente, dataRetirada = @novoDataRet, dataDevolucao = @novoDataDev WHERE idAluguel = @idAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novoIdCliente", aluguelAtualizado.idCliente);
                        cmd.Parameters.AddWithValue("@novoDataRet", aluguelAtualizado.dataInicio);
                        cmd.Parameters.AddWithValue("@novoDataDev", aluguelAtualizado.dataFim);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public AluguelDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Aluguel WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),

                            idCliente = Convert.ToInt32(rdr[1]),

                            dataInicio = Convert.ToDateTime(rdr[2]),

                            dataFim = Convert.ToDateTime(rdr[3]),
                        };

                        return aluguelBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Aluguel (idCliente, dataRetirada, dataDevolucao) VALUES (@idCliente, @dataRetirada, @dataDevolucao)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@dataRetirada", novoAluguel.dataInicio);
                    cmd.Parameters.AddWithValue("@dataDevolucao", novoAluguel.dataFim);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM GENERO WHERE idAluguel = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            //Declara a SqlConnection con passando a string de conexão como parâmetro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução a ser executada.
                string querySelectAll = "SELECT * FROM Aluguel";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declara o SqlDataReader rar para percorrer a tabela do banco de dados.
                SqlDataReader rdr;

                //Declara o SQLCommand cmd passando a query que sera executada e a conexão com parâmetros.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armaneza os dados no rdr.
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr, o laço se repete.
                    while (rdr.Read())
                    {
                        //Instancia um objeto aluguel do tipo AluguelDomain
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),

                            idCliente = Convert.ToInt32(rdr[1]),

                            dataInicio = Convert.ToDateTime(rdr[2]),

                            dataFim = Convert.ToDateTime(rdr[3]),
                        };

                        //Adicionar o objeto aluguel criado a lista listaAlugueis.
                        listaAlugueis.Add(aluguel);
                    }
                }
            }

            return listaAlugueis;
        }
    }
}
