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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            // Doktorları datagride aktarma
            DataTable dt1 = new DataTable();

            //SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Doktorlar", bgl.baglanti());

            SqlDataAdapter da1 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Doktor', DoktorBrans as Branş, DoktorTc as TC, DoktorSifre as Şifre From Tbl_Doktorlar", bgl.baglanti());
            

            da1.Fill(dt1);

            dataGridView1.DataSource = dt1;

            // Branşları combobox'a aktarma
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());

            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }

            bgl.baglanti().Close();
        }

        private void BtnDoktorEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Tbl_Doktorlar (DoktorAd, DoktorSoyad, DoktorBrans, DoktorTC, DoktorSifre) Values (@d1, @d2, @d3, @d4, @d5)", bgl.baglanti());

            komut.Parameters.AddWithValue("@d1", TxtAd.Text);
            komut.Parameters.AddWithValue("@d2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@d3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@d4", MskTC.Text);
            komut.Parameters.AddWithValue("@d5", TxtSifre.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Doktor Kaydı Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void BtnDoktorSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_Doktorlar Where DoktorTC=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", MskTC.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Doktor Kaydı Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDoktorGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1, DoktorSoyad=@d2, DoktorBrans=@d3, DoktorSifre=@d5 Where DoktorTC=@d4", bgl.baglanti());

            komut.Parameters.AddWithValue("@d1", TxtAd.Text);
            komut.Parameters.AddWithValue("@d2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@d3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@d4", MskTC.Text);
            komut.Parameters.AddWithValue("@d5", TxtSifre.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Doktor Kaydı Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}