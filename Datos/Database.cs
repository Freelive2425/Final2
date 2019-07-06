using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class Database
    {
        private SqlConnection conn;
        public SqlConnection ConectaDb()
        {
            try
            {
                string cadena = "Data Source=localhost, Initial Catalog=dbSeguro, Integrated Security=True";
                conn = new SqlConnection(cadena);
                conn.Open();
                return conn;
            }
            catch(SqlException e)
            {
                return null;
            }
        }
        public void DesconectaDb()
        {
            conn.Close();
        }
    }
}
