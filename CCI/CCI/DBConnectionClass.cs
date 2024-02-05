using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CCI
{
    class DBConnectionClass
    {
        public SqlConnection getConnection()
        {

            SqlConnection sqlCon = null;
            try
            {

                sqlCon = new SqlConnection("data source=SANDUSHA;initial catalog=CIC;Integrated Security=True");
                sqlCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Db" + ex);

            }
            return sqlCon;
        }
    }
}

