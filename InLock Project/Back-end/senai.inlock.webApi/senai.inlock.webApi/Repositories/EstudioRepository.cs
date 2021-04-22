using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-7VJEO6N; initial catalog=M_Peoples; user Id=sa; pwd=Mateus90210";

        /// <summary>
        /// Atualiza um  existente
        /// </summary>
        /// <param name="id">ID do estudio que será atualizado</param>
        /// <param name="EstudioAtt">Objeto funcionarioAtualizado que será atualizado</param>
        public void AtualizarUrl(int id, EstudioDomain EstudioAtt)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdUrl = "UPDATE Estudio SET NomeEstudio = @NomeEstudio WHERE IdEstudio = @IdEstudio";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@NomeEstudio", EstudioAtt.NomeEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="NovoEstudio">Objeto NovoEstudio que será cadastrado</param>
        public void CadastrarEstudio(EstudioDomain NovoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(NomeEstudio) VALUES(@NomeEstudio)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeEstudio", NovoEstudio.NomeEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um Estudio existente
        /// </summary>
        /// <param name="id"></param>
        public void DeletarEstudio(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os Estudios
        /// </summary>
        /// <returns>Retorna uma lista de Estudios</returns>
        public List<EstudioDomain> ListarEstudios()
        {

            List<EstudioDomain> ListaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Estudios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain funcionario = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            NomeEstudio = rdr[1].ToString(),
                        };

                        ListaEstudios.Add(funcionario);
                    }
                }
            }

            return ListaEstudios;
        }
    }
}
