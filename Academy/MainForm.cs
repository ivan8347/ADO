using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DBtools;
namespace Academy
{
    public partial class MainForm : Form
    {
        Query[] queries =
        {
            new Query
                (
                "Students,Groups,Directions",
                "last_name,first_name,middle_name,group_name,direction_name",
                "[group] = group_id AND direction = direction_id"
                ),
            new Query
                (
                "Groups,Directions",
                "group_id,group_name,weekdays,start_time,start_date,direction_name",
                "direction = direction_id" 
                ),
            new Query
                (
                "Students RIGHT JOIN Groups ON([group] = group_id) RIGHT JOIN Directions ON (direction = direction_id)",
                "direction_id, direction_name, COUNT(DISTINCT group_id)  AS N'Количество групп', COUNT(stud_id) AS N'Количество студентов' ",
                "",
                "direction_id, direction_name"
                ),

           //new Query ("Directions", "*"),
            //new Query ("Disciplines","*"),
            new Query
                (
                "Disciplines, Directions, DisciplinesDirectionsRelation",
                "discipline_name, direction_name",
                "Disciplines.discipline_id = DisciplinesDirectionsRelation.discipline " +
                "AND Directions.direction_id = DisciplinesDirectionsRelation.direction"
                 ),

            new Query ("Teachers","*")
        };


        string[] statusBarSignatures =
        {
            "Количество студентов:",
            "Количество групп:",
            "Количество направлений:",
            "Количество дисциплин:",
            "Количество преподавателей:"

        };

        DBtools.Connector connector;
        Dictionary<string, int> d_directions;
        Dictionary<string, int> d_groups;
        DataGridView[] tables = null;
        public MainForm()
        {
            InitializeComponent();
            tables = new DataGridView[] { dgvStudents, dgvGroups, dgvDirections, dgvDisciplines, dgvTeachers };
            // AllocConsole();
            connector = new DBtools.Connector("Data Source=KIT1\\SQLEXPRESS;Initial Catalog=SPU_411_Import;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            // movies_connector = new DBtools.Connector("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies_SPU_411;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            // dgvDirections.DataSource = movies_connector.Select("SELECT * FROM Directors");

            d_directions = connector.GetDictionary("*","Directions");
            d_groups = connector.GetDictionary("group_id,group_name","Groups");
           

            cbGroupsDirection.Items.AddRange(d_directions.Select(d => d.Key).ToArray());
            cbStudentsDirection.Items.AddRange(d_directions.Select(d => d.Key).ToArray());
            cbStudentsGroup.Items.AddRange(d_groups.Select(g => g.Key).ToArray());
            cbStudentsGroup.Items.Insert(0,"Все группы");
            cbStudentsDirection.Items.Insert(0,"Все направления");
          //  cbGroupsDirection.Items.Insert(0,"Все направления");
            cbStudentsDirection.SelectedIndex = cbStudentsGroup.SelectedIndex = 0;

            tabControl_SelectedIndexChanged(tabControl, null);
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = tabControl.SelectedIndex;

            tables[i].DataSource = connector.Select(queries[i].ToString());
            toolStripStatusLabel.Text = $"{statusBarSignatures[i]}: {CountRecordsInDGV (tables[i])}";
        }
        private void cbGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
        {

            tables[1].DataSource = connector.Select
             (
              "group_id, group_name,weekdays,start_time,start_date,direction_name",
             "Groups,Directions",
              $"direction=direction_id AND direction = N'{d_directions[cbGroupsDirection.SelectedItem.ToString()]}'"
             );
            toolStripStatusLabel.Text = $"{statusBarSignatures[1]}: {CountRecordsInDGV (tables[1])}";
        }
        int CountRecordsInDGV(DataGridView dgv)
        { 
        return dgv.RowCount == 0 ? 0 : dgv.Rows.Count - 1;
        }

        private void cbStudentsDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
           int i = cbStudentsDirection.SelectedIndex;
            Dictionary<string, int> d_groups = connector.GetDictionary
                (
                "group_id,group_name",
                "Groups",
             i == 0 ? "" :
              $"direction={d_directions[cbStudentsDirection.SelectedItem.ToString()]}"
                );
            cbStudentsGroup.Items.Clear();
            cbStudentsGroup.Items.AddRange(d_groups.Select(g => g.Key).ToArray());
        }


    }
}
