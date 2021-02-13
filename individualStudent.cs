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
    public partial class individualStudent : Form
    {
        public individualStudent()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MINHAJ; database =school; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewAdmission where ID = " + textBox1.Text + "";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                labelFullName.Text = ds.Tables[0].Rows[0][1].ToString();
                labelFather.Text = ds.Tables[0].Rows[0][2].ToString();
                labelGender.Text = ds.Tables[0].Rows[0][3].ToString();
                labelDOB.Text = ds.Tables[0].Rows[0][4].ToString();
                labelContact.Text = ds.Tables[0].Rows[0][5].ToString();
                labelEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                labelSemester.Text = ds.Tables[0].Rows[0][7].ToString();
                labelProgram.Text = ds.Tables[0].Rows[0][8].ToString();
                labelInstitue.Text = ds.Tables[0].Rows[0][9].ToString();
                labelDuration.Text = ds.Tables[0].Rows[0][10].ToString();
                labelAddress.Text = ds.Tables[0].Rows[0][11].ToString();
            }

            else
            {
                MessageBox.Show("No Record Found with the given ID", "Match Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBox1.Text = "";
                labelFullName.Text = "_______";
                labelFather.Text = "_______";
                labelGender.Text = "_______";
                labelDOB.Text = "_______";
                labelContact.Text = "_______";
                labelEmail.Text = "_______";
                labelSemester.Text = "_______";
                labelProgram.Text = "_______";
                labelInstitue.Text = "_______";
                labelDuration.Text = "_______";
                labelAddress.Text = "_______";
            }

           

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            labelFullName.Text = "_______";
            labelFather.Text = "_______";
            labelGender.Text = "_______";
            labelDOB.Text = "_______";
            labelContact.Text = "_______";
            labelEmail.Text = "_______";
            labelSemester.Text = "_______";
            labelProgram.Text = "_______";
            labelInstitue.Text = "_______";
            labelDuration.Text = "_______";
            labelAddress.Text = "_______";



        }
    }
}
