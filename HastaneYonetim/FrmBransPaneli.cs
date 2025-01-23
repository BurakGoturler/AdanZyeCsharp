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
    public partial class FrmBransPaneli : Form
    {
        public FrmBransPaneli()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();
        private void FrmBransPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select BransId as ID, BransAd as Branş From Tbl_Branslar", bgl.baglanti());

            da.Fill(dt);
            
            dataGridView1.DataSource = dt;
        }

        private void BtnBransEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Tbl_Branslar (BransAd) Values (@b1)",bgl.baglanti());

            komut.Parameters.AddWithValue("@b1", TxtBrans.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Branş Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtBrans.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnBransSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Tbl_Branslar Where BransId=@b1", bgl.baglanti());

            komut.Parameters.AddWithValue("@b1", TxtId.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Branş Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnBransGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Branslar set BransAd=@p1 Where BransId=@p2", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", TxtBrans.Text);
            komut.Parameters.AddWithValue("@p2", TxtId.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Branş Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}