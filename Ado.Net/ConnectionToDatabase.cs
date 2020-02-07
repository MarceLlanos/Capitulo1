using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1
{
    class ConnectionToDatabase
    {
        SqlConnection connection ;

        public ConnectionToDatabase()
        {
            connection = new SqlConnection();
        }

        public SqlConnection ConnectToDatabase(string server, string database, string userId, string password)
        {
            connection.ConnectionString = String.Format("Server = {0}; Database = {1}; User Id = {2}; Password = {3}; ", server, database, userId, password);
            connection.Open();

            return connection;
        }

        
    }
}
