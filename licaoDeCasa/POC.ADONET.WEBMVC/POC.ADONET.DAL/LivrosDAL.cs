using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.ADONET.MODELS;
using System.Data.SqlClient;
using System.Data;

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
            
            var stringConnection = Repository.StringConnectar();
            //Atribui a string conexao no banco
            repoDB.Conn.ConnectionString = stringConnection;

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






        //feito em casa

        public bool AdcionaRegistro(LivrosMOD model)
        //public bool AdcionaRegistro(int title_idVS,string titleVS, string typeVS, string pub_idVS, double priceVS,double advanceVS, int royaltyVS, int ytd_salesVS,string notesVS, string pubdateVs)
        {
            try
            {
                //verifica se a instancia é valida
                CriarInstanciaRepoDB();
                //COMANDO SQL
                repoDB.Command.CommandText = @"INSERT INTO pubs.dbo.tabelaCloneTitles VALUES (@title_id,@title,@type,@pub_id,@price,@advance,@royalty,@ytd_sales,@notes,@pubdate)";


                // os valores
                repoDB.Command.Parameters.AddWithValue("@title_id", model.Title_id);
                repoDB.Command.Parameters.AddWithValue("@title", model.Titulo);
                repoDB.Command.Parameters.AddWithValue("@type", model.Tipo);
                repoDB.Command.Parameters.AddWithValue("@pub_id", model.Pub_id);
                repoDB.Command.Parameters.AddWithValue("@price", model.Preco);
                repoDB.Command.Parameters.AddWithValue("@advance", model.Advance);
                repoDB.Command.Parameters.AddWithValue("@royalty", model.Royalty);
                repoDB.Command.Parameters.AddWithValue("@ytd_sales", model.Ytd_Sales);
                repoDB.Command.Parameters.AddWithValue("@notes", model.Resenha);
                repoDB.Command.Parameters.AddWithValue("@pubdate", model.PubDate);

                //substitui os valores
                //repoDB.Command.Parameters.AddWithValue("@title_id", title_idVS);
                //repoDB.Command.Parameters.AddWithValue("@title", titleVS);
                //repoDB.Command.Parameters.AddWithValue("@type", typeVS);
                //repoDB.Command.Parameters.AddWithValue("@pub_id", pub_idVS);
                //repoDB.Command.Parameters.AddWithValue("@price", priceVS);  
                //repoDB.Command.Parameters.AddWithValue("@advance", advanceVS);
                //repoDB.Command.Parameters.AddWithValue("@royalty", royaltyVS);
                //repoDB.Command.Parameters.AddWithValue("@ytd_sales", ytd_salesVS);
                //repoDB.Command.Parameters.AddWithValue("@notes", notesVS);
                //repoDB.Command.Parameters.AddWithValue("@pubdate", pubdateVs);

                //ATRIBUIR PARA A PROPRIEDADE CONNECTION O OBJETO SQLCONNECTCTION JA INSTANCIADO.
                repoDB.Command.Connection = repoDB.Conn;

                //ABRE CONEXAO 
                repoDB.OpenConnection();
                //Conn.State == ConnectionState.Open)
                //repoDB.fecharConexao();
                bool valida = (repoDB.Conn.State == ConnectionState.Open ?true : false  );


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







        public bool AlteraRegistro(LivrosMOD livrosTeste)
        {
            int retorno = 0;
            try
            {
                //método que instancia o repodb
                CriarInstanciaRepoDB();

                //comando para alterar 
                repoDB.Command.CommandText = "update pubs.dbo.tabelaCloneTitles set notes = @notes, price = @price where title_id = @title_id";

                //substituições e associações
                repoDB.Command.Parameters.AddWithValue("@notes", livrosTeste.Resenha);
                repoDB.Command.Parameters.AddWithValue("@price", livrosTeste.Preco);
                repoDB.Command.Parameters.AddWithValue("@title_id", livrosTeste.Id);

                if (repoDB.OpenConnection())
                {
                    retorno = repoDB.Command.ExecuteNonQuery();
                }

                repoDB.Conn.Close();
                   

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                repoDB.fecharConexao();
            }
            return retorno == 0 ? false: true;
        }
    }
}
