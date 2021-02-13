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
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

            if (txtStudentId.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = MINHAJ; database =school; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select fullName, fatherName, duration from NewAdmission where ID = " + txtStudentId.Text + "";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                if (DS.Tables[0].Rows.Count != 0)
                {
                    fullNameLabel.Text = DS.Tables[0].Rows[0][0].ToString();
                    fatherNameLabel.Text = DS.Tables[0].Rows[0][1].ToString();
                    durationLabel.Text = DS.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    fullNameLabel.Text = "___________";
                    fatherNameLabel.Text = "___________";
                    durationLabel.Text = "___________";
                }

            }

            else
            {
                fullNameLabel.Text = "___________";
                fatherNameLabel.Text = "___________";
                durationLabel.Text = "___________";
                txtStudentId.Text = "";
                txtFees.Text = "";
            }

            

            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MINHAJ; database =school; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from fees where ID = " + txtStudentId.Text + "";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);


            if (DS.Tables[0].Rows.Count == 0)
            {
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = "data source = MINHAJ; database =school; integrated security = True";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;

                cmd1.CommandText = "insert into fees (ID, fees) values (" + txtStudentId.Text + "," + txtFees.Text + ")";

                SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();
                DA1.Fill(DS1);

                if (MessageBox.Show("Fee deposited successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    txtStudentId.Text = "";
                    txtFees.Text = "";
                    fullNameLabel.Text = "___________";
                    fatherNameLabel.Text = "___________";
                    durationLabel.Text = "___________";
                }
            }

            else
            {
                MessageBox.Show("Fee has already been deposited!");
                txtStudentId.Text = "";
                txtFees.Text = "";
                fullNameLabel.Text = "___________";
                fatherNameLabel.Text = "___________";
                durationLabel.Text = "___________";
            }


            
        }
    }
}
