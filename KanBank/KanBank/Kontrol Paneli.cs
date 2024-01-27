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
    public partial class Kontrol_Paneli : Form
    {
        public Kontrol_Paneli()
        {
            InitializeComponent();
            GetData();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\firas\OneDrive\Desktop\KB proje\KanBankDb.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void GetData()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from DonorTbl", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BağışçıLbl.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from TransferTbl", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from EmployeeTbl", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            KullanıcıLbl.Text = dt2.Rows[0][0].ToString();


            SqlDataAdapter sda3 = new SqlDataAdapter("select Sum(BStock) from BloodTbl", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int BStock= Convert.ToInt32(dt3.Rows[0][0].ToString());
            Toplam.Text = "" + BStock;

            SqlDataAdapter sda4 = new SqlDataAdapter("select Bstock from BloodTbl where BGroup= '" + "A+" + "'", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            APlusSayiLbl.Text = dt4.Rows[0][0].ToString();
            double AplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / BStock) * 100;
            APlusProgress.Value =Convert.ToInt32 (AplusPercentage);

            SqlDataAdapter sda5 = new SqlDataAdapter("select Bstock from BloodTbl where BGroup= '" + "B+" + "'", con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            BPlusSayiLbl.Text = dt5.Rows[0][0].ToString();
            double BplusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / BStock) * 100;
            BPlusprogress.Value = Convert.ToInt32(BplusPercentage);

            SqlDataAdapter sda6 = new SqlDataAdapter("select Bstock from BloodTbl where BGroup= '" + "O+" + "'", con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            OPlusSayiLbl.Text = dt6.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / BStock) * 100;
            OPlusProgress.Value = Convert.ToInt32(OplusPercentage);


            SqlDataAdapter sda7 = new SqlDataAdapter("select Bstock from BloodTbl where BGroup= '" + "A-" + "'", con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            AminusSayiLbl.Text = dt7.Rows[0][0].ToString();
            double AminusPercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / BStock) * 100;
            AminusProgress.Value = Convert.ToInt32(AminusPercentage);

            SqlDataAdapter sda8 = new SqlDataAdapter("select Bstock from BloodTbl where BGroup= '" + "B-" + "'", con);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);
            BminusSayiLbl.Text = dt8.Rows[0][0].ToString();
            double BminusPercentage = (Convert.ToDouble(dt8.Rows[0][0].ToString()) / BStock) * 100;
            BminusProgress.Value = Convert.ToInt32(BminusPercentage);

            SqlDataAdapter sda9 = new SqlDataAdapter("select Bstock from BloodTbl where BGroup= '" + "O-" + "'", con);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            OminusSayiLbl.Text = dt9.Rows[0][0].ToString();
            double OminusPercentage = (Convert.ToDouble(dt9.Rows[0][0].ToString()) / BStock) * 100;
            OminusProgress.Value = Convert.ToInt32(OminusPercentage);

            SqlDataAdapter sda10 = new SqlDataAdapter("select Bstock from BloodTbl where BGroup= '" + "AB+" + "'", con);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            ABPlusSayiLbl.Text = dt10.Rows[0][0].ToString();
            double ABplusPercentage = (Convert.ToDouble(dt10.Rows[0][0].ToString()) / BStock) * 100;
            ABPlusProgress.Value = Convert.ToInt32(ABplusPercentage);

            SqlDataAdapter sda11 = new SqlDataAdapter("select Bstock from BloodTbl where BGroup= '" + "AB-" + "'", con);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            ABminusSayiLbl.Text = dt11.Rows[0][0].ToString();
            double ABminusPercentage = (Convert.ToDouble(dt11.Rows[0][0].ToString()) / BStock) * 100;
            ABminusProgress.Value = Convert.ToInt32(ABminusPercentage);

            con.Close();
        }
        private void Kontrol_Paneli_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Bağışçı Ob = new Bağışçı();
            Ob.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }
    }
}
