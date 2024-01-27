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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\firas\OneDrive\Desktop\KB proje\KanBankDb.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void Reset()
        {
            HAdiTb.Text = "";
            HYasTb.Text = "";
            HCinCb.SelectedIndex = -1;
            HTelifonTb.Text = "";
            HKGurupuCb.SelectedIndex = -1;
            HAddressTb.Text = "";
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (HAdiTb.Text == "" || HTelifonTb.Text == "" || HYasTb.Text == "" || HCinCb.SelectedIndex == -1 || HKGurupuCb.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into HastaTbl Values('"
                        + HAdiTb.Text
                        + "','"
                        + HYasTb.Text
                        + "','"
                        + HTelifonTb.Text
                        + "','"
                        + HCinCb.SelectedItem.ToString()
                        + "','"
                        + HAddressTb.Text
                        + "','"
                        + HKGurupuCb.SelectedItem.ToString()
                        + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Kaydedildi");
                    con.Close();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }



        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Hasta_Load(object sender, EventArgs e)
        {

        }

        private void HAdiTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        Hastalar HG = new Hastalar();
            HG.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Kantransferi KT = new Kantransferi();
            KT.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Bağışçı Ob = new Bağışçı();
            Ob.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
            Kanstoğu Ob = new Kanstoğu();
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
