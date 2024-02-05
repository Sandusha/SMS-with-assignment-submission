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
using System.IO;

namespace CCI
{
    public partial class ViewInformation : Form
    {
        SqlConnection sqlCon;
        public ViewInformation()
        {
            try
            {
                DBConnectionClass obj = new DBConnectionClass();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "View Student Info Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            InitializeComponent();
        }

        private void ViewInformation_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                    ("Select * from StudentInfo where SID='" + GetUName.id + "'", sqlCon);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Sidlbl.Text = dr[0].ToString();
                    Namelbl.Text = dr[1].ToString();
                    Doblbl.Text = dr[2].ToString();
                    Addresslbl.Text = dr[3].ToString();
                    Phonelbl.Text = dr[4].ToString();
                    Emaillbl.Text = dr[5].ToString();
                    Batchlbl.Text = dr[6].ToString();
                    byte[] img = (byte[])(dr[7]);
                    if (img == null)
                        Picbox.Image = null;
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        Picbox.Image = Image.FromStream(ms);
                    }
                   
                }

                else
                {
                    MessageBox.Show("User data not found", "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Seaching data" + ex, "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
