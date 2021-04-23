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
    {        /// <summary>
             /// String de conexão com o banco de dados que recebe os parâmetros
             /// </summary>
        private string stringConexao = "Data Source=DESKTOP-7VJEO6N; initial catalog=inlock_games_manha; user Id=sa; pwd=Mateus90210";

        public void AtualizarUrl(int id, UsuarioDomain UsuarioAtt)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string atualizarIdUrl = "UPDATE Usuario SET NomeUsuario = @NomeUsuario, Senha= @SenhaUsuario, Email= @EmailUsuario WHERE IdUsuario = @IdUsuario";
                using (SqlCommand command = new SqlCommand(atualizarIdUrl, con))
                {
                    command.Parameters.AddWithValue("@IdUsuario", id);
                    command.Parameters.AddWithValue("@NomeUsuario", UsuarioAtt.NomeUsuario);
                    command.Parameters.AddWithValue("@SenhaUsuario", UsuarioAtt.Senha);
                    command.Parameters.AddWithValue("@EmailUsuario", UsuarioAtt.Email);

                    con.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="NovoUsuario"></param>
        public void CadastrarUsuario(UsuarioDomain NovoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string cadastrarUsuario = "INSERT INTO Usuario(NomeUsuario, Email, Senha, IdTipoUsuario) VALUES (@NomeUsuario, @EmailUsuario, @SenhaUsuario, @IdTipoUsuario)";

                using (SqlCommand command = new SqlCommand(cadastrarUsuario, con))
                {
                    command.Parameters.AddWithValue("@NomeUsuario", NovoUsuario.NomeUsuario);
                    command.Parameters.AddWithValue("@EmailUsuario", NovoUsuario.Email);
                    command.Parameters.AddWithValue("@SenhaUsuario", NovoUsuario.Senha);
                    command.Parameters.AddWithValue("@IdTipoUsuario", NovoUsuario.TipoUsuario.IdTipoUsuario);

                    con.Open();

                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string deletarUsuario = "DELETE FROM Usuario WHERE IdUsuario = @Id";

                using (SqlCommand command = new SqlCommand(deletarUsuario, con))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    con.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns></returns>
        public List<UsuarioDomain> ListarUsuarios()
        {
            List<UsuarioDomain> listaDeUsuario = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string listarUsuario = "SELECT IdUsuario, NomeUsuario, Email, IdTipoUsuario FROM Usuario";
                SqlDataReader reader;

                con.Open();

                using (SqlCommand command = new SqlCommand(listarUsuario, con))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(reader[0]),
                            NomeUsuario = Convert.ToString(reader[1]),
                            Email = Convert.ToString(reader[2]),
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(reader[3])
                            }
                        };
                        listaDeUsuario.Add(usuario);
                    }
                }
            }

            return listaDeUsuario;
        }
    }
}
