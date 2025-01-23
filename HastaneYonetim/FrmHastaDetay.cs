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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string tc;

        SqlBaglanti bgl = new SqlBaglanti();

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;

            // Ad Soyad Çekme
            SqlCommand komut = new SqlCommand("Select HastaAd, HastaSoyad From Tbl_Hastalar Where HastaTC=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", LblTC.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            }

            bgl.baglanti().Close();

            // Randevu Geçmişi Listeleme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select RandevuBrans as Branş, RandevuDoktor as Doktor, HastaTC as 'Hasta TC', HastaSikayet as 'Hasta Şikayet', RandevuTarih as Tarih, RandevuSaat as Saat, RandevuDurum as Durum From Tbl_Randevular Where HastaTC=" + tc, bgl.baglanti());

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            // Branşları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());

            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }

            bgl.baglanti().Close();
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();

            SqlCommand komut3 = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", bgl.baglanti());

            komut3.Parameters.AddWithValue("@p1", CmbBrans.Text);

            SqlDataReader dr3 = komut3.ExecuteReader();

            while (dr3.Read())
            {
                CmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }

            bgl.baglanti().Close();
        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select RandevuID as ID, RandevuBrans as Branş, RandevuDoktor as Doktor, HastaTC as 'Hasta TC', HastaSikayet as 'Hasta Şikayet', RandevuTarih as Tarih, RandevuSaat as Saat, RandevuDurum as Durum From Tbl_Randevular Where RandevuBrans='" + CmbBrans.Text + "'" + "and RandevuDoktor='" + CmbDoktor.Text + "' and RandevuDurum=0", bgl.baglanti());

            da.Fill(dt);

            dataGridView2.DataSource = dt;
        }

        private void LnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaBilgiDuzenle frmHastaBilgiDuzenle = new FrmHastaBilgiDuzenle();
            frmHastaBilgiDuzenle.TCno = LblTC.Text;
            frmHastaBilgiDuzenle.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            TxtId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void BtnHastaRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Randevular set RandevuDurum=@p1, HastaTC=@p1, HastaSikayet=@p2 Where RandevuId=@p3", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", LblTC.Text);
            komut.Parameters.AddWithValue("@p2", RchSikayet.Text);
            komut.Parameters.AddWithValue("@p3", TxtId.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Randevu Başarıyla Oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}