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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-25IM5T3;Initial Catalog=BonusOkul;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();

            baglanti.Open();

            SqlCommand komut = new SqlCommand("Select * From TBL_KULUPLER", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();

            da.Fill(dt);

            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = "KULUPID";

            comboBox1.DataSource = dt;

            baglanti.Close();
        }

        string c = "";

        private void BtnOgrenciEkle_Click(object sender, EventArgs e)
        {


            ds.OgrenciEkle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);

            MessageBox.Show("Öğrenci Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnOgrenciListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TxtOgrenciId.Text = comboBox1.SelectedValue.ToString();
        }

        private void BtnOgrenciSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtOgrenciId.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOgrenciId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrenciAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void BtnOgrenciGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c, int.Parse(TxtOgrenciId.Text));
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kadın";
            }
        }

        private void BtnOgrenciAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(TxtOgrenciAra.Text);
        }
    }
}