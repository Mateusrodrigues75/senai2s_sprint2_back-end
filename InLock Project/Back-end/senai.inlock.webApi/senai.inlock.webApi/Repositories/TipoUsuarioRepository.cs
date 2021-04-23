using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {        /// <summary>
             /// String de conexão com o banco de dados que recebe os parâmetros
             /// </summary>
        private string stringConexao = "Data Source = DESKTOP - 7VJEO6N; initial catalog = M_Peoples; user Id = sa; pwd=Mateus90210";

        /// <summary>
        /// Atualiza um tipo de usuario já existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="TipoUsuarioAtt"></param>
        public void AtualizarUrl(int id, TipoUsuarioDomain TipoUsuarioAtt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastra um tipo de usuario
        /// </summary>
        /// <param name="NovoTipoUsuario"></param>
        public void CadastrarTipoUsuario(TipoUsuarioDomain NovoTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string cadastrarTipoUsuario = "INSERT INTO TipoUsuario(Titulo) VALUES(@Titulo)";
                using (SqlCommand command = new SqlCommand(cadastrarTipoUsuario, con))
                {
                    command.Parameters.AddWithValue("@Titulo", NovoTipoUsuario.Titulo);

                    con.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string deletarTipoUsuario = "DELETE FROM TipoUsuario WHERE IdTipoUsuario = @IdTipoUsuario";

                using (SqlCommand command = new SqlCommand(deletarTipoUsuario, con))
                {
                    command.Parameters.AddWithValue("@IdTipoUsuario", id);

                    con.Open();

                    command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Lista todos os tipos de usuarios
        /// </summary>
        /// <returns></returns>
        public List<TipoUsuarioDomain> ListarTipoUsuario()
        {
            List<TipoUsuarioDomain> listaDeTipoUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string listarTipoUsuario = "SELECT * FROM TipoUsuario";
                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(listarTipoUsuario, con))
                {
                    con.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(reader["IdTipoUsuario"]),
                            Titulo = Convert.ToString(reader["Titulo"])
                        };
                        listaDeTipoUsuario.Add(tipoUsuario);
                    }
                }
            }
            return listaDeTipoUsuario;
        }
    }
}
