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
    public partial class frmIstatistik : Form
    {
        public frmIstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DOGU;Initial Catalog=PersonelVeritabani;Integrated Security=True");
        private void frmIstatistik_Load(object sender, EventArgs e)
        {
            ///Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1= new SqlCommand("Select Count(*) from Tbl_Personel",baglanti);
            SqlDataReader dr1=komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();
            ///Evli Personel Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) from Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvli.Text = dr2[0].ToString();
            }
            baglanti.Close();
            ///Bekar Personel Sayısı 
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) from Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekar.Text = dr3[0].ToString();
            }
            baglanti.Close();
            ///Sehir sayisi
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(PerSehir)) from Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehir.Text = dr4[0].ToString();
            }
            baglanti.Close();
            ///Toplam Maas
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();
            ///Ortalama Maas
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();

        }
    }
}
