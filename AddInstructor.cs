using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schoolManagement
{
    public partial class AddInstructor : Form
    {
        public AddInstructor()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void AddInstructor_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String gender = "";
            bool isChecked = radioMale.Checked;

            if (isChecked)
            {
                gender = radioMale.Text;
            }
            else
            {
                gender = radioFemale.Text;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MINHAJ; database =school; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into instructor (fname,gender,dob,contact,email,semester,prog,duration,adres) values ('"+txtFullName.Text+"','"+gender+"', '"+dateTimePickerDOB.Text+"'," +
                "'"+txtContact.Text+"', '"+txtEmail.Text+"', '"+txtSemester.Text+"', '"+txtProgram.Text+"', '"+txtDuration.Text+"', '"+txtAddress.Text+"')";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MessageBox.Show("Data has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            radioMale.Checked = false;
            radioFemale.Checked = false;
            txtContact.Clear();
            txtEmail.Clear();
            txtSemester.ResetText();
            txtProgram.ResetText();
            txtDuration.ResetText();
            txtAddress.Clear();
        }
    }
}
