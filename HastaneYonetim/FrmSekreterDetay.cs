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

namespace HastaneYonetim
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        public string tc;

        SqlBaglanti bgl = new SqlBaglanti();

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;

            //Ad Soyad
            SqlCommand komut = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter Where SekreterTC=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", LblTC.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            // Branşları Datadgrid'e Aktarma
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select BransAd as Branş From Tbl_Branslar", bgl.baglanti());

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            // Doktorları Listeye Aktarma
            DataTable dt2 = new DataTable();

            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar' , DoktorBrans as Branş From Tbl_Doktorlar", bgl.baglanti());

            da2.Fill(dt2);

            dataGridView2.DataSource = dt2;

            // Branşları combobox'a Aktarma
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());

            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }

            bgl.baglanti().Close();
        }

        private void BtnRandevuKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("Insert into Tbl_Randevular (RandevuTarih, RandevuSaat, RandevuBrans, RandevuDoktor) Values (@r1, @r2, @r3, @r4)", bgl.baglanti());

            komutkaydet.Parameters.AddWithValue("@r1", MskTarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", MskSaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", CmbBrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", CmbDoktor.Text);

            komutkaydet.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Randevu Başarıyla Oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();

            SqlCommand komut = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1",CmbBrans.Text);

            SqlDataReader dr3 = komut.ExecuteReader();

            while (dr3.Read())
            {
                CmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }

            bgl.baglanti().Close();
        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Tbl_Duyurular (Duyuru) Values (@d1)", bgl.baglanti());

            komut.Parameters.AddWithValue("@d1", RchDuyuru.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Duyuru Başarıyla Oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli frmDoktorPaneli = new FrmDoktorPaneli();
            frmDoktorPaneli.Show();
        }

        private void BtnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBransPaneli frmBransPaneli = new FrmBransPaneli();
            frmBransPaneli.Show();
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frmRandevuListesi = new FrmRandevuListesi();
            frmRandevuListesi.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frmDuyurular = new FrmDuyurular();
            frmDuyurular.Show();
        }
    }
}