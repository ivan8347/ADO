using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;

namespace ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies_SPU_411;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connection_string);

            string cmd = "SELECT title,year,first_name,last_name FROM Movies JOIN Directors ON (director = director_id)";
            // connection.Open();
            //// string cmd = "SELECT * FROM Movies";
            // SqlCommand command = new SqlCommand(cmd, connection);
            // SqlDataReader reader = command.ExecuteReader();
            // while (reader.Read())
            // {
            //     //Console.WriteLine($"{reader[0]} \t  {reader[1]} \t  {reader[2]}");
            //     for (int i = 0; i < reader.FieldCount; i++)
            //     {
            //         //Console.Write(reader[i] +   "\t");
            //         Console.Write(reader[i].ToString().PadRight(29));
            //     }
            //     Console.WriteLine();
            // }

            // reader.Close();
            // connection.Close();
            Connector connector = new Connector(connection_string);
            connector.Select(" title,year,first_name,last_name", "Movies,Directors", "director = director_id");
            Console.WriteLine("\n-------------------------------------------------------------\n");

            //connector.Insert("Directors", "8, N'Иванов',N'Петя'");
            connector.Select(" *", "Directors");

            connector.Update("Directors", "first_name", "N'Вася'", "director_id = 6 ");

            Console.WriteLine("\n-------------------------------------------------------------\n");

            connector.Select
                (
                "SELECT \n title, year, first_name, last_name " +
                "FROM Directors LEFT JOIN Movies ON director = director_id" +
                " ORDER BY first_name "
                );
            Console.WriteLine("\n-------------------------------------------------------------\n");

            //connector.AddPrimaryKey("Directors", "director_id");

        }

    }
}
