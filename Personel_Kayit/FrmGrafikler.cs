using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Personel_Kayit
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=APACHIE;Initial Catalog=Personel;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {           
            //Grafik 1

            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select Sehir, Count(*) from tbl_Personel group by Sehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //Grafik 2

            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select meslek,avg(maas) from tbl_personel group by Meslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
