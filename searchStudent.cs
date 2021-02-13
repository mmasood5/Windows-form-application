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
    public partial class searchStudent : Form
    {
        public searchStudent()
        {
            InitializeComponent();
        }

        private void searchStudent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MINHAJ; database =school; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select NewAdmission.ID as Student_ID, NewAdmission.fullName as Full_Name, NewAdmission.fatherName as Father_Name, NewAdmission.gender as Gender, NewAdmission.dob as DOB, " +
                "NewAdmission.contact as Contact, NewAdmission.email as Email, NewAdmission.semester as Semester, NewAdmission.program as Program, NewAdmission.institue as Institute," +
                "NewAdmission.duration as Duration, NewAdmission.addres as Address, fees.fees as Fees from NewAdmission inner join fees on NewAdmission.ID = fees.ID";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = MINHAJ; database =school; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewAdmission where ID = "+textBox1.Text+"";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
