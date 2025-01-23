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
    public partial class FrmRandevuListesi : Form
    {
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }

        SqlBaglanti bgl = new SqlBaglanti();

        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select RandevuBrans as Branş, RandevuDoktor as Doktor, HastaTC as 'Hasta TC', HastaSikayet as 'Hasta Şikayet', RandevuTarih as Tarih, RandevuSaat as Saat, RandevuDurum as Durum From Tbl_Randevular", bgl.baglanti());

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        public int secilen;
    }
}