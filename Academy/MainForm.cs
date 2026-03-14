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
           dgvDirections.DataSource = connector.Select("SELECT * FROM Directions");
            toolStripStatusLabel.Text = $"Количество направлений обучения :(dgvDirections.RowCount - 1)";
        }
    }
}
