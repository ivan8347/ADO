using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ADO
{
    internal class Connector
    {
        string connection_string;
        SqlConnection connection;
        public Connector(string connection_string)
        {
            this.connection_string = connection_string;
            this.connection = new SqlConnection(connection_string);
        }
        public void Select(string fileds, string tables, string condition = "")
        {
            string cmd = $"SELECT {fileds} FROM {tables}";
            if (condition != "") cmd += $" WHERE {condition}";
            cmd += ";";
            connection.Open();
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write("  " + reader[i].ToString().PadRight(29));
                }
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();

        }
        public void Insert(string table, string values)
        {
            string cmd = $"INSERT INTO {table} VALUES ({values})";
            connection.Open();
            SqlCommand command = new SqlCommand(cmd, connection);
            command.ExecuteNonQuery();

            connection.Close();

        }

        public void Update(string fileds, string tables, string values, string condition)
        {
            string cmd = $"UPDATE {fileds} SET {tables} = {values} WHERE {condition}";
            connection.Open();
            SqlCommand command = new SqlCommand(cmd, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Select(string fullQuery)
        {

            connection.Open();
            SqlCommand command = new SqlCommand(fullQuery, connection);
            SqlDataReader reader = command.ExecuteReader();
            /*for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write("| " + reader.GetName(i).PadRight(29));
            }
            // Console.WriteLine("|");

            Console.WriteLine(new string('-', (reader.FieldCount * 29)));*/

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write("  " +  reader[i].ToString().PadRight(29));
                }
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();
        }
       
        public void AddPrimaryKey(string table, string column)
        {
            string cmd = $"ALTER TABLE {table} ADD CONSTRAINT PK_{table} PRIMARY KEY ({column});";

            connection.Open();
            SqlCommand command = new SqlCommand(cmd, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
