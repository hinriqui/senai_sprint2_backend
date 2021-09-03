using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        /// <summary>
        /// String de conexão que recebe os parâmetros do banco de dados
        /// </summary>
        private string stringConexao = @"Data Source=DESKTOP-BHEJL7O\SQLEXPRESS; initial catalog=M_Rental; user Id=sa; pwd=qwerty";

        public void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.placaVeiculo != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Veiculo SET idEmpresa = @novaEmpresa, idModelo = @novoModelo, idAluguel = @novoAluguel, placaVeiculo = @novaPlaca WHERE idVeiculo = @idAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novaEmpresa", veiculoAtualizado.idEmpresa);
                        cmd.Parameters.AddWithValue("@novoModelo", veiculoAtualizado.idEmpresa);
                        cmd.Parameters.AddWithValue("@novoAluguel", veiculoAtualizado.idAluguel);
                        cmd.Parameters.AddWithValue("@placaVeiculo", veiculoAtualizado.placaVeiculo);


                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public VeiculoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Veiculo WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),

                            idEmpresa = Convert.ToInt32(rdr[1]),

                            idModelo = Convert.ToInt32(rdr[2]),

                            idAluguel = Convert.ToInt32(rdr[3]),

                            placaVeiculo = rdr[4].ToString()
                        };

                        return veiculoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Veiculo (idEmpresa, idModelo, idAluguel, placaVeiculo) VALUES (@idEmpresa, @idModelo, @idAluguel, @placaVeiculo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@idAluguel", novoVeiculo.idAluguel);
                    cmd.Parameters.AddWithValue("@placaVeiculo", novoVeiculo.placaVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Veiculo WHERE idVeiculo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            //Declara a SqlConnection con passando a string de conexão como parâmetro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução a ser executada.
                string querySelectAll = "SELECT * FROM Veiculo";

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
                        //Instancia um objeto veículo do tipo VeiculoDomain
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),

                            idEmpresa = Convert.ToInt32(rdr[1]),

                            idModelo = Convert.ToInt32(rdr[2]),

                            idAluguel = Convert.ToInt32(rdr[3]),

                            placaVeiculo = rdr[4].ToString()
                        };

                        //Adicionar o objeto cliente criado a lista listaVeiculos.
                        listaVeiculos.Add(veiculo);
                    }
                }
            }

            return listaVeiculos;
        }
    }
}
