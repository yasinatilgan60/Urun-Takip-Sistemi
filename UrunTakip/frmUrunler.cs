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
    public partial class frmUrunler : Form
    {
        public frmUrunler()
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

        private void btnGeri_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Hide();
            frm.Show();
        }

        SqlConnection con = new SqlConnection("Data Source = ATILGAN; Initial Catalog = UrunTakip; Integrated Security = True");
        private void btnKontrol_Click(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter data = new SqlDataAdapter();
                DataTable dtable = new DataTable();
                SqlDataReader read;
                int count = 0;
                if (Convert.ToBoolean(con.State) == false)
                {

                    con.Open();
                    SqlCommand kom = new SqlCommand();
                    kom.Connection = con;
                    kom.CommandText = "exec urunKontrol '"+txtUrunAdi.Text+"'";
                    read = kom.ExecuteReader();
                    while (read.Read())
                    {
                        count += 1;
                    }
                    if (count == 0)
                    {
                        MessageBox.Show("Ürün bulunamadı.");
                    }
                    read.Close();
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

        SqlConnection conn = new SqlConnection("Data Source = ATILGAN; Initial Catalog = UrunTakip; Integrated Security = True");
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {

                if (conn.State==ConnectionState.Closed)
                {
                    conn.Open();
                }
                //string sorgu = "exec urunGuncelle '@ad','@fiyat',@adet,'@lisans'";
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandText = "exec urunGuncelle '"+txtUrununAdi.Text+"','"+txtFiyat.Text+"',"+Convert.ToInt32(txtAdet.Text)+",'"+txtLisans.Text+"'";
                
                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ürün Güncelleme İşlemi Gerçekleştirildi...");



            }
            catch (SqlException ex)
            {

                MessageBox.Show("Ürün Güncelleme İşlemi Gerçekleştirilemedi.."+ex);
            }

        }
    }
}
