using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CCI
{
    public partial class ViewAssignmentStatus : Form
    {
        SqlConnection sqlCon;
        public ViewAssignmentStatus()
        {
            try
            {
                DBConnectionClass obj = new DBConnectionClass();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "View Assignment Status Info Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            InitializeComponent();
        }

        private void ViewAssignmentStatus_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                    ("Select Fundamentals_Of_Networking,Fundamentals_Of_IT,Project_Management,Entroduction_To_Ecommerce,Fundamentals_Of_Programming,Web_Development,Advance_Programming,Business_Analytics,Final_Project from AssignmentInfo where SID = '" + GetUName.id + "'", sqlCon);


                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Fnlbl.Text = dr[0].ToString();
                    Filbl.Text = dr[1].ToString();
                    Pmlbl.Text = dr[2].ToString();
                    Eelbl.Text = dr[3].ToString();
                    Fplbl.Text = dr[4].ToString();
                    Wdlbl.Text = dr[5].ToString();
                    Aplbl.Text = dr[6].ToString();
                    Balbl.Text = dr[7].ToString();
                    Finallbl.Text = dr[8].ToString();

                }

                else
                {
                    MessageBox.Show("User data not found", "View Assignment Status Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Seaching data" + ex, "View Assignment Status Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentForm obj = new StudentForm();
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
