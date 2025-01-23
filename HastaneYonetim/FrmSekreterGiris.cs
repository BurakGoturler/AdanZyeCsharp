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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
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

        private void BtnSekreterGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                FrmSekreterDetay frmSekreterDetay = new FrmSekreterDetay();
                frmSekreterDetay.tc = MskTC.Text;
                frmSekreterDetay.Show();
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