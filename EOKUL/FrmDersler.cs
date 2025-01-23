using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOKUL
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.TBL_DERSLERTableAdapter ds = new DataSet1TableAdapters.TBL_DERSLERTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnDersListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnDersEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(TxtDersAd.Text);

            MessageBox.Show("Ders Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDersSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(TxtDersId.Text));

            MessageBox.Show("Ders Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDersGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(TxtDersAd.Text, byte.Parse(TxtDersId.Text));

            MessageBox.Show("Ders Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}