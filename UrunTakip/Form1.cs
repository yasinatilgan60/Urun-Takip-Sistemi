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

namespace UrunTakip
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source = ATILGAN; Initial Catalog = UrunTakip; Integrated Security = True");
        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select Kullanıcıadı,parola from kullanıcı where Kullanıcıadı='" + txtKullanıcı.Text + "' and parola='" + txtSifre.Text + "'", con);
                SqlDataReader oku;
                oku = cmd.ExecuteReader();
                int sayac = 0;
                while (oku.Read())
                {
                    sayac = +1;
                }
                if (sayac == 1)
                {
                    frmMenu menu = new frmMenu();
                    this.Hide();
                    menu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Yanlış kullanıcı adı veya şifre girdiniz");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Kullanici girişinde hata oluştu" + ex);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            //uygulamayı kapatmak için...
            if (MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
