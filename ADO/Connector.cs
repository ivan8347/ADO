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
            Select(cmd);
            //connection.Open();
            //SqlCommand command = new SqlCommand(cmd, connection);
            //SqlDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        Console.Write(reader[i].ToString().PadRight(29));
            //    }
            //    Console.WriteLine();
            //}
            //reader.Close();
            //connection.Close();

        }

        public void Insert(string cmd)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(cmd, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Insert(string table, string values)
        {
            string cmd = $"INSERT INTO {table} VALUES ({values})";
            Insert(cmd);
            //connection.Open();
            //SqlCommand command = new SqlCommand(cmd, connection);
            //command.ExecuteNonQuery();
            //connection.Close();

        }
        public void Select(string cmd)
        {

            connection.Open();
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i].ToString().PadRight(29));
                }
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();

        }
        public object Scalar(string cmd)
        {
            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            //int value = Convert.ToInt32(command.ExecuteScalar());
            object value = command.ExecuteScalar();
            connection.Close();
            return value;
        }
        public string GetPrimaryKeyColumn(string table)
        {
            return (string)Scalar
                (
                $"SELECT COLUMN_NAME" +
                $" FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE " +
                $"WHERE CONSTRAINT_NAME = (SELECT CONSTRAINT_NAME" +
                $" FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS " +
                $"WHERE TABLE_NAME = N'{table}' AND CONSTRAINT_TYPE = N'PRIMARY KEY')"
                );
        }
        public int GetLastPrimaryKey(string table)
        {
            return Convert.ToInt32(Scalar($"SELECT MAX({GetPrimaryKeyColumn(table)})FROM {table}")) ;
            /*(
            $"SELECT CONSTRAINT_NAME" +
            $" FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS" +
            $" WHERE CONSTRAINT_TYPE = N'PRIMARY KEY " +
            $"'AND TABLE_NAME = N'{table}';"
            );

            string primary_key_column = result as string;
            Console.WriteLine(primary_key_column);
            return primary_key_column;*/

        }
        public int GetNextPrimaryKey(string table)
        {
            return GetLastPrimaryKey(table) + 1;
        }
         public void Update(string cmd)
        {
            SqlCommand command = new SqlCommand (cmd, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close ();

        }
        public void Delete(string table, string condition)
        {
            string cmd = $"DELETE FROM {table} WHERE {condition};";

            connection.Open();
            SqlCommand command = new SqlCommand(cmd, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }


    }
}
