using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepositoty : IFuncionariosRepository
    {
        private string stringConexao = "Data Source=DESKTOP-7VJEO6N; initial catalog=M_Peoples; user Id=sa; pwd=Mateus90210";
        public void AtualizarIdUrl(int id, FuncionariosDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateIdUrl = "UPDATE Funcionarios SET nome = @Nome, sobrenome = @sobrenome, DataNascimento = @DataNascimento WHERE idFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);
                    cmd.Parameters.AddWithValue("@ID",id);
                    cmd.Parameters.AddWithValue("@DataNAscimento", funcionario.DataNascimento);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionariosDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT idFuncionario, nome, sobrenome FROM Funcionarios WHERE idFuncionario = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        FuncionariosDomain funcionarioBuscado = new FuncionariosDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),

                            nome = rdr["nome"].ToString(),
                            sobrenome = rdr["sobrenome"].ToString()
                        };

                        return funcionarioBuscado;
                    }
                    return null;
                }
            }
        }

        public List<FuncionariosDomain> BuscarPorNome(string nome)
        {
            // Cria uma lista funcionarios onde serão armazenados os dados
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idFuncionario, nome, sobrenome, DataNascimento FROM Funcionarios" +
                                        $" WHERE Nome LIKE '%{nome}%'";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto funcionario do tipo FuncionarioDomain
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna IdFuncionario da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"])

                            // Atribui à propriedade Nome o valor da coluna Nome da tabela do banco de dados
                            ,
                            nome = rdr["nome"].ToString()

                            // Atribui à propriedade Sobrenome o valor da coluna Sobrenome da tabela do banco de dados
                            ,
                            sobrenome = rdr["sobrenome"].ToString()

                            // Atribui à propriedade DataNascimento o valor da coluna DataNascimento da tabela do banco de dados
                            ,
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        // Adiciona o filme criado à lista funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de funcionarios
            return funcionarios;
        }

        public void Cadastrar(FuncionariosDomain novoFuncionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Funcionarios(nome, sobrenome) VALUES(@nome, @sobrenome)";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", novoFuncionario.sobrenome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE idFuncionarios = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionariosDomain> ListarNomeCompleto()
        {
            // Cria uma lista funcionarios onde serão armazenados os dados
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFuncionario, CONCAT (Nome, ' ', Sobrenome), DataNascimento FROM Funcionarios";

                // Outra forma
                //string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto funcionario do tipo FuncionarioDomain
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna IdFuncionario da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"])

                            // Atribui à propriedade Nome os valores das colunas Nome e Sobrenome da tabela do banco de dados
                            ,
                            nome = rdr[1].ToString()

                            // Atribui à propriedade DataNascimento o valor da coluna DataNascimento da tabela do banco de dados
                            ,
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        // Adiciona o filme criado à lista funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de funcionarios
            return funcionarios;
        }

        public List<FuncionariosDomain> ListarOrdenado(string ordem)
        {
            // Cria uma lista funcionarios onde serão armazenados os dados
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idFuncionario, nome, sobrenome, DataNascimento FROM Funcionarios" +
                                        $" WHERE Nome LIKE '%{ordem}%'";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto funcionario do tipo FuncionarioDomain
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            // Atribui à propriedade IdFuncionario o valor da coluna IdFuncionario da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"])

                            // Atribui à propriedade Nome o valor da coluna Nome da tabela do banco de dados
                            ,
                            nome = rdr["nome"].ToString()

                            // Atribui à propriedade Sobrenome o valor da coluna Sobrenome da tabela do banco de dados
                            ,
                            sobrenome = rdr["sobrenome"].ToString()

                            // Atribui à propriedade DataNascimento o valor da coluna DataNascimento da tabela do banco de dados
                            ,
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        // Adiciona o filme criado à lista funcionarios
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de funcionarios
            return funcionarios;
        }

        public List<FuncionariosDomain> ListarTodos()
        {
            List<FuncionariosDomain> listaFuncionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFuncionario, nome, sobrenome FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain()
                        {
                            idFuncionario = Convert.ToInt32(rdr[0]),
                            nome = rdr[1].ToString(),
                            sobrenome = rdr[2].ToString()
                        };

                        listaFuncionarios.Add(funcionario);
                    }
                }
            }

            return listaFuncionarios;
        }
    }
}
