using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Personel_Kayit
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=APACHIE;Initial Catalog=Personel;Integrated Security=True");

        void Temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            cbSehir.Text = "";
            mskMaas.Text = "";
            rbEvli.Checked = false;
            rbBekar.Checked = false;
            txtMeslek.Text = "";
            txtAd.Focus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelDataSet.tbl_Personel);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelDataSet.tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelDataSet.tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into tbl_Personel (Ad,Soyad,Sehir,Maas,Durum,Meslek) values(@ad,@soyad,@sehir,@maas,@durum,@meslek)", baglanti);
            cmd.Parameters.AddWithValue("@ad", txtAd.Text);
            cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@sehir", cbSehir.Text);
            cmd.Parameters.AddWithValue("@maas", mskMaas.Text);
            cmd.Parameters.AddWithValue("@durum", lblRadio.Text);
            cmd.Parameters.AddWithValue("@meslek", txtMeslek.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void rbEvli_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEvli.Checked==true)
            {
                lblRadio.Text = "True";
            }
        }

        private void rbBekar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBekar.Checked == true)
            {
                lblRadio.Text = "False";
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            lblRadio.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void lblRadio_TextChanged(object sender, EventArgs e)
        {
            if (lblRadio.Text=="True")
            {
                rbEvli.Checked = true;
            }
            if (lblRadio.Text == "False")
            {
                rbBekar.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("Delete from tbl_Personel where personelId=@id",baglanti);
            komutSil.Parameters.AddWithValue("@id", txtID.Text);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayit Silindi");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("update tbl_Personel set Ad=@ad,Soyad=@soyad,Sehir=@sehir,Maas=@maas,Durum=@durum,Meslek=@meslek where personelID=@id",baglanti);
            komutGuncelle.Parameters.AddWithValue("@ad",txtAd.Text);
            komutGuncelle.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@sehir",cbSehir.Text);
            komutGuncelle.Parameters.AddWithValue("@maas",mskMaas.Text);
            komutGuncelle.Parameters.AddWithValue("@durum", lblRadio.Text);
            komutGuncelle.Parameters.AddWithValue("@meslek", txtMeslek.Text);
            komutGuncelle.Parameters.AddWithValue("@id", txtID.Text);
            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgi Güncellendi");
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            FrmIstatistik frm = new FrmIstatistik();
            frm.Show();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            FrmRaporlar frp = new FrmRaporlar();
            frp.Show();
        }

        private void tblPersonelBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
