using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Personel_Kayit
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=APACHIE;Initial Catalog=Personel;Integrated Security=True");

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayisi
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select count(*) from tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamPersonelSayisi.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //Evli Personel Sayisi
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from tbl_Personel where Durum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvliPersonelSayisi.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Bekar Personel Sayisi
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from tbl_Personel where durum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekarPersonelSayisi.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Sehir Sayisi
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count (distinct (sehir)) from tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehirSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //Toplam Maas
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(maas) from tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Ortalama Maas
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(maas) from tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtalamaMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
