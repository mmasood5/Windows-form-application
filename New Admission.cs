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
    public partial class New_Admission : Form
    {
        public New_Admission()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String name = txtFullName.Text;
            String fname = txtFatherName.Text;
            String gender = "";
            bool isChecked = radioButtonMale.Checked;
            if (isChecked)
            {
                gender = radioButtonMale.Text;
            }
            else
            {
                gender = radioButtonFemale.Text;
            }

            String dob = dateTimePickerDOB.Text;
            Int64 contact = Int64.Parse(txtMobile.Text);
            String email = txtEmail.Text;
            String semester = txtSemester.Text;
            String program = txtProgram.Text;
            String institue = txtInstitute.Text;
            String duration = txtDuration.Text;
            String address = txtAddress.Text;

            SqlConnection con = new SqlConnection();

            con.ConnectionString = "data source = MINHAJ; database =school; integrated security = True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into NewAdmission (fullName, fatherName, gender, dob, contact, email, semester, program, institue, duration, addres) " +
                "values ('" + name + "', '" + fname + "', '" + gender + "', '" + dob + "', " + contact + ", '" + email + "', '" + semester + "', '" + program + "', '" + institue + "', '" + duration + "', '" + address + "')";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            con.Close();
            MessageBox.Show("Data has been saved", "Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtFatherName.Clear();
            txtAddress.Clear();
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            txtMobile.Clear();
            txtProgram.ResetText();
            txtSemester.ResetText();
            txtInstitute.ResetText();
            txtEmail.Clear();
            txtDuration.ResetText();
            
        }

        private void New_Admission_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = "data source = MINHAJ; database =school; integrated security = True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select max (ID) from NewAdmission";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            Int64 abc = Convert.ToInt64(DS.Tables[0].Rows[0][0]);
            label13.Text = (abc+1).ToString();
        }
    }
}
