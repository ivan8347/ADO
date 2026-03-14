using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

/*namespace IntroductionToADO
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
            ////connector.Insert
            ////    (
            ////         $"IF NOT EXISTS (SELECT * FROM Directors WHERE last_name=N'Scott' AND first_name=N'Gray') " +
            ////         $"INSERT Directors VALUES({connector.GetNextPrimaryKey("Directors")},N'Scott',N'Gray')"
            ////    );
            //connector.Insert("Directors", $"{connector.GetNextPrimaryKey("Directors")},N'Besson',N'Luc'");
            connector.Update("UPDATE Directors SET last_name=N'Lettich',first_name=N'Sheldon' WHERE director_id=8");
            connector.Select("*", "Directors");
            Console.WriteLine("\n-------------------------------------------------------------\n");

            connector.Select(cmd);

            Console.WriteLine(connector.GetPrimaryKey("SELECT director_id FROM Directors WHERE last_name=N'Cameron' AND first_name=N'James'"));
            Console.WriteLine(connector.GetPrimaryKey("Directors", "  last_name,  first_name ", "   Cameron  ,  James   "));
            Console.WriteLine(connector.GetPrimaryKey("Movies", "  title,  director ", "The Heat, 5"));
            Console.WriteLine(connector.GetPrimaryKey("Movies", "  title,  year ", "The Heat, 1995-12-15"));


            connector.Insert
                (
                     $"INSERT Directors(director_id,first_name,last_name) " +
                     $"VALUES({connector.GetNextPrimaryKey("Directors")},N'Georg',N'Martin')"
                );


            //connector.RemoveDuplicates("Directors", "last_name, first_name");
            //connector.RemoveDuplicates("Movies", "title, year");

        }
    }
}*/

namespace IntroductionToADO
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection_string =
                "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=Movies_SPU_411;" +
                "Integrated Security=True;";

            Connector db = new Connector(connection_string);

            Console.WriteLine("=== DELETE ===");
            // db.Delete("DELETE FROM Directors WHERE director_id = 43");
            // db.Delete("DELETE FROM Directors WHERE director_id BETWEEN 18 AND 19");




            Console.WriteLine("=== SELECT (ручная сборка SQL) ===");
            db.Select("title, year", "Movies", "year = '1995-12-15'");

            Console.WriteLine("\n-------------------------------------------------------------\n");

            Console.WriteLine("=== SELECT (готовый SQL) ===");
            string sql = "SELECT title, year FROM Movies";
            db.Select(sql);

            Console.WriteLine("\n-------------------------------------------------------------\n");

            Console.WriteLine("=== PRIMARY KEY INFO ===");
            string table = "Movies";
            Console.WriteLine("PK column: " + db.GetPrimaryKeyColumn(table));
            Console.WriteLine("Last PK:   " + db.GetLastPrimaryKey(table));
            Console.WriteLine("Next PK:   " + db.GetNextPrimaryKey(table));

            Console.WriteLine("\n-------------------------------------------------------------\n");

            Console.WriteLine("=== INSERT ===");
            int nextId = db.GetNextPrimaryKey("Directors");
            db.Insert("Directors", $"{nextId}, N'Besson', N'Luc'");
            db.Select("*", "Directors");

            Console.WriteLine("\n-------------------------------------------------------------\n");

            Console.WriteLine("=== UPDATE ===");
            db.Update("UPDATE Directors SET last_name=N'Lettich', first_name=N'Sheldon' WHERE director_id=8");
            db.Select("*", "Directors");

            Console.WriteLine("\n-------------------------------------------------------------\n");

            Console.WriteLine("=== PRIMARY KEY SEARCH ===");
            Console.WriteLine(db.GetPrimaryKey("SELECT director_id FROM Directors WHERE last_name=N'Cameron' AND first_name=N'James'"));
            Console.WriteLine(db.GetPrimaryKey("Directors", "last_name, first_name", "Cameron, James"));
            Console.WriteLine(db.GetPrimaryKey("Movies", "title, director", "The Heat, 5"));
            Console.WriteLine(db.GetPrimaryKey("Movies", "title, year", "The Heat, 1995-12-15"));

            Console.WriteLine("\n-------------------------------------------------------------\n");

            Console.WriteLine("=== INSERT через полный SQL ===");
            db.Insert(
                $"INSERT INTO Directors(director_id, first_name, last_name) " +
                $"VALUES({db.GetNextPrimaryKey("Directors")}, N'Georg', N'Martin')"
            );
            db.Select("*", "Directors");

            Console.WriteLine("\n=== END ===");

            //Console.WriteLine("=== DELETE ===");
            //  db.Delete("DELETE FROM Movies WHERE director_id = 44");
        }
    }
}
