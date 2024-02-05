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
    public partial class ManageBatchInfo : Form
    {
        SqlConnection sqlCon;
        public ManageBatchInfo()
        {
            try
            {
                DBConnectionClass obj = new DBConnectionClass();
                sqlCon = obj.getConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "Add Batch Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            InitializeComponent();
        }

        private void ManageBatchInfo_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select BatchID from  BatchInfo", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                string id = "";

                while (dr.Read())
                {
                    id = dr[0].ToString();
                }
                string idString = id.Substring(4);

                int CTR = Int32.Parse(idString);
                if (CTR >= 1 && CTR < 9)
                {
                    CTR = CTR + 1;
                    txtBatchId.Text = "HDIT00" + CTR;
                }
                else if (CTR >= 10 && CTR < 99)
                {
                    CTR = CTR + 1;
                    txtBatchId.Text = "HDIT0" + CTR;
                }
                else if (CTR > 99)
                {
                    CTR = CTR + 1;
                    txtBatchId.Text = "HDIT" + CTR;
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("error" + e1, "Add Batch Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {

                SqlCommand cmd3 = new SqlCommand
                    ("Select distinct BatchID from BatchInfo", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                DataSet ds = new DataSet();

                da.Fill(ds, "BatchInfo");

                cmbBatch.DataSource = ds;
                cmbBatch.DisplayMember = "BatchInfo.BatchID";
              //  cmbBatch.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex, "View Batch Form",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmbBatch.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtBatchId.Text) || String.IsNullOrEmpty(txtSCount.Text))
                {
                    MessageBox.Show("Fields Can't Be Empty.", "Add Batch Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else

                {
                    SqlCommand cmd2 = new SqlCommand("insert into BatchInfo values('" + txtBatchId.Text + "', '" + txtSCount.Text + "');", sqlCon);
                    int temp = cmd2.ExecuteNonQuery();

                    if (temp > 0)
                    {
                        MessageBox.Show("Batch Details Saved", "Add Batch Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to create user", "Add Batch Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show("Error inserting data" + ex, "Add Batch Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBatchId.Text = "";
            txtSCount.Text = "";
            try
            {
                SqlCommand cmd5 = new SqlCommand("Select BatchID from  BatchInfo", sqlCon);
                SqlDataReader dr = cmd5.ExecuteReader();
                string id = "";

                while (dr.Read())
                {
                    id = dr[0].ToString();
                }
                string idString = id.Substring(4);

                int CTR = Int32.Parse(idString);
                if (CTR >= 1 && CTR < 9)
                {
                    CTR = CTR + 1;
                    txtBatchId.Text = "HDIT00" + CTR;
                }
                else if (CTR >= 10 && CTR < 99)
                {
                    CTR = CTR + 1;
                    txtBatchId.Text = "HDIT0" + CTR;
                }
                else if (CTR > 99)
                {
                    CTR = CTR + 1;
                    txtBatchId.Text = "HDIT" + CTR;
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("error" + e1, "Add Batch Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                SqlCommand SearchSudent = new SqlCommand
        ("select SID,Name,Address,Phone from StudentInfo where Batch = '" + cmbBatch.Text.ToString() + "'", sqlCon);

                SqlDataAdapter da = new SqlDataAdapter(SearchSudent);
                DataSet ds = new DataSet();
                da.Fill(ds, "StudentInfo");

                dgStudInfo.DataSource = ds;
                dgStudInfo.DataMember = "StudentInfo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("error selecting student " +ex, "View Batch Info Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Cordinator obj = new Cordinator();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
        
    