using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.ADONET.DAL
{
    public class ClienteDAL
    {
        Repository repoDB;

        public bool Add(string nome, string email, string observacao = "")
        {

            //verifica se a instancia é valida
            if (repoDB == null)
            {
                //se não cria uma
                repoDB = new Repository();
            }


            //ATRIBUI UMA STRING CONEXÃO
            repoDB.Conn.ConnectionString = "Data Source=3P47_14;" +
                                           "Initial Catalog=LivraiaGames;" +
                                           "User ID=sa;Password=Imp@ct@";

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
    }
}
