using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        /// <summary>
        /// String de conexão que recebe os parâmetros do banco de dados
        /// </summary>
        private string stringConexao = @"Data Source=DESKTOP-BHEJL7O\SQLEXPRESS; initial catalog=M_Rental; user Id=sa; pwd=qwerty";

        public void AtualizarIdCorpo(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.nomeCliente != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Cliente SET nomeCliente = @novoNome, Sobrenome = @novoSobrenome, cpfCliente = @novoCpf WHERE idCliente = @idAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novoNome", clienteAtualizado.nomeCliente);
                        cmd.Parameters.AddWithValue("@novoSobrenome", clienteAtualizado.Sobrenome);
                        cmd.Parameters.AddWithValue("@novoCpf", clienteAtualizado.cpfCliente);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public ClienteDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Cliente WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(rdr[0]),

                            nomeCliente = rdr[1].ToString(),

                            Sobrenome = rdr[2].ToString(),

                            cpfCliente = rdr[3].ToString(),
                        };

                        return clienteBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Cliente (nomeCliente, Sobrenome, cpfCliente) VALUES (@nomeCliente, @Sobrenome, @cpfCliente)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.Sobrenome);
                    cmd.Parameters.AddWithValue("@cpfCliente", novoCliente.cpfCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Cliente WHERE idCliente = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            //Declara a SqlConnection con passando a string de conexão como parâmetro.
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução a ser executada.
                string querySelectAll = "SELECT * FROM Cliente";

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
                        //Instancia um objeto cliente do tipo ClienteDomain
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),

                            nomeCliente = rdr[1].ToString(),

                            Sobrenome = rdr[2].ToString(),

                            cpfCliente = rdr[3].ToString(),
                        };

                        //Adicionar o objeto cliente criado a lista listaClientes.
                        listaClientes.Add(cliente);
                    }
                }
            }

            return listaClientes;
        }
    }
}
