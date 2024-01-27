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
using Guna.UI2.WinForms;
using System.IO;

namespace KanBank
{
    public partial class Hastalar : Form
    {
        public Hastalar()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\firas\OneDrive\Desktop\KB proje\KanBankDb.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void populate()
        {
            Con.Open();
            string Query = "select * from HastaTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HastalarDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        int key = 0;

        private void HastalarDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HAdiTb.Text = HastalarDGV.SelectedRows[0].Cells[1].Value.ToString();
            HYasTb.Text = HastalarDGV.SelectedRows[0].Cells[2].Value.ToString();
            HTelifonTb.Text = HastalarDGV.SelectedRows[0].Cells[3].Value.ToString();
            HCinCb.SelectedItem = HastalarDGV.SelectedRows[0].Cells[4].Value.ToString();
            HAddresTb.Text = HastalarDGV.SelectedRows[0].Cells[5].Value.ToString();
            HKGurupuCb.SelectedItem = HastalarDGV.SelectedRows[0].Cells[6].Value.ToString();

            if(HAdiTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HastalarDGV.SelectedRows[0].Cells[0].Value.ToString());

            }

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Hastalar_Load(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            HAdiTb.Text = "";
            HYasTb.Text = "";
            HTelifonTb.Text = "";
            HCinCb.SelectedIndex = -1;
            HKGurupuCb.SelectedIndex = -1;
            HAddresTb.Text = "";
            key = 0;
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
        if (key ==0)
            {
                MessageBox.Show("Select the Patent to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from HastaTbl where HSayi=" + key + ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Silindi");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        //Hasta sayfaya gitmek için
        private void label3_Click(object sender, EventArgs e)
        {
        Hasta Has = new Hasta();
            Has.Show();
            this.Hide();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (HAdiTb.Text == "" || HTelifonTb.Text == "" || HYasTb.Text == "" || HCinCb.SelectedIndex == -1 || HKGurupuCb.SelectedIndex == -1 || HAddresTb.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "Update HastaTbl set Hadi='"+HAdiTb.Text+"',Hyas="+HYasTb.Text+",Htelifon="+HTelifonTb.Text+",Hcinsiyet='"+HCinCb.SelectedItem.ToString()+"',Haddress='"+HAddresTb.Text+"',Hkgurupu='"+HKGurupuCb.SelectedItem.ToString()+"' where HSayi="+key+"";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Düzenlendi");
                    Con.Close();
                    Reset();
                    populate();
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

        private void label9_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }
    }
}
