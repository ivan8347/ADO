using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBtools;
namespace Academy
{
    public partial class MainForm : Form
    {
        DBtools.Connector connector;
        //DBtools.Connector movies_connector;

        public MainForm()
        {
            InitializeComponent();
            connector = new DBtools.Connector("Data Source=KIT1\\SQLEXPRESS;Initial Catalog=SPU_411_Import;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            // movies_connector = new DBtools.Connector("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Movies_SPU_411;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            // dgvDirections.DataSource = movies_connector.Select("SELECT * FROM Directors");
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    toolStripStatusLabel.Text = $"Количество студентов: {dgvStudents.RowCount - 1}";
                    break;
                case 1:
                    toolStripStatusLabel.Text = $"Количество групп: {dgvGroups.RowCount - 1}";
                    break;
                case 2:
                    toolStripStatusLabel.Text = $"Количество направлений обучения:{dgvDirections.RowCount - 1}";
                    break;
                case 3:
                    toolStripStatusLabel.Text = $"Количество дисциплин:{dgvDisciplines.RowCount - 1}";
                    break;
                case 4:
                    toolStripStatusLabel.Text = $"Количество преподователей:{dgvTeachers.RowCount - 1}";
                    break;
            }
        }
        private void LoadAllTables()
        {
            dgvStudents.DataSource = connector.Select("SELECT * FROM Students");
            dgvGroups.DataSource = connector.Select("SELECT * FROM Groups");
            dgvDirections.DataSource = connector.Select("SELECT * FROM Directions");
            dgvDisciplines.DataSource = connector.Select("SELECT * FROM Disciplines");
            dgvTeachers.DataSource = connector.Select("SELECT * FROM Teachers");
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAllTables();
        }
    }
}
