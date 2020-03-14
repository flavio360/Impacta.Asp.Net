using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.ADONET.MODELS;
using System.Data.SqlClient;

namespace POC.ADONET.DAL
{
    public class LivrosDAL
    {
        Repository repoDB;

        private void CriarInstanciaRepoDB()
        {
            if (repoDB == null)
            {
                //se não cria uma
                repoDB = new Repository();
            }

            //Atribui a string conexao no banco
            //repoDB.Conn.ConnectionString = stringConnection;

            //atribui a sqlconnection

            repoDB.Command.Connection = repoDB.Conn;
        }

        public List<LivrosMOD>GetBooks()
        {
            SqlDataReader dataReader = null;
            List<LivrosMOD> listaLivros = new List<LivrosMOD>();

            try
            {
                //cria conexão
                CriarInstanciaRepoDB();

                //comando SQL
                repoDB.Command.CommandText = @"SELECT * FROM TITLES ORDER BY TITLE";

                //abre conexão

                if (repoDB.OpenConnection())
                {
                    LivrosMOD livro = new LivrosMOD();
                    dataReader = repoDB.Command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        livro.Id = dataReader["title_id"].ToString();
                        livro.Titulo = dataReader["title"].ToString();
                        livro.Tipo = dataReader["type"].ToString();
                        livro.Preco = (float)dataReader["price"];

                        //var preco = dataReader["price"] == null ? null : Convert.ToDecimal(dat)
                        // livro.Preco = (float)Convert.ToDecimal(dataReader["price"]);

                        livro.Resenha = dataReader["notes"].ToString();

                        //adiciona na lista

                        listaLivros.Add(livro);

                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //encera o uso do objeto sqldatareadere
                dataReader.Close();
                //fecha conexão DB
                repoDB.fecharConexao(); 
            }
            return listaLivros;
        }
    }
}
