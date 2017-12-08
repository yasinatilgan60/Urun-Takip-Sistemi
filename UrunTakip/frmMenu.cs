using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunTakip
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmGiris gi = new frmGiris();
            this.Hide();
            gi.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMusteri mus = new frmMusteri();
            mus.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPersonel per = new frmPersonel();
            per.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmUrunler urun = new frmUrunler();
            urun.Show();
            this.Hide();
        }
    }
}
