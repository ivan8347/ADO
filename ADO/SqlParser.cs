using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class SqlResult
    {
        public string CommandType { get; set; } // INSERT / UPDATE / DELETE / SELECT
        public string Table { get; set; }       // имя таблицы
        public string Fields { get; set; }      // список полей
        public string Values { get; set; }      // список значений
        public string Condition { get; set; }   // WHERE ...
        public string Join { get; set; }
        public string OrderBy { get; set; }

        public string Raw { get; set; }         // исходный SQL
    }
    public static class SqlParser
    {
        public static SqlResult ParseInsert(string cmd)
        {
            string upper = cmd.ToUpper();

            // --- TABLE ---
            // INSERT INTO Directors VALUES (...)
            // INSERT INTO Directors(field1, field2) VALUES (...)
            string[] parts = cmd.Split(new char[] { ' ', '(' }, StringSplitOptions.RemoveEmptyEntries);
            string table = parts[2]; // после INSERT INTO

            // Проверяем, есть ли список полей
            bool hasFields = upper.Contains("(") && upper.IndexOf("(") < upper.IndexOf("VALUES");

            string fields = "";
            string values = "";

            if (hasFields)
            {
                // INSERT INTO Directors(field1, field2) VALUES (v1, v2)
                string[] inside = cmd.Split(new char[] { '(', ')' }, StringSplitOptions.None);
                // inside[1] = field1, field2
                // inside[3] = v1, v2
                fields = inside[1].Trim();
                values = inside[3].Trim();
            }
            else
            {
                // INSERT INTO Directors VALUES (v1, v2)
                string afterValues = cmd.Split(new string[] { "VALUES" }, StringSplitOptions.None)[1];
                values = afterValues.Trim().Trim('(', ')');
            }

            return new SqlResult
            {
                CommandType = "INSERT",
                Table = table,
                Fields = fields,
                Values = values,
                Raw = cmd
            };
        }

        public static SqlResult ParseUpdate(string cmd)
        {
            string table = cmd.Split(' ')[1];
            string setPart = cmd.Split(new string[] {"SET"},StringSplitOptions.None) [1]
                .Split(new string[] {"WHERE"}, StringSplitOptions.None)[0]
                .Trim();
            string condition = cmd.Contains("WHERE")
                ? cmd.Split
                (new string[] { "WHERE" }, StringSplitOptions.None)[1].Trim() : "";
            return new SqlResult
            {
                CommandType = "UPDATE",
                Table = table,
                Fields = setPart,
                Condition = condition,
                Raw = cmd
            };
        }
        public static SqlResult ParseDelete(string cmd)
        {
            string table = cmd.Split(' ') [2];
            string condition = cmd.Contains("WHERE")
               ? cmd.Split
               (new string[] { "WHERE" }, StringSplitOptions.None)[1].Trim() : "";
            return new SqlResult
            {
                CommandType = "DELETE",
                Table = table,
                Condition = condition,
                Raw = cmd
            };
        }

        public static SqlResult ParseSelect(string cmd)
        {
            string upper = cmd.ToUpper();

            // --- SELECT поля ---
            string fields = cmd.Split(new string[] { "SELECT" }, StringSplitOptions.None)[1]
                               .Split(new string[] { "FROM" }, StringSplitOptions.None)[0]
                               .Trim();

            // --- FROM + всё, что после ---
            string afterFrom = cmd.Split(new string[] { "FROM" }, StringSplitOptions.None)[1].Trim();

            // --- TABLE ---
            string table = afterFrom.Split(' ')[0];

            // --- JOIN ---
            string join = "";
            if (upper.Contains("JOIN"))
            {
                join = afterFrom.Split(new string[] { "JOIN" }, StringSplitOptions.None)[1].Trim();

                if (join.ToUpper().Contains("WHERE"))
                    join = join.Split(new string[] { "WHERE" }, StringSplitOptions.None)[0].Trim();

                if (join.ToUpper().Contains("ORDER BY"))
                    join = join.Split(new string[] { "ORDER BY" }, StringSplitOptions.None)[0].Trim();
            }

            // --- WHERE ---
            string condition = "";
            if (upper.Contains("WHERE"))
            {
                condition = cmd.Split(new string[] { "WHERE" }, StringSplitOptions.None)[1].Trim();

                if (condition.ToUpper().Contains("ORDER BY"))
                    condition = condition.Split(new string[] { "ORDER BY" }, StringSplitOptions.None)[0].Trim();
            }

            // --- ORDER BY ---
            string orderBy = "";
            if (upper.Contains("ORDER BY"))
            {
                orderBy = cmd.Split(new string[] { "ORDER BY" }, StringSplitOptions.None)[1].Trim();
            }

            return new SqlResult
            {
                CommandType = "SELECT",
                Table = table,
                Fields = fields,
                Join = join,
                Condition = condition,
                OrderBy = orderBy,
                Raw = cmd
            };
        }


        public static SqlResult Parse(string cmd) 
        {
        string upper = cmd.ToUpper();
            if (upper.StartsWith ("INSERT")) return ParseInsert(cmd);
            if (upper.StartsWith ("UPDATE")) return ParseUpdate(cmd);
            if (upper.StartsWith ("DELETE")) return ParseDelete(cmd);
            if (upper.StartsWith ("SELECT")) return ParseSelect(cmd);

            throw new Exception("Неизвестный SQL‑запрос");

        }



            //public static string GetTableFromInsert(string cmd)
            //{
            //    string[] parts = cmd.Split(' ', '(', ')');
            //    return parts[1];
            //}
            //public static string GetFieldsFromInsert(string cmd)
            //{
            //    string[] parts = cmd.Split('(', ')');
            //    return parts[1];
            //}
            //public static string GetValuesFromInsert(string cmd)
            //{
            //    string[] parts = cmd.Split('(', ')');
            //    return parts[3];
            //}
        
    }
}
