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

            string table = "Movies";
            // Console.WriteLine(connector.Scalar("Select MAX(director_id) FROM Directors"));
            Console.WriteLine(connector.GetLastPrimaryKey(table));
            Console.WriteLine(connector.GetNextPrimaryKey(table));
            Console.WriteLine(connector.GetPrimaryKeyColumn(table));
            // connector.GetNextPrimaryKey(table);
            /*  connector.Insert
                (
                $"IF NOT EXISTS(SELECT * FROM Directors WHERE last_name = N'Besson' AND first_name = N'Luc')" +
                $" INSERT Directors VALUES ({connector.GetNextPrimaryKey("Directors")}, N'Scott', N'Gray')"
                );
            */
            connector.InsertUnique
                (
                    "Directors",
                    "last_name, first_name",
                    $"{connector.GetNextPrimaryKey("Directors")}, N'Besson', N'Luc'"
                );


            //connector.Insert("Directors", $"{connector.GetNextPrimaryKey("Directors")}, N'Besson',N'Luc'");
            //connector.Update("UPDATE Directors SET last_name = N'Lettich', first_name = N'Sheldon' WHERE director_id = 10");
            //connector.Delete("Directors", "director_id = 13");
            // connector.RemoveDuplicates("Directors", "last_name, first_name");
            //connector.RemoveDuplicates("Movies", "title, year");

            connector.Select("*", "Directors");
            Console.WriteLine("\n-------------------------------------------------------------\n");
            connector.Select(cmd);
        }
    }
}
