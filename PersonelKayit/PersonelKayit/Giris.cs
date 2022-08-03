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

namespace PersonelKayit
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DOGU;Initial Catalog=PersonelVeritabani;Integrated Security=True");
        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Admin where KullaniciAd=@p1 and Sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1", txtKullanici.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmAnaForm frm = new frmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("HATALI KULLANICI ADI VEYA ŞİFRE");
            }
            baglanti.Close();
        }
    }
}
