using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Capitulo1
{
    class QuerysToDatabase
    {
        SqlCommand command;
        SqlConnection connection;

        public QuerysToDatabase()
        {
            command = new SqlCommand();
            command.Connection = connection;
            connection = new ConnectionToDatabase().ConnectToDatabase("localhost", "Person", "root", "");
        }

        public void InsertStatement(string tableName, string atribute1, string atribute2, string value1, string value2)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = string.Format("INSERT INTO {0} ({1}, {2}) " + "VALUES ('{3}', '{4}')", tableName, atribute1, atribute2, value1, value2);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void InsertARecord()
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "PersonInsert";
            command.Parameters.Add(new SqlParameter("@FirstName", "Joe"));
            command.Parameters.Add(new SqlParameter("@LastName", "Smith"));
            command.ExecuteNonQuery();
        }

        public void SelectData()
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Person";
            SqlDataReader dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine(string.Format("First Name: {0} , Last Name: {1}", dr["FirstName"], dr["LastName"]));
                }
            }

            dr.Close();
            connection.Close();
        }

        public void CountRecordsOnTable(string table)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("SELECT COUNT(*) FROM {0}", table);
            object obj = command.ExecuteScalar();

            Console.WriteLine(string.Format("Count: {0}", obj.ToString()));

            connection.Close();
        }

        public void XmlData()
        {
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Person FOR XML AUTO, XMLDATA";
            XmlReader xml = command.ExecuteXmlReader();

            connection.Close();
        }
    }
}
