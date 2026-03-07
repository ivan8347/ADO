using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace IntroductionToADO
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies_SPU_411;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connection_string);
            string cmd = "SELECT title,year,first_name,last_name FROM Movies JOIN Directors ON(director=director_id)";

            Connector connector = new Connector(connection_string);
            connector.Select("title,year,first_name,last_name", "Movies,Directors", "director=director_id");
            Console.WriteLine("\n-------------------------------------------------------------\n");

            string table = "Movies";
            //Console.WriteLine(connector.Scalar($"SELECT MAX(director_id) FROM Directors"));
            Console.WriteLine(connector.GetLastPrimaryKey(table));
            Console.WriteLine(connector.GetNextPrimaryKey(table));
            Console.WriteLine(connector.GetPrimaryKeyColumn(table));
            Console.WriteLine("\n-------------------------------------------------------------\n");
            connector.Insert
                (
                     $"IF NOT EXISTS (SELECT * FROM Directors WHERE last_name=N'Scott' AND first_name=N'Gray') " +
                     $"INSERT Directors VALUES({connector.GetNextPrimaryKey("Directors")},N'Scott',N'Gray')"
                );
            //connector.Insert("Directors", $"{connector.GetNextPrimaryKey("Directors")},N'Besson',N'Luc'");
            connector.Update("UPDATE Directors SET last_name=N'Lettich',first_name=N'Sheldon' WHERE director_id=8");
            connector.Select("*", "Directors");
            Console.WriteLine("\n-------------------------------------------------------------\n");

            connector.Select(cmd);

            Console.WriteLine(connector.GetPrimaryKey("SELECT director_id FROM Directors WHERE last_name=N'Cameron' AND first_name=N'James'"));
            Console.WriteLine(connector.GetPrimaryKey("Directors", "  last_name,  first_name ", "   Cameron  ,  James   "));
            Console.WriteLine(connector.GetPrimaryKey("Movies", "  title,  director ", "The Heat, 5"));
            Console.WriteLine(connector.GetPrimaryKey("Movies", "  title,  year ", "The Heat, 1995-12-15"));
        }
    }
}