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
    public partial class ManageAdminusers : Form
    {
        SqlConnection sqlCon;
        public ManageAdminusers()
        {
            try
            {
                DBConnectionClass obj = new DBConnectionClass();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "Manage User Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ManageAdminusers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                    ("Select * from Mainusers where UserID='" + txtUserID.Text + "'", sqlCon);

                // cmd.Connection = sqlCon;             
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtPw.Text = dr[1].ToString();
                    cmbType.Text = dr[2].ToString();
                   
                }

                else
                {
                    MessageBox.Show("User not found", "Manage User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Seaching data" + ex, "Manage User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtUserID.Text) || String.IsNullOrEmpty(txtPw.Text) || String.IsNullOrEmpty(txtCPw.Text) || String.IsNullOrEmpty(cmbType.Text.ToString()))
                {
                    MessageBox.Show("Fields Can't Be Empty.", "Manage User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPw.Text.Length < 5)
                {
                    MessageBox.Show("Password must have more than 5 characters.", "Manage User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!txtPw.Text.Equals(txtCPw.Text))
                {
                    MessageBox.Show("Password and Confirm password should match.", "Manage User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {

                    SqlCommand cmd = new SqlCommand("Update Mainusers set  Password='" + txtPw.Text + "', Usertype='" + cmbType.Text.ToString() + "' where UserID='" + txtUserID.Text + "'", sqlCon);

                    //cmd.Connection = sqlCon;             
                    int numberOfRecords = cmd.ExecuteNonQuery();
                    if (numberOfRecords > 0)
                    {
                        MessageBox.Show("User Updated", "Manage User Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating data" + ex, "Manage User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("delete from Mainusers where UserID = '" + txtUserID.Text + "'", sqlCon);
                // cmd.Connection = sqlCon;
                int numberOfRecords = cmd.ExecuteNonQuery();
                if (numberOfRecords > 0)
                {
                    MessageBox.Show("User Deleted", "Manage User Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting data" + ex, "Manage User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "";
            txtPw.Text = "";
            txtCPw.Text = "";
            cmbType.SelectedItem = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
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
