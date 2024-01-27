using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanBank
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Bağışçı Bağ = new Bağışçı();
            Bağ.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
             KanBağışı Bağış = new KanBağışı();
            Bağış.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Bağışçılar Ba =new Bağışçılar();
            Ba.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Hasta has = new Hasta();
            has.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Hastalar HL = new Hastalar();
            HL.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Kanstoğu KS = new Kanstoğu();
            KS.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Kantransferi KT = new Kantransferi();
            KT.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Kontrol_Paneli KP = new Kontrol_Paneli();
            KP.Show();
            this.Hide();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {

        }
    }
}
