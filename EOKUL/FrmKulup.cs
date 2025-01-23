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

namespace EOKUL
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-25IM5T3;Initial Catalog=BonusOkul;Integrated Security=True");

        public void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_KULUPLER", baglanti);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKulupListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKulupEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("INSERT INTO TBL_KULUPLER (KULUPAD) VALUES (@P1)",baglanti);

            komut.Parameters.AddWithValue("@P1",TxtKulupAd.Text);

            komut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Kulüp Listeye Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Listele();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightCoral;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnKulupSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("DELETE FROM TBL_KULUPLER WHERE KULUPID=@P1", baglanti);

            komut.Parameters.AddWithValue("@P1", TxtKulupId.Text);

            komut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Kulüp Listeden Başarıyla Kaldırıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Listele();
        }

        private void BtnKulupGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("UPDATE TBL_KULUPLER SET KULUPAD=@P1 WHERE KULUPID=@P2", baglanti);

            komut.Parameters.AddWithValue("@P1", TxtKulupAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtKulupId.Text);

            komut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Kulüp Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Listele();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.LightGreen;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Transparent;
        }
    }
}