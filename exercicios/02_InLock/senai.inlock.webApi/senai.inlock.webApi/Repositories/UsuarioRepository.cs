using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = @"Data Source=DESKTOP-BHEJL7O\SQLEXPRESS; initial catalog=inlock_games_manha; user Id=sa; pwd=qwerty";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT  idUsuario, email, senha, idTipoUsuario FROM USUARIO
	                                   WHERE email = @email and senha = @senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };
                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }
    }
}
