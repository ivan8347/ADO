using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace Academy
{
    public partial class StudentForm : HumanForm
    {
        public StudentForm()
        {
            InitializeComponent();
            rtbLastName.Text = "Тупенко";
            rtbFirstName.Text = "Василий";
            rtbMiddleName.Text = "Петрович";

            cbGroup.DataSource = DataBase.Connector.Select("*", "Groups");
            cbGroup.DisplayMember = "group_name";
            cbGroup.ValueMember = "group_id";

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Academy.Models.Student student = new Models.Student
                (
                0,
                rtbLastName.Text,
                rtbFirstName.Text,
                rtbMiddleName.Text,
                dtpBirthDate.Value.ToString("yyyy-MM-dd"),
                rtbEmail.Text,
                rtbPhone.Text,
                pictureBoxPhoto.Image,
                Convert.ToInt32  (cbGroup.SelectedValue)
                );
            DataBase.Connector.Insert($"INSERT Students({student.GetNames()}) VALUES ({student})");


            //DBtools.Connector connector = new DBtools.
            // Connector(ConfigurationManager.ConnectionStrings["SPU_411_Import"].ConnectionString);
            /* DataBase.Connector.Insert


       // connector.Insert
           (
           $"INSERT Students(last_name,first_name,middle_name,birth_date,[group]) " +
           $"VALUES (N'{rtbLastName.Text}',N'{rtbFirstName.Text}',N'{rtbMiddleName.Text}',N'{dtpBirthDate.Value.ToString("yyyy-MM-dd")}'," +
           $"{cbGroup.SelectedValue})"
           );*/
        }
    }
}
