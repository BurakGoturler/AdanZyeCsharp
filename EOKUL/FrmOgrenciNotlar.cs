﻿using System;
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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-25IM5T3;Initial Catalog=BonusOkul;Integrated Security=True");

        public string numara;

        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM TBL_NOTLAR INNER JOIN TBL_DERSLER ON TBL_NOTLAR.DERSID = TBL_DERSLER.DERSID WHERE OGRID = @p1",baglanti);

            komut.Parameters.AddWithValue("@p1", numara);

            SqlDataAdapter da = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}