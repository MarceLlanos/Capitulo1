using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1
{
    class DataSetDataTableDataAdapterExample
    {
        SqlConnection connection;

        public DataSetDataTableDataAdapterExample()
        {
            connection = new ConnectionToDatabase().ConnectToDatabase("localhost", "Person", "root", "");

        }

        public void GetData(string table)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT * FROM {0}", table), connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, table);

            connection.Close();

            foreach  (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Console.WriteLine(string.Format("First Name: {0} , Last Name: {1}", dataRow["FirstName"], dataRow["LastName"]));
            }
        }
    }
}
