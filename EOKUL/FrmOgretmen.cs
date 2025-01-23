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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            Form1 AnaForm = new Form1();
            AnaForm.Show();
            this.Hide();
        }

        private void BtnKulupIslemler_Click(object sender, EventArgs e)
        {
            FrmKulup frmKulup = new FrmKulup();
            frmKulup.Show();
        }

        private void BtnDersIslemler_Click(object sender, EventArgs e)
        {
            FrmDersler frmDersler = new FrmDersler();
            frmDersler.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci frmOgrenci = new FrmOgrenci();
            frmOgrenci.Show();
        }

        private void BtnSinavNotlar_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar frmSinavNotlar = new FrmSinavNotlar();
            frmSinavNotlar.Show();
        }
    }
}