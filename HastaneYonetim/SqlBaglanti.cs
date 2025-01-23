using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HastaneYonetim
{
    public class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-25IM5T3;Initial Catalog=HastaneProje;Integrated Security=True;");

            baglan.Open();

            return baglan;
        }
    }
}