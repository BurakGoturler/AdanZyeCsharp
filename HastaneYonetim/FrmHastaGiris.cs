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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            Form1 frmGiris = new Form1();
            frmGiris.Show();
            this.Hide();
        }

        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit frmHastaKayit = new FrmHastaKayit();
            frmHastaKayit.Show();
        }

        private void BtnHastaGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                FrmHastaDetay frmHastaDetay = new FrmHastaDetay();
                frmHastaDetay.tc = MskTC.Text;
                frmHastaDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi Girişi! Lütfen Tekrar Deneyiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bgl.baglanti().Close();
        }
    }
}