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
    public partial class CreateStudentUsers : Form
        
    {
        SqlConnection sqlCon;
        public CreateStudentUsers()
        {
            try
            {
                DBConnectionClass obj = new DBConnectionClass();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "Create User Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            InitializeComponent();
        }

        private void CreateStudentUsers_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select StudentID from  StudentUsers", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                string id = "";

                while (dr.Read())
                {
                    id = dr[0].ToString(); 
                }
                string idString = id.Substring(1);    

                int CTR = Int32.Parse(idString);
                if (CTR >= 1 && CTR < 9)
                {
                    CTR = CTR + 1;//5
                    txtUID.Text = "S00" + CTR;
                }
                else if (CTR >= 10 && CTR < 99)
                {
                    CTR = CTR + 1;
                    txtUID.Text = "S0" + CTR;
                }
                else if (CTR > 99)
                {
                    CTR = CTR + 1;
                    txtUID.Text = "S" + CTR;
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("error" + e1, "Create User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtUID.Text) || String.IsNullOrEmpty(txtCPassword.Text) || String.IsNullOrEmpty(txtCPassword.Text))
                {
                    MessageBox.Show("Fields Can't Be Empty.", "Create User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtCPassword.Text.Length < 5)
                {
                    MessageBox.Show("Password must have more than 5 characters.", "Create User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!txtCPassword.Text.Equals(txtPassword.Text))
                {
                    MessageBox.Show("Password and Confirm password should match.", "Create User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else

                {
                    SqlCommand cmd = new SqlCommand("insert into StudentUsers values('" + txtUID.Text + "', '" + txtPassword.Text + "');", sqlCon);

                    int temp = cmd.ExecuteNonQuery();

                    if (temp > 0)
                    {
                        MessageBox.Show("User created", "Create User Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to create user", "Create User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show("Error inserting data" + ex, "Create User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUID.Text = "";
            txtCPassword.Text = "";
            txtPassword.Text = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Select StudentID from  StudentUsers", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                string id = "";

                while (dr.Read())
                {
                    id = dr[0].ToString();
                }
                string idString = id.Substring(1);

                int CTR = Int32.Parse(idString);
                if (CTR >= 1 && CTR < 9)
                {
                    CTR = CTR + 1;//5
                    txtUID.Text = "S00" + CTR;
                }
                else if (CTR >= 10 && CTR < 99)
                {
                    CTR = CTR + 1;
                    txtUID.Text = "S0" + CTR;
                }
                else if (CTR > 99)
                {
                    CTR = CTR + 1;
                    txtUID.Text = "S" + CTR;
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("error" + e1, "Create User Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
