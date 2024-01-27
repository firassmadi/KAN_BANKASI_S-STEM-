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

namespace KanBank
{
    public partial class KanBağışı : Form
    {
        public KanBağışı()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\firas\OneDrive\Desktop\KB proje\KanBankDb.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void populate()
        {
            con.Open();
            string Query = "select * from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BağışçılaarDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void bloodStock()
        {
            con.Open();
            string Query = "select * from BloodTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Bağışçılar Ob = new Bağışçılar();
            Ob.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Hasta Ob = new Hasta();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hastalar Ob = new Hastalar();
            Ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Kanstoğu Ob = new Kanstoğu();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Kantransferi Ob = new Kantransferi();
            Ob.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Kontrol_Paneli Ob = new Kontrol_Paneli();
            Ob.Show();
            this.Hide();
        }

        private void DPhoneTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Bağış_yapmak_Load(object sender, EventArgs e)
        {

        }
        int oldstock;
        private void GetStock(string Bgroup)
        {
            //Helps to get actual stock of Blood based on particular Blood Group
            con.Open();
            string query = "select * from BloodTbl where BGroup= '" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt =new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());
            }
            con.Close();
        }
        private void BağışçılaarDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = BağışçılaarDGV.SelectedRows[0].Cells[1].Value.ToString();
            BGroupTbl.Text = BağışçılaarDGV.SelectedRows[0].Cells[6].Value.ToString();
            GetStock(BGroupTbl.Text);
        }
        private void reset()
        {
            DNameTb.Text = "";
            BGroupTbl.Text = "";
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(DNameTb.Text == "")
            {
                MessageBox.Show("Select A donor");
            }
            else
            {
                try
                {
                    int Stock = oldstock + 1;
                    string query = "Update BloodTbl set BStock=" + Stock +" where BGroup= '" + BGroupTbl.Text + "';";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation Successfull");
                    con.Close();
                    reset();
                    bloodStock();
                   
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Bağışçı Ob = new Bağışçı();
            Ob.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }

        private void BloodStockDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void DNameTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
