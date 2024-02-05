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
    public partial class Login : Form
    {
        SqlConnection sqlCon;
        public Login()
        {
            InitializeComponent();
            try
            {
                DBConnectionClass obj = new DBConnectionClass();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "Login Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            {
                if (String.IsNullOrEmpty(cmbUType.Text.ToString()))
                    MessageBox.Show("Select user type ", "Login Form", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                if (cmbUType.Text.ToString() == "Student" )
                    try
                    {
                        SqlCommand cmd = new SqlCommand("Select * from StudentUsers where StudentID='" + txtUid.Text.Trim() + "' and Password='" + txtPassword.Text.Trim() + "' ", sqlCon);
                        SqlDataReader dr = cmd.ExecuteReader();
                        bool records = dr.HasRows;
                        if (records)
                        {
                            MessageBox.Show("Login Successfull as Student" ,"Login Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                            GetUName.id = txtUid.Text;
                            StudentForm obj = new StudentForm();
                            obj.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("Invalid user id or password ", "Login Form", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        dr.Close();
                    }


                    catch (Exception e1)
                    {
                        MessageBox.Show("error validating login" + e1, "Login Form",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                else if (cmbUType.Text.ToString() == "Admin")

                    try
                    {
                        SqlCommand cmd = new SqlCommand("select Usertype from  Mainusers where UserID='" + txtUid.Text.Trim() + "' and Password='" + txtPassword.Text.Trim() + "' ", sqlCon);
                        SqlDataReader dr = cmd.ExecuteReader();
                        bool records = dr.HasRows;
                        if (records)
                        {
                            MessageBox.Show("Login Successfull as Administrator", "Login Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                            Admin obj = new Admin();
                            obj.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("Invalid user id or password ", "Login Form", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        dr.Close();
                    }


                    catch (Exception e1)
                    {
                        MessageBox.Show("error validating login" + e1, "Login Form",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                else

                try
                {
                        SqlCommand cmd = new SqlCommand("select Usertype from  Mainusers where UserID='" + txtUid.Text.Trim() + "' and Password='" + txtPassword.Text.Trim() + "' ", sqlCon);
                        SqlDataReader dr = cmd.ExecuteReader();
                        bool records = dr.HasRows;
                        if (records)
                        {
                            MessageBox.Show("Login Successfull as Coordinator", "Login Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                            Cordinator obj = new Cordinator();
                            obj.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("Invalid user id or password ", "Login Form", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        dr.Close();
                    }


                    catch (Exception e1)
                    {
                        MessageBox.Show("error validating login" + e1, "Login Form",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

    }
}
