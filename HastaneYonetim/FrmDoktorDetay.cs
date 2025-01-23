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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        public string TC;

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = TC;

            // Doktor Ad Soyad
            SqlCommand komut = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar Where DoktorTC=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", LblTC.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevular
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select RandevuBrans as Branş, RandevuDoktor as Doktor, HastaTC as 'Hasta TC', HastaSikayet as 'Hasta Şikayet', RandevuTarih as Tarih, RandevuSaat as Saat, RandevuDurum as Durum From Tbl_Randevular Where RandevuDoktor='" + LblAdSoyad.Text + "'", bgl.baglanti());

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle frmDoktorBilgiDuzenle = new FrmDoktorBilgiDuzenle();
            frmDoktorBilgiDuzenle.TC = LblTC.Text;
            frmDoktorBilgiDuzenle.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frmDuyurular = new FrmDuyurular();
            frmDuyurular.Show();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            RchSikayet.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }
    }
}