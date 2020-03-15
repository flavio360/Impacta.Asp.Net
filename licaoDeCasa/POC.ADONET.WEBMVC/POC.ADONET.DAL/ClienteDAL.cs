using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using POC.ADONET.MODELS;
using System.Data;

namespace POC.ADONET.DAL
{
    public class ClienteDAL
    {
        Repository repoDB;

        #region Variavel com string de conexão

        //ATRIBUI UMA STRING CONEXÃO PARA O CURSO
        //String stringConnection = "Data Source=3P47_14;" +
        //                          "Initial Catalog=pubs;" +
        //                          "User ID=sa;Password=Imp@ct@";

        //ATRIBUI UMA STRING CONEXÃO PARA O ESTUDO EM CASA
        String stringConnection = @"Data Source=nflopes\sqlexpress;
                                    Initial Catalog=pubs;
                                    Integrated Security=True";
        #endregion

        #region Adiciona dados cliente a DB

        public bool Add(string nome, string email, string observacao = "")
        {
            try
            {
                //verifica se a instancia é valida
                CriarInstanciaRepoDB();

                ////ATRIBUI UMA STRING CONEXÃO
                //repoDB.Conn.ConnectionString = "Data Source=3P47_14;" +
                //                               "Initial Catalog=LivraiaGames;" +
                //                               "User ID=sa;Password=Imp@ct@";

                //COMANDO SQL
                repoDB.Command.CommandText = @"INSERT INTO LivraiaGames.dbo.Cliente VALUES (@nome,@email,@observacao)";


                //substitui os valores
                repoDB.Command.Parameters.AddWithValue("@nome", nome);
                repoDB.Command.Parameters.AddWithValue("@email", email);
                repoDB.Command.Parameters.AddWithValue("@observacao", observacao);

                //ATRIBUIR PARA A PROPRIEDADE CONNECTION O OBJETO SQLCONNECTCTION JA INSTANCIADO.
                repoDB.Command.Connection = repoDB.Conn;

                //ABRE CONEXAO 
                repoDB.OpenConnection();

                //executar o isnert na base
                var retorno = repoDB.Command.ExecuteNonQuery();

                //executeNonQuery RETORNA O NUMER ODE LINHAS AFETADAS NO COMANDO
                //IF TERNARRIO PARA RETORNAR BOLL INSERCAO
                //se > 0 = true.
                return (retorno > 0 ? true : false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           finally
            {
                repoDB.fecharConexao();
            }           
        }

        public bool DeleteById(int id)
        {
            int retorno = 0;

            try
            {
               
                //criar instancia do reposiorie
                CriarInstanciaRepoDB();

                repoDB.Command.CommandText = "DELETE FROM Cliente WHERE Id = @clienteId";

                //substiui o parametro

                repoDB.Command.Parameters.AddWithValue("@clienteId", id);

                if (repoDB.OpenConnection())
                {
                    retorno = repoDB.Command.ExecuteNonQuery();
                }
            }
            catch (Exception erro)
            {
                throw erro;
            }

            finally
            {
                repoDB.fecharConexao();
            }
            return retorno > 0;
        }
        #endregion

        #region UPDATE NA TABELA
        public bool Update(ClienteMOD cliente, int id = 0)
        {
            //variavel que retorna linhas afetadas
            int retorno = 0;
            //criar instancia de RepoDB

            try
            {
                CriarInstanciaRepoDB();

                //qUERY UPDATE
                repoDB.Command.CommandText = @"UPDATE Cliente SET sNome = @Nome," +
                                                            " sEmail = @Email, "+
                                                            " sObservacoes = @Observacao" +
                                                            " WHERE Id = @clienteId ";

                //troca dos parametros

                repoDB.Command.Parameters.AddWithValue("@clienteId", cliente.Id);
                repoDB.Command.Parameters.AddWithValue("@Nome", cliente.Nome);
                repoDB.Command.Parameters.AddWithValue("@Email", cliente.Email);
                repoDB.Command.Parameters.AddWithValue("@Observacao", cliente.Observacao);

                //abri conexao
                if (repoDB.OpenConnection())
                {
                    retorno = repoDB.Command.ExecuteNonQuery();
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                repoDB.fecharConexao();
            }

            //se nº linhas = 0, nada alterado. 
            return retorno == 0 ? false : true;
        }
        #endregion


        public void CriarInstanciaRepoDB()
        {
            if (repoDB == null)
            {
                //se não cria uma
                repoDB = new Repository();
            }

            //Atribui a string conexao no banco
            repoDB.Conn.ConnectionString = stringConnection;

            //atribui a sqlconnection

            repoDB.Command.Connection = repoDB.Conn;
        }

        #region METODO RETORNA LISTA CLIENTES
        public List<ClienteMOD> selectAll()
        {
            
            //CRIAR UMA INSTANCIA RepoDB
            CriarInstanciaRepoDB();
            //para recuperar o retorno do select
            var lista = new List<ClienteMOD>();

            //OBETO DO TIPO ClienteMOD
            var cliente = new ClienteMOD();

            lista.Add(cliente);

            repoDB.Command.CommandText = "SELECT * FROM Cliente";

            //abri a conexão com BD
            if (repoDB.OpenConnection())
            {
                SqlDataReader resultadoSelect = repoDB.Command.ExecuteReader();

                while (resultadoSelect.Read())
                {
                    cliente.Id = (int)resultadoSelect["Id"];
                    cliente.Nome = resultadoSelect["Nome"].ToString();
                    cliente.Email = resultadoSelect["Email"].ToString();
                    cliente.Observacao = resultadoSelect["Observacao"].ToString();

                    //adiciona na lista


                    lista.Add(cliente);
                }              
                //fechando e deixa disponivel para leitura ou exclusao do GC
                resultadoSelect.Close();
            }

            //devolver o resultado do select para as demais camadas do projeto
            return lista;           
                        
        }
        #endregion

        #region Select por ID
        public ClienteMOD selectById(int id)
        {

            try
            {
                //CRIAR UMA INSTANCIA RepoDB
                CriarInstanciaRepoDB();

                //OBETO DO TIPO ClienteMOD
                var cliente = new ClienteMOD();

                repoDB.Command.CommandText = "SELECT * FROM Cliente WHERE ID = @id";

                //Substitui  o parametro
                repoDB.Command.Parameters.AddWithValue("@id", id);

                //abri a conexão com BD
                if (repoDB.OpenConnection())
                {
                    SqlDataReader resultadoSelect = repoDB.Command.ExecuteReader();

                    while (resultadoSelect.Read())
                    {
                        cliente.Id = (int)resultadoSelect["Id"];
                        cliente.Nome = resultadoSelect["sNome"].ToString();
                        cliente.Email = resultadoSelect["sEmail"].ToString();
                        cliente.Observacao = resultadoSelect["sObservacoes"].ToString();
                    }
                    //fechando e deixa disponivel para leitura ou exclusao do GC
                    resultadoSelect.Close();
                }
                //devolver o resultado do select para as demais camadas do projeto
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                repoDB.fecharConexao();

            }
            
        }
        #endregion
    }
}
