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
    public partial class AddAssignmentMarks : Form
    {
        SqlConnection sqlCon;
        public AddAssignmentMarks()
        {
            try
            {
                DBConnectionClass obj = new DBConnectionClass();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "Assignment and Results Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            InitializeComponent();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtSID.Text))
                {

                    MessageBox.Show("Enter Student ID.", "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand
                        ("select Fundamentals_Of_Networking,Fundamentals_Of_IT,Project_Management,Entroduction_To_Ecommerce,Fundamentals_Of_Programming,Web_Development,Advance_Programming,Business_Analytics,Final_Project from AssignmentInfo where SID = '" + txtSID.Text + "'", sqlCon);

                    SqlDataReader dr = cmd2.ExecuteReader();

                    if (dr.Read())
                    {
                        cmbSub1.Text = dr[0].ToString();
                        cmbSub2.Text = dr[1].ToString();
                        cmbSub3.Text = dr[2].ToString();
                        cmbSub4.Text = dr[3].ToString();
                        cmbSub5.Text = dr[4].ToString();
                        cmbSub6.Text = dr[5].ToString();
                        cmbSub7.Text = dr[6].ToString();
                        cmbSub8.Text = dr[7].ToString();
                        cmbSub9.Text = dr[8].ToString();
                    }

                    else
                    {
                        MessageBox.Show("Student Not found", "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Seaching data" + ex, "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(cmbSub1.Text.ToString()) || String.IsNullOrEmpty(cmbSub2.Text.ToString()) ||
                    String.IsNullOrEmpty(cmbSub3.Text.ToString()) || String.IsNullOrEmpty(cmbSub4.Text.ToString()) ||
                    String.IsNullOrEmpty(cmbSub5.Text.ToString()) || String.IsNullOrEmpty(cmbSub6.Text.ToString()) ||
                    String.IsNullOrEmpty(cmbSub7.Text.ToString()) || String.IsNullOrEmpty(cmbSub8.Text.ToString()) || String.IsNullOrEmpty(cmbSub9.Text.ToString()))
                {

                    MessageBox.Show("Select student id for add assignments", "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("Update AssignmentInfo set Fundamentals_Of_Networking='" + cmbSub1.Text.ToString() + "' ,Fundamentals_Of_IT= '" + cmbSub2.Text.ToString() + "',Project_Management='" + cmbSub3.Text.ToString() + "',Entroduction_To_Ecommerce='" + cmbSub4.Text.ToString() + "',Fundamentals_Of_Programming='" + cmbSub5.Text.ToString() + "',Web_Development='" + cmbSub6.Text.ToString() + "',Advance_Programming='" + cmbSub7.Text.ToString() + "',Business_Analytics='" + cmbSub8.Text.ToString() + "',Final_Project='" + cmbSub9.Text.ToString() + "' where SID='" + txtSID.Text + "'", sqlCon);

                    int numberOfRecords = cmd3.ExecuteNonQuery();
                    if (numberOfRecords > 0)
                    {
                        MessageBox.Show("Assignment Status Updated", "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating data" + ex, "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbBatch.SelectedItem = null;
            cmbSub1.SelectedItem = null;
            cmbSub2.SelectedItem = null;
            cmbSub3.SelectedItem = null;
            cmbSub4.SelectedItem = null;
            cmbSub5.SelectedItem = null;
            cmbSub6.SelectedItem = null;
            cmbSub7.SelectedItem = null;
            cmbSub8.SelectedItem = null;
            cmbSub9.SelectedItem = null;
            txtSID.Text = "";
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtSID2.Text))
                {

                    MessageBox.Show("Enter Student ID.", "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand cmd4 = new SqlCommand
                        ("select Fundamentals_Of_Networking,Fundamentals_Of_IT,Project_Management,Entroduction_To_Ecommerce,Fundamentals_Of_Programming,Web_Development,Advance_Programming,Business_Analytics,Final_Project from ResultsInfo where SID = '" + txtSID2.Text + "'", sqlCon);

                    SqlDataReader dr = cmd4.ExecuteReader();

                    if (dr.Read())
                    {
                        txtsub1.Text = dr[0].ToString();
                        txtsub2.Text = dr[1].ToString();
                        txtsub3.Text = dr[2].ToString();
                        txtsub4.Text = dr[3].ToString();
                        txtsub5.Text = dr[4].ToString();
                        txtsub6.Text = dr[5].ToString();
                        txtsub7.Text = dr[6].ToString();
                        txtsub8.Text = dr[7].ToString();
                        txtsub9.Text = dr[8].ToString();
                    }

                    else
                    {
                        MessageBox.Show("Student Not found", "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Seaching data" + ex, "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit2_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtsub1.Text.ToString()) || String.IsNullOrEmpty(txtsub2.Text.ToString()) ||
                    String.IsNullOrEmpty(txtsub3.Text.ToString()) || String.IsNullOrEmpty(txtsub4.Text.ToString()) ||
                    String.IsNullOrEmpty(txtsub5.Text.ToString()) || String.IsNullOrEmpty(txtsub6.Text.ToString()) ||
                    String.IsNullOrEmpty(txtsub7.Text.ToString()) || String.IsNullOrEmpty(txtsub8.Text.ToString()) || String.IsNullOrEmpty(txtsub9.Text.ToString()))
                {

                    MessageBox.Show("Select student id for add marks", "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand cmd5 = new SqlCommand("Update ResultsInfo set Fundamentals_Of_Networking='" + txtsub1.Text.ToString() + "' ,Fundamentals_Of_IT= '" + txtsub2.Text.ToString() + "',Project_Management='" + txtsub3.Text.ToString() + "',Entroduction_To_Ecommerce='" + txtsub4.Text.ToString() + "',Fundamentals_Of_Programming='" + txtsub5.Text.ToString() + "',Web_Development='" + txtsub6.Text.ToString() + "',Advance_Programming='" + txtsub7.Text.ToString() + "',Business_Analytics='" + txtsub8.Text.ToString() + "',Final_Project='" + txtsub9.Text.ToString() + "' where SID='" + txtSID2.Text + "'", sqlCon);

                    int numberOfRecords = cmd5.ExecuteNonQuery();
                    if (numberOfRecords > 0)
                    {
                        MessageBox.Show("Results Updated", "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating data" + ex, "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            cmbbatch2.SelectedItem = null;
            txtsub1.Text = null;
            txtsub2.Text = null;
            txtsub3.Text = null;
            txtsub4.Text = null;
            txtsub5.Text = null;
            txtsub6.Text = null;
            txtsub7.Text = null;
            txtsub8.Text = null;
            txtsub9.Text = null;
            txtSID2.Text = null;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Cordinator obj = new Cordinator();
            obj.Show();
            this.Hide();
        }

        private void AddAssignmentMarks_Load(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand
                    ("Select distinct Batch from AssignmentInfo", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds, "AssignmentInfo");

                cmbBatch.DataSource = ds;
                cmbbatch2.DataSource = ds;
                cmbBatch.DisplayMember = "AssignmentInfo.Batch";
                cmbbatch2.DisplayMember = "AssignmentInfo.Batch";



            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex, "Assignment and Results Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
    
}
