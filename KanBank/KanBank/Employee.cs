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

namespace KanBank
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            populate();
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\firas\OneDrive\Desktop\KB proje\KanBankDb.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False");


        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the Employee to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from EmployeeTbl where EmpNum=" + Key + ";";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Başarıyla Silindi");
                    con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Reset()
        {
            EmpNameTb.Text = "";
            EmpPassTb.Text = "";
            Key = 0;
        }
        private void populate()
        {
            con.Open();
            string Query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpPassTb.Text == "")
            {
                MessageBox.Show("Eksik bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into EmployeeTbl Values('"
                        + EmpNameTb.Text
                        + "','"
                        + EmpPassTb.Text
                        + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Başarıyla Kaydedildi");
                    con.Close();
                    Reset();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpPassTb.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
     

            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmpDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "Update EmployeeTbl set EmpId='" + EmpNameTb.Text + "',EmpPass=" + EmpPassTb.Text + " where EmpNum =" + Key + ";";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Çalışan Başarıyla Düzenlendi");
                    con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
