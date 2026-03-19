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
                "group_name,weekdays,start_time,start_date,direction_name",
                "direction = direction_id"
                ),
            new Query ("Directions", "*"),
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
        //DBtools.Connector movies_connector;
        DataGridView[] tables = null;
        public MainForm()
        {
            InitializeComponent();
            tables = new DataGridView[] { dgvStudents, dgvGroups, dgvDirections, dgvDisciplines, dgvTeachers };
            // AllocConsole();
            connector = new DBtools.Connector("Data Source=KIT1\\SQLEXPRESS;Initial Catalog=SPU_411_Import;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            // movies_connector = new DBtools.Connector("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies_SPU_411;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            // dgvDirections.DataSource = movies_connector.Select("SELECT * FROM Directors");
            tabControl_SelectedIndexChanged(tabControl, null);
        }
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        //GROUP
        private void MainForm_Load(object sender, EventArgs e)
        {
            DataTable dataTable = connector.Select("SELECT direction_id, direction_name FROM Directions");

            DataRow emptyRow = dataTable.NewRow();
            emptyRow["direction_id"] = DBNull.Value;
            emptyRow["direction_name"] = "";   // или "Все направления"
            dataTable.Rows.InsertAt(emptyRow, 0);


            cbDirectionsFilter.DataSource = dataTable;
            cbDirectionsFilter.DisplayMember = "direction_name";
            cbDirectionsFilter.ValueMember = "direction_id";
            cbDirectionsFilter.SelectedIndex = 0;

            cbDisciplinesFilter.DataSource = dataTable.Copy(); 
            cbDisciplinesFilter.DisplayMember = "direction_name";
            cbDisciplinesFilter.ValueMember = "direction_id";
            cbDirectionsFilter.SelectedIndex = 0;

            cbDirectionsFilter.SelectedIndex = -1; 
        }


        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine($"{(sender as TabControl).SelectedIndex} \t{tabControl.SelectedTab.Text}");
            // dgvDirections.DataSource = connector.Select("SELECT * FROM Directions");
            // toolStripStatusLabel.Text = $"Количество направлений обучения:{dgvDirections.RowCount - 1}";
            /*DataGridView dgv = (this.GetType().GetField($"dgv{tabControl.SelectedTab.Text}").GetValue(this) as DataGridView);
            dgv.DataSource = connector.Select($"Select * from {tabControl.SelectedTab.Text}");

            toolStripStatusLabel.Text = $"Количество записей:{dgv.RowCount - 1}";*/

            int i = tabControl.SelectedIndex;
            if (i == 1)
            {
                ApplyGroupsFilter();
                return;
            }
            if (i == 3)
            {
                ApplyDisciplinesFilter();
                return;
            }


            tables[i].DataSource = connector.Select(queries[i].ToString());
            toolStripStatusLabel.Text = $"{statusBarSignatures[i]}: {tables[i].RowCount - 1}";
        }



        private void ApplyFilter(DataGridView dgv, Query query, ComboBox cb, string filterField, int tabIndex)

        {
            string statusText = statusBarSignatures[tabIndex];
            if (cb.SelectedIndex == -1 || cb.SelectedValue == null || cb.SelectedValue == DBNull.Value)
            {
                dgv.DataSource = connector.Select(query.ToString());
                toolStripStatusLabel.Text = $"{statusText} {dgv.RowCount - 1}";
                return;
            }

            int directionId = Convert.ToInt32(cb.SelectedValue);

            string sql =
                $"SELECT {query.Fields} " +
                $"FROM {query.Tables} " +
                $"WHERE {query.Condition} AND {filterField} = {directionId}";

            dgv.DataSource = connector.Select(sql);
            toolStripStatusLabel.Text = $"{statusText} {dgv.RowCount - 1}";
        }


        private void ApplyGroupsFilter()
        {
            ApplyFilter(dgvGroups, queries[1], cbDirectionsFilter, "direction_id", 1);
        }


        private void ApplyDisciplinesFilter()
        {
            ApplyFilter( dgvDisciplines, queries[3], cbDisciplinesFilter, "Directions.direction_id", 3 );
        }
 
        private void cbDirectionsFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
                ApplyGroupsFilter();

            if (tabControl.SelectedIndex == 3)
                ApplyDisciplinesFilter();
        }

       
    }
}
