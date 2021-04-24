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
                    command.Parameters.AddWithValue("@IdTipoUsuario", NovoUsuario.TipoUsuario = new TipoUsuarioDomain());

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

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão con passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define o comando a ser executado no banco de dados
                string querySelect = "SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuario WHERE Email = @Email AND Senha = @Senha;";

                // Define o comando cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto do tipo UsuarioDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas do banco de dados
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            Email = Convert.ToString(rdr[1]),
                            Senha = Convert.ToString(rdr[2]),
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                Titulo = Convert.ToString(rdr[3])
                            }
                        };
                        // Retorna o usuário buscado
                        return usuarioBuscado;
                    }
                    // Caso não encontre um email e senha correspondente, retorna null
                    return null;
                }
            }
        }
    }
}
