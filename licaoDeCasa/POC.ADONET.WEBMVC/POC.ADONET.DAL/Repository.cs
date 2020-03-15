using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace POC.ADONET.DAL
{
    public class Repository
    {
        //objeto de conexao

        public SqlCommand Command { get; set; }
        public SqlConnection Conn { get; set; }

        public Repository()
        {
            Conn = new SqlConnection();
            Command = new SqlCommand();
        }

        public bool OpenConnection()
        {
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void fecharConexao()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }

        public static string   StringConnectar()
        {
            string stringConnection = string.Empty;

            //ATRIBUI UMA STRING CONEXÃO PARA O CURSO
            //String stringConnection = "Data Source=3P47_14;" +
            //                          "Initial Catalog=pubs;" +
            //                          "User ID=sa;Password=Imp@ct@";

            //ATRIBUI UMA STRING CONEXÃO PARA O ESTUDO EM CASA
            return stringConnection = @"Data Source=nflopes\sqlexpress;
                                    Initial Catalog=pubs;
                                    Integrated Security=True";
        }
    }
}
