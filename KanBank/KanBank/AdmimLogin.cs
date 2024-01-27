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
    public partial class AdmimLogin : Form
    {
        public AdmimLogin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(AdminPassTb.Text== "")
            {
                MessageBox.Show("Admin Şifrası Giriniz");
            }
            else if(AdminPassTb.Text=="12345")
            {
                Employee emp = new Employee();
                emp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış şifra. Sistem Yöneticisiyle İletişime Geçin");
                AdminPassTb.Text = "";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
