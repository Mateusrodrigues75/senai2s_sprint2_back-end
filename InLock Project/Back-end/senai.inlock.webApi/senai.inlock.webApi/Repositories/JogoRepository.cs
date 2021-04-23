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
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-7VJEO6N; initial catalog=M_Peoples; user Id=sa; pwd=Mateus90210";
        public void AtualizarUrl(int id, JogoDomain JogoAtt)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdUrl = "UPDATE Jogo SET Descricao = @Descricao, Valor = @Valor WHERE IdJogo = @IdJogo";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Descricao", JogoAtt.Descricao);
                    cmd.Parameters.AddWithValue("@Valor", JogoAtt.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Cadastra um novo Jogo   
        /// </summary>
        /// <param name="NovoJogo">Objeto NovoJogo que será Cadastrado</param>
        public void CadastrarJogo(JogoDomain NovoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogo(NomeJogo,Descricao,DataLancamento,Valor,IdEstudio) VALUES(@NomeJogo,@Descricao,@DataLancamento,@Valor, @IdEstudio)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", NovoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", NovoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", NovoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", NovoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio",NovoJogo.Estudio.IdEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um Jogo existente
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @IdJogo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os Jogos
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        public List<JogoDomain> ListarJogos()
        {

            List<JogoDomain> ListaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, NomeEstudio, IdJogo, Nomejogo, Descricao, DataLancamento, Valor  FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain Jogo = new JogoDomain()
                        {
                            Estudio =
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            },
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(rdr["Valor"])
                        };

                        ListaJogos.Add(Jogo);
                    }
                }
            }

            return ListaJogos;
        }
    }
}
