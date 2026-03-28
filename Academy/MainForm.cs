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
                "group_id,last_name,first_name,middle_name,group_name,direction_name",
                "[group] = group_id AND direction = direction_id"
                ),
            new Query
                (
                "Groups,Directions",
                "group_name,weekdays,start_time,start_date,direction_name",
                "direction = direction_id"
                ),
            new Query ("Directions", "*"),

             new Query
                (
                    "Disciplines ",
                    "*",
                   // "discipline_id, discipline_name, number_of_lessons",
                    "1 = 1"
                ),
            /*new Query
                (
                "Disciplines, Directions, DisciplinesDirectionsRelation",
                "discipline_id,discipline_name,number_of_lessons",
                "Disciplines.discipline_id = DisciplinesDirectionsRelation.discipline " +
                "AND Directions.direction_id = DisciplinesDirectionsRelation.direction"
                ),*/
            new Query
                (
                    "Teachers",
                    "*",
                   // "teacher_id, last_name, first_name, middle_name, birth_date, email, phone, photo, work_since, rate",
                    " 1 = 1"
                ),


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

        /// //////////////////////////
        Dictionary<string, int> d_directions = null;
        Dictionary<string, Dictionary<string, int>> d_trees = null;
        public MainForm()
        {
            InitializeComponent();
            tables = new DataGridView[] { dgvStudents, dgvGroups, dgvDirections, dgvDisciplines, dgvTeachers };
            // AllocConsole();
            connector = new DBtools.Connector("Data Source=KIT1\\SQLEXPRESS;Initial Catalog=SPU_411_Import;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            tabControl_SelectedIndexChanged(tabControl, null);

            d_trees = new Dictionary<string, Dictionary<string, int>>();
            d_trees.Add(nameof(d_directions), d_directions);
            LoadDataToComboBox(cbGroupsDirection);
            LoadDataToComboBox(cbStudentsGroup);
            LoadDataToComboBox(cbStudentsDirection);
            LoadDataToComboBox(cbDisciplinesDirection);
            LoadDataToComboBox(cbTeachersDiscipline);
           // LoadDataToComboBox(cbTeachersTeacher);
            cbGroupsDirection.Items.Insert(0, "Все направления");
            cbStudentsDirection.Items.Insert(0, "Все направления");
            cbStudentsGroup.Items.Insert(0, "Все группы");
            cbDisciplinesDirection.Items.Insert(0, "Все направления");
            cbTeachersDiscipline.Items.Insert(0, "Все дисциплины");
           // cbTeachersTeacher.Items.Insert(0, "Все преподователи");
        }
        int CountRecordsInDGV(DataGridView dgv)
        {
            return dgv.RowCount == 0 ? 0 : dgv.RowCount - 1;
        }

        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        void LoadDataToComboBox(ComboBox comboBox)
        {
            string table = comboBox.Name.Substring(Array.FindLastIndex<char>(comboBox.Name.ToCharArray(), Char.IsUpper)) + "s";
            string dictionary_name = $"d_{table}".ToLower();
            //Console.WriteLine("\n----------------------------------------\n");
            //Console.WriteLine(table);
            //Console.WriteLine(dictionary_name);
            //Console.WriteLine("\n----------------------------------------\n");
            d_trees[dictionary_name] = connector.LoadDictionary(table);
            foreach (KeyValuePair<string, int> i in d_trees[dictionary_name])
            {
                comboBox.Items.Add(i.Key);
            }
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = tabControl.SelectedIndex;
            tables[i].DataSource = connector.Select(queries[i].ToString());
            toolStripStatusLabel.Text = $"{statusBarSignatures[i]}:  {tables[i].RowCount - 1}";
        }

        private void cbGroupsDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            tables[1].DataSource = connector.Select
                (
                 queries[1].ToString() +
                  (
                  cbGroupsDirection.SelectedIndex == 0 ? "" : $" " +
                  $"AND direction = {d_trees["d_directions"][cbGroupsDirection.SelectedItem.ToString()]}"
                  )
                );
            toolStripStatusLabel.Text = $"{statusBarSignatures[1]}: {CountRecordsInDGV(tables[1])}";
        }

        private void cbStudentsDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            tables[0].DataSource = connector.Select
               (
                queries[0].ToString() +
                (cbStudentsDirection.SelectedIndex == 0 ? "" : $" " +
                $"AND direction = {d_trees["d_directions"][cbStudentsDirection.SelectedItem.ToString()]}")
               );
            toolStripStatusLabel.Text = $"{statusBarSignatures[0]}: {CountRecordsInDGV(tables[0])}";
        }

        private void cbStudentsGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            tables[0].DataSource = connector.Select
              (
               queries[0].ToString() +
               (
               cbStudentsGroup.SelectedIndex == 0 ? "" : $" " +
               $"AND [group] = {d_trees["d_groups"][cbStudentsGroup.SelectedItem.ToString()]}")
              );
            toolStripStatusLabel.Text = $"{statusBarSignatures[0]}: {CountRecordsInDGV(tables[0])}";
        }
        private void cbDisciplinesDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            tables[3].DataSource = connector.Select
           (
                 queries[3].ToString() +
              (
               cbDisciplinesDirection.SelectedIndex == 0
                ? "" :
                $" AND EXISTS ( SELECT * FROM DisciplinesDirectionsRelation " +
                $" WHERE DisciplinesDirectionsRelation.discipline = discipline_id  " +
                $"AND direction = {d_trees["d_directions"][cbDisciplinesDirection.SelectedItem.ToString()]})"
              )
           );
            toolStripStatusLabel.Text = $"{statusBarSignatures[3]}: {CountRecordsInDGV(tables[3])}";
        }
        private void cbTeachersDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            tables[4].DataSource = connector.Select
            (
                queries[4].ToString() +
                (
                    cbTeachersDiscipline.SelectedIndex == 0
                    ? "" :
                    $"AND EXISTS ( SELECT * FROM TeachersDisciplinesRelation " +
                    $"WHERE TeachersDisciplinesRelation.teacher = teacher_id " +
                    $"AND discipline = {d_trees["d_disciplines"][cbTeachersDiscipline.SelectedItem.ToString()]})"
                )
            );

            toolStripStatusLabel.Text = $"{statusBarSignatures[4]}: {CountRecordsInDGV(tables[4])}";
        }

        private void cbTeachersTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /*private void cbDisciplinesDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            tables[3].DataSource = connector.Select
                (
                queries[3].ToString() +
                (
                cbDisciplinesDirection.SelectedIndex == 0 ? "" : $" " +
                $" AND Directions.direction_id = {d_trees["d_directions"][cbDisciplinesDirection.SelectedItem.ToString()]}"
                )
                );
            toolStripStatusLabel.Text = $"{statusBarSignatures[3]}: {CountRecordsInDGV(tables[3])}";
        }*/

        /* private void cbTeachersDiscipline_SelectedIndexChanged(object sender, EventArgs e)
         {
             tables[4].DataSource = connector.Select
              (
               queries[4].ToString() +
               (
               cbTeachersDiscipline.SelectedIndex == 0 ? "" : $" " +
               $" AND Disciplines.discipline_id = {d_trees["d_discipline"][cbTeachersDiscipline.SelectedItem.ToString()]}")
              );
         }*/



    }
}
