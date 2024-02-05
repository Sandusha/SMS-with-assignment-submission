using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CCI
{
    public partial class AssignmentsInfo : Form
    {
        SqlConnection sqlCon;
        public AssignmentsInfo()
        {
            try
            {
                DBConnectionClass obj = new DBConnectionClass();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "Assignment View Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            InitializeComponent();
        }

        private void AssignmentsInfo_Load(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd3 = new SqlCommand
                    ("Select distinct Batch from AssignmentInfo", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();

                da.Fill(ds, "AssignmentInfo");

                cmbBatch.DataSource = ds;
                cmbBatch.DisplayMember = "AssignmentInfo.Batch";
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex, "Assignment View Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtSID.Text.ToString()))

                {

                    MessageBox.Show("Enter student Id ", "Assignment View Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand
                        ("select Fundamentals_Of_Networking,Fundamentals_Of_IT,Project_Management,Entroduction_To_Ecommerce,Fundamentals_Of_Programming,Web_Development,Advance_Programming,Business_Analytics,Final_Project from AssignmentInfo where SID = '" + txtSID.Text + "'", sqlCon);

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        Empty.Text = dr[0].ToString();
                        Empty2.Text = dr[1].ToString();
                        Empty3.Text = dr[2].ToString();
                        Empty4.Text = dr[3].ToString();
                        Empty5.Text = dr[4].ToString();
                        Empty6.Text = dr[5].ToString();
                        Empty7.Text = dr[6].ToString();
                        Empty8.Text = dr[7].ToString();
                        Empty9.Text = dr[8].ToString();
                    }

                    else
                    {
                        MessageBox.Show("Student Not found", "Assignment View Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Seaching data" + ex, "Assignment View Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Empty.Text = null;
            Empty2.Text = null;
            Empty3.Text = null;
            Empty4.Text = null;
            Empty5.Text = null;
            Empty6.Text = null;
            Empty7.Text = null;
            Empty8.Text = null;
            Empty9.Text = null;
            txtSID.Text = "";
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand SearchAssignment = new SqlCommand
        ("select SID,Fundamentals_Of_Networking,Fundamentals_Of_IT,Project_Management,Entroduction_To_Ecommerce,Fundamentals_Of_Programming,Web_Development,Advance_Programming,Business_Analytics,Final_Project from AssignmentInfo where Batch = '" + cmbBatch.Text.ToString() + "'", sqlCon);

                SqlDataAdapter da = new SqlDataAdapter(SearchAssignment);
                DataSet ds = new DataSet();
                da.Fill(ds, "AssignmentInfo");

                dataGrid1.DataSource = ds;
                dataGrid1.DataMember = "AssignmentInfo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("error selecting student " + ex, "Assignment View Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Cordinator obj = new Cordinator();
            obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
