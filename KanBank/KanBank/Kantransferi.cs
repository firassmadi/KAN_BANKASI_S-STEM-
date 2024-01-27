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
    public partial class Kantransferi : Form
    {
        public Kantransferi()
        {
            InitializeComponent();
            fillHastaCb();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\firas\OneDrive\Desktop\KB proje\KanBankDb.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void fillHastaCb()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select HSayi from HastaTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HSayi", typeof(int));
            dt.Load(rdr);
            HastaIdCb.ValueMember = "HSayi";
            HastaIdCb.DataSource = dt;
            con.Close();
        }
        private void GetData()
        {
            //Helps to get the BloodGroup and Name of the Patient
            con.Open();
            string query = "select * from HastaTbl where HSayi= " + HastaIdCb.SelectedText.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                HAdiTb.Text = (dr["HAdi"].ToString());
                KanGurupu.Text = (dr["HKGurupu"].ToString());
            }
            con.Close();
        }
        int stock = 0;
        private void GetStock(string Bgroup)
        {
            //Helps to get actual stock of Blood based on particular Blood Group
            con.Open();
            string query = "select * from BloodTbl where BGroup= '" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stock = Convert.ToInt32(dr["BStock"].ToString());
            }
            con.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Kantransferi_Load(object sender, EventArgs e)
        {

        }

        private void HastaIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            GetStock(KanGurupu.Text);
            if (stock > 0)
            {
                TransferBtn.Visible = true;
                AvailableLbl.Text = "Mevcut Stok";
                AvailableLbl.Visible = true;
            }
            else
            {
                AvailableLbl.Text = "Stok Mevcut Değil";
                AvailableLbl.Visible = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Hasta Hs = new Hasta();
            Hs.Show(this);
            this.Hide();

        }
        private void Reset()
        {
            HAdiTb.Text = "";
           // HastaIdCb.SelectedIndex = -1;
            KanGurupu.Text = "";
            AvailableLbl.Visible = false;
            TransferBtn.Visible=false; 
        }
        private void updatestock()
        {
            int newstock = stock - 1;
            try
            {
                string query = "Update BloodTbl set BStock=" + newstock + " where BGroup='" + KanGurupu.Text + "';";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Hasta Başarıyla Düzenlendi");
                con.Close();
               
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void TransferBtn_Click(object sender, EventArgs e)
        {
            if (HAdiTb.Text == "")
            {
                MessageBox.Show("Eksik bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into TransferTbl Values('"
                        + HAdiTb.Text
                        + "','"
                        + KanGurupu.Text
                        + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Başarılı Transfer");
                    con.Close();
                    GetStock(KanGurupu.Text);
                    updatestock();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Kanstoğu Bstock= new Kanstoğu();
            Bstock.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Bağışçı Ob = new Bağışçı();
            Ob.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            KanBağışı Ob = new KanBağışı();
            Ob.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Bağışçılar Ob = new Bağışçılar();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hastalar Ob = new Hastalar();
            Ob.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Kontrol_Paneli Ob = new Kontrol_Paneli();
            Ob.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }
    }
}
