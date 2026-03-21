using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    internal class Query
    {
        public string Tables { get; set; }
        public string Fields{get;set;}
        public string Condition {  get; set; }
        public string Group_by { get; set; }

        public Query(string tables, string fields, string condition = "", string group_by = "")
        {
            this.Tables = tables;
            this.Fields = fields;
            this.Condition = condition;
            this.Group_by = group_by;
        }
        public override string ToString()
        {
            string cmd = $"SELECT {Fields} FROM {Tables}";
            if (Condition != "" && Condition != " ") cmd += $" WHERE {Condition}";
            if (Group_by != "") cmd += $" GROUP BY {Group_by}";
            cmd += ";";
            return cmd;

            
        }
    }
}
