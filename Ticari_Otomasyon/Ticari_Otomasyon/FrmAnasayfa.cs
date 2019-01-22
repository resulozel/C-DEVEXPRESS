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
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Urunad, Sum(Adet) as 'Adet' From TBL_URUNLER group by UrunAd having sum(adet) <= 20 order by Sum(adet)", bgl.baglanti());
            da.Fill(dt);
            GridKontrolStoklar.DataSource = dt;
        }

      /* void ajanda()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_NOTLAR",bgl.baglanti());
            da.Fill(dt);
           // gridKontrolAjanda.DataSource = dt;
        }*/
       /* void fihrist()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,Telefon1 From TBL_FIRMALAR",bgl.baglanti());
            da.Fill(dt);
            GridKontrolFihrist.DataSource = dt;
            
        }*/
    /*void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("http://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name=="title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }

            }


        }*/

    
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {

            stoklar();
            //fihrist();
           // ajanda();
            webBrowser1.Navigate("http://www.tcmb.gov.tr/kurlar/today.xml");
           // haberler();
          

        }

        private void gridView5_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView5.GetDataRow(gridView5.FocusedRowHandle);
           
        }
    }
}
