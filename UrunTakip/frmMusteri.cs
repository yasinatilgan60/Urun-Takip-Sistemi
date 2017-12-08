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
    public partial class frmMusteri : Form
    {
        public frmMusteri()
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlDataAdapter data = new SqlDataAdapter();
                DataTable dtable = new DataTable();
                SqlCommand kom = new SqlCommand();
                if (Convert.ToBoolean(con.State) == false)
                {

                    kom.Connection = con;
                    kom.CommandText = "select m.musteriAd,m.musteriSoyad,m.musteriTel,f.firmaAd from musteriler m inner join firma f on f.firmaId = m.firmaId where musteriAd='"+txtAd.Text+"' and musteriSoyad='"+txtSoyad.Text+"'";
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                string sorgu = "insert into musteriler(musteriAd,musteriSoyad,firmaId,musteriTel) values(@ad,@soyad,@ıd,@tel)";
                SqlCommand komut = new SqlCommand(sorgu,con);
                komut.Parameters.Add("@ad",SqlDbType.VarChar).Value=txtMusteriAd.Text;
                komut.Parameters.Add("@soyad", SqlDbType.VarChar).Value = txtMusteriSoyad.Text;
                komut.Parameters.Add("@ıd", SqlDbType.VarChar).Value = txtId.Text;
                komut.Parameters.Add("@tel", SqlDbType.VarChar).Value = txtMusteriTelefon.Text;
                komut.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Müşteri Ekleme İşlemi Gerçekleşti...");
            }
            catch (SqlException ex)
            {

                string hata = ex.Message;
            }
        }
    }
}
