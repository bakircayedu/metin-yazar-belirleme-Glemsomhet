using MetinYazarBelirleme.Veritipi;
using System;
// using System.Collections;
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
    public partial class HashTabloFormu : Form
    {
        public Hashtable hashTablo;
        public HashTabloFormu()
        {
            InitializeComponent();
        }

        private void HashTabloFormu_Load(object sender, EventArgs e)
        {
            lstKelimeler.Items.Clear();
            string text = "";

            for(int i=0; i < hashTablo.Count; i++)
            {
                lstKelimeler.Items.Add(
                    hashTablo.keys[i].ToString()+" - "+
                    hashTablo.values[i].ToString()
                    );
            }

            //foreach (KeyValuePair<string, int> oge in hashTablo)
            //{
            //    lstKelimeler.Items.Add(oge.Key + " : " + oge.Value);
            //}
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string kelime = txtKelime.Text.ToLower();
            if (hashTablo.ContainsKey(kelime))
                txtTekrar.Text = hashTablo[kelime].ToString();
            else
                txtTekrar.Text = "Kelime buunamadı.";
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
