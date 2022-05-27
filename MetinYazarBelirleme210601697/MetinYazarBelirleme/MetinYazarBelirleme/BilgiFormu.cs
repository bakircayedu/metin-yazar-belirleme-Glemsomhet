using MetinYazarBelirleme.Veritipi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetinYazarBelirleme
{
    public partial class BilgiFormu : Form
    {
        // Cümlelerdeki kelime sayıları
        public int[] kelimeSayilari;

        // Cümleler
        public BagliListe cumleler;
        public BilgiFormu()
        {
            InitializeComponent();
        }

        private void BilgiFormu_Load(object sender, EventArgs e)
        {
            txtToplamCumle.Text = cumleler.Count.ToString();
            int toplamKelime = kelimeSayilari.Sum();
            txtToplamKelime.Text = toplamKelime.ToString();
            txtOrtalama.Text = ((double)toplamKelime / cumleler.Count).ToString();

            lstCumleler.Items.Clear();

            for(int i=0; i<cumleler.Count; i++)
            {
                lstCumleler.Items.Add(""+ i+" - "+ kelimeSayilari[i]+ " : "+cumleler[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
