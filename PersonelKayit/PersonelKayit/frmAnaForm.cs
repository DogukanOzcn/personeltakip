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
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DOGU;Initial Catalog=PersonelVeritabani;Integrated Security=True");

        public void temizle()
        {
            txtID.Text = "";
            txtAD.Text = "";
            txtSoyad.Text = "";
            txtMeslek.Text = "";
            cmbSehir.Text = "";
            mskMaas.Text = "";
            radioButton1.Checked=false;
            radioButton2.Checked=false;
            txtAD.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
  
        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeritabaniDataSet.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAD.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4",mskMaas.Text);
            komut.Parameters.AddWithValue("@p5",txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text=="False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel Where PerId=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtID.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("KAYIT SİLİNDİ");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 where PerId=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1",txtAD.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cmbSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mskMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtID.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("PERSONEL BİLGİSİ GÜNCELLENDİ");
        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            frmIstatistik fr = new frmIstatistik();
            fr.Show();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            frmGrafikler frg = new frmGrafikler();
            frg.Show();
        }
    }
}
