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
    }
}
