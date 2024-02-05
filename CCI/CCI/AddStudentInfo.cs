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
    public partial class AddStudentInfo : Form
    {
        SqlConnection sqlCon;
        string imgLoc = "";
        public AddStudentInfo()
        {
            try
            {
                DBConnectionClass obj = new DBConnectionClass();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "Add Student Info Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            InitializeComponent();
     }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                    ("Select * from StudentUsers where StudentID='" + txtSearchUser.Text + "'", sqlCon);
          
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtSID.Text = dr[0].ToString();

                }

                else
                {
                    MessageBox.Show("User not found", "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Seaching data" + ex, "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
                

            {
               
                if (String.IsNullOrEmpty(txtSID.Text) || String.IsNullOrEmpty(txtName.Text) ||
                    String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrEmpty(DtpDate.Value.ToString()) ||
                    String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(cmbBatch.Text.ToString()) || 
                    String.IsNullOrEmpty(Picbox.ToString()))
                {
                    
                    MessageBox.Show("Fields Can't Be Empty.", "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (16 >DateTime.Today.Year - DtpDate.Value.Year || DateTime.Today.Year - DtpDate.Value.Year > 100 )
                {
                    MessageBox.Show("Student age must be between 16 - 100", "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
                else

                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    SqlCommand cmd = new SqlCommand("insert into StudentInfo values('" + txtSID.Text + "', '" + txtName.Text + "','" + DtpDate.Value.ToString() + "','" + txtAddress.Text + "', '" + txtPhone.Text + "','" + txtEmail.Text + "', '" + cmbBatch.Text.ToString() + "',@img);", sqlCon);
                    cmd.Parameters.Add(new SqlParameter("@img", img));
                    int temp = cmd.ExecuteNonQuery();

                    if (temp > 0)
                    {
                        MessageBox.Show("User created", "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SqlCommand cmd2 = new SqlCommand("insert into AssignmentInfo (SID,Batch,Fundamentals_Of_Networking,Fundamentals_Of_IT,Project_Management,Entroduction_To_Ecommerce,Fundamentals_Of_Programming,Web_Development,Advance_Programming,Business_Analytics,Final_Project) values ('" + txtSID.Text + "', '" + cmbBatch.Text.ToString() + "','" + "Not Submitted" + "','" + "Not Submitted" + "','" + "Not Submitted" + "','" + "Not Submitted" + "','" + "Not Submitted" + "','" + "Not Submitted" + "','" + "Not Submitted" + "','" + "Not Submitted" + "','" + "Not Submitted" + "');", sqlCon);
                        int temp1 = cmd2.ExecuteNonQuery();
                        SqlCommand cmd3 = new SqlCommand("insert into ResultsInfo (SID,Batch,Fundamentals_Of_Networking,Fundamentals_Of_IT,Project_Management,Entroduction_To_Ecommerce,Fundamentals_Of_Programming,Web_Development,Advance_Programming,Business_Analytics,Final_Project) values ('" + txtSID.Text + "', '" + cmbBatch.Text.ToString() + "','" + "Not Released" + "','" + "Not Released" + "','" + "Not Released" + "','" + "Not Released" + "','" + "Not Released" + "','" + "Not Released" + "','" + "Not Released" + "','" + "Not Released" + "','" + "Not Released" + "');", sqlCon);
                        int temp2 = cmd3.ExecuteNonQuery();
                        SqlCommand cmd4 = new SqlCommand("Update BatchInfo set  StudentCount = StudentCount + 1  where BatchID='" + cmbBatch.Text.ToString() + "'", sqlCon);
                        int numberOfRecords = cmd4.ExecuteNonQuery();
                        if (temp1 > 0)
                        {
                          
                        }
                        else
                        {
                            MessageBox.Show("Error Occured Creating Assignment Data", "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (temp2 > 0)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Error Occured Creating Results Data", "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (numberOfRecords > 0)
                        {
                           
                        }
                        else
                        {
                            MessageBox.Show("Error Occured Updating Batch Data", "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {

                        MessageBox.Show("Failed to create user", "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show("Error inserting data.Upload User Picture" , "Add Student Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            { OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
                dlg.Title = "Select Student Picture";
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    Picbox.ImageLocation = imgLoc;
                 }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Loading Picture" + ex, "Add Student Info Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddStudentInfo_Load(object sender, EventArgs e)
        {
            try
            {

                SqlCommand cmd = new SqlCommand
                    ("Select distinct BatchID from BatchInfo", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds, "BatchInfo");

                cmbBatch.DataSource = ds;
                cmbBatch.DisplayMember = "BatchInfo.BatchID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex, "Add Student Info Form",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            Cordinator obj = new Cordinator();
            obj.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchUser.Text = null;
            txtSID.Text = null;
            txtName.Text = null;
            txtAddress.Text = null;
            txtPhone.Text = null;
            txtEmail.Text = null;
            cmbBatch.SelectedItem = null;
            Picbox.Image = null;

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
