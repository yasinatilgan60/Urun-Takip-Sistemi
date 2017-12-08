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
    public partial class frmPersonel : Form
    {
        public frmPersonel()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmGiris gi = new frmGiris();
            this.Hide();
            gi.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize eminmisiniz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        SqlConnection con = new SqlConnection("Data Source = ATILGAN; Initial Catalog = UrunTakip; Integrated Security = True");
        private void btnGorevlendir_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int sayi1, sayi2;
                sayi1 = Convert.ToInt32(txtUrunId.Text);
                sayi2 = Convert.ToInt32(txtFirmaId.Text);
                string sorgu = "exec UrunHareketEkleme "+sayi1+",'"+txtPerAd.Text+"','"+textPerSoyad.Text+"',"+sayi2;
                SqlCommand komut = new SqlCommand(sorgu, con);
                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Personel Görevlendirme İşlemi Tamamlandı.");
            }
            catch (SqlException ex)
            {
                 string hata = ex.Message;
            }
        }

        private void btnAramaYap_Click(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter data = new SqlDataAdapter();
                DataTable dtable = new DataTable();
                SqlCommand kom = new SqlCommand();
                if (Convert.ToBoolean(con.State) == false)
                {

                    kom.Connection = con;
                    kom.CommandText = "exec personelListele "+Convert.ToInt32(txtId.Text);
                    data.SelectCommand = kom;
                    data.Fill(dtable);
                    dataGridView1.DataSource = dtable;
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
        }
    }
}
