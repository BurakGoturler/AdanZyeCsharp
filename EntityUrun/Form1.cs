using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityUrun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBL_KATEGORI.ToList();

            dataGridView1.DataSource = kategoriler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TBL_KATEGORI t = new TBL_KATEGORI();

            t.KATEGORIAD = textBox2.Text;

            db.TBL_KATEGORI.Add(t);

            db.SaveChanges();

            MessageBox.Show("Kategori Başarıyla Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);

            var ktg = db.TBL_KATEGORI.Find(x);

            db.TBL_KATEGORI.Remove(ktg);

            db.SaveChanges();

            MessageBox.Show("Kategori Başarıyla Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);

            var ktg = db.TBL_KATEGORI.Find(x);

            ktg.KATEGORIAD = textBox2.Text;

            db.SaveChanges();

            MessageBox.Show("Kategori Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}