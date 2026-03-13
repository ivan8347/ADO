using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public static class SqlParser
    {
        public static string GetTableFromInsert(string cmd)
        {
            string[] parts = cmd.Split(' ', '(', ')');
            return parts[1];
        }
        public static string GetFieldsFromInsert(string cmd)
        {
            string[] parts = cmd.Split('(', ')');
            return parts[1];
        }
        public static string GetValuesFromInsert(string cmd)
        {
            string[] parts = cmd.Split('(', ')');
            return parts[3];
        }

    }
}
