using MetinYazarBelirleme.Veritipi;
using System;
// using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MetinYazarBelirleme
{
    public partial class Form1 : Form
    { 
        // Bütün cümleler
        string[] satirlar;

        // Kelime sınıfından nesnelerin tutulacağı yığıt (Stack) tanımla.
        Yigit<Kelime> kelimeYigiti;

        // Kelime ve sayısını tutacak dizi tanımla.
        BasitKelime[] kelimeSayilari;
        Yigit<BasitKelime> basitKelimeSayilari;

        // Cümlelerdeki kelime sayıları
        int[] kelimeler;

        // Kelime ağacı
        BagliListe kelimeAgaci;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dosya bilgilerini derler.
        /// </summary>
        /// <param name="dosya">Dosyann yolu</param>
        /// <returns>Dosya bilgileri metni</returns>
        private string DosyaBilgileri(string dosya)
        {
            string str = "";
            str += "Dosya özellikleri: "+File.GetAttributes(dosya) + "\r\n";
            str+="Oluşturulma tarih ve zamanı: "+File.GetCreationTime(dosya)+"\r\n";
            str += "Oluşturulma tarih ve zamanı UTC: " + File.GetCreationTimeUtc(dosya) + "\r\n";
            str+="Son erişme tarih ve zamanı: "+File.GetLastAccessTime(dosya)+"\r\n";
            str+= "Son erişme tarih ve zamanı UTC: "+File.GetLastAccessTimeUtc(dosya)+"\r\n";
            str += "Son yazma tarih ve zamanı: " + File.GetLastWriteTime(dosya) + "\r\n";
            str += "Son yazma tarih ve zamanı UTC: " + File.GetLastWriteTimeUtc(dosya) + "\r\n";
            return str;
        }

        /// <summary>
        /// Metin Yükle düğmesi tıklandığında çalışacak  metod. 
        /// Dosya seçer, seçilen dosyanın yolunu metin kutusuna yazar.
        /// Dosya bilgilerini gösterir.
        /// Hash Tablo Oluştur düğmesini pasifleştirir.
        /// </summary>
        /// <param name="sender">Olayı tetikleyen nesne, burada btnMetinYukle düğmesi</param>
        /// <param name="e">Tıklanma olayı argümanları</param>
        private void btnMetinYukle_Click(object sender, EventArgs e)
        {
            // Aç ileti kutusu nesnesi oluştur.
            var ofd = new OpenFileDialog();

            // 1- Metin dosyalarını ve 2- Tüm dosyaları göster.
            ofd.Filter = "Metin dosyası|*.txt|Tüm dosyalar|*.*";

            // Varsayılan olarak TXT uzantılı dosyaları göster.
            ofd.FilterIndex = 0;

            // Sadece 1 dosya seçimine izin ver.
            ofd.Multiselect = false;

            // İleti kutusunun başlığı
            ofd.Title = "Metin Dosyası Aç";

            // Eğer ileti kutusu "Aç" düğmesine tıklanarak kapatıldıysa
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosya adını metin kutusuna yaz.
                txtDosyaYolu.Text = ofd.FileName;

                // Dosya bilgilerini ileti kutusunda göster.
                MessageBox.Show(DosyaBilgileri(txtDosyaYolu.Text), txtDosyaYolu.Text + " Bilgileri");

                // Hash Tablo Oluştur düğmesini pasifleştir.
                btnHash.Enabled=false;
            }


        }

        /// <summary>
        /// Dosya yolu metin kutusu içindeki metin değiştiğinde çalışacak metod.
        /// Eğer metin kutusunda dosya yolu varsa Stack'e Oku düğmesini etkinleştirir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDosyaYolu_TextChanged(object sender, EventArgs e)
        {
            if (txtDosyaYolu.Text != "")
                btnStackOku.Enabled = true;
            else btnStackOku.Enabled = false;
        }

        /// <summary>
        /// kelimeYigiti içindeki kelimeleri, 
        /// metinde kaç kez geçtiği, 
        /// hangi cümlede ve kaçıncı sırada olduğu bilgilerini liste kutusuna yazar.
        /// </summary>
        void KelimeleriListeKutusunaAt()
        {
            // Liste kutusu önceden doluysa başlat.
            lstKelimeler.Items.Clear();

            // İlerleme çubuğunu sıfırla.
            progressBar.Value = 0;
            kelimeSayilari = new BasitKelime[kelimeYigiti.Count];
            progressBar.Maximum = kelimeYigiti.Count;
            progressBar.Visible = true;

            // Liste öğelerinin açıklaması
            lstKelimeler.Items.Add("1 KELİME  Sayı [(Cümle Numarası, Cümledeki Sıra Numarası)]");
            lstKelimeler.Items.Add("2 --------------------------------------------------------");
            
            // kelimeYigiti içindeki her bir kelime için...
            for(int i=0;i<kelimeYigiti.Count;i++)   
            {
                // i. kelime bilgilerini listeye ekle.
                lstKelimeler.Items.Add(kelimeYigiti[i].ToString());

                // Detaylı i. kelime bilgilerinden
                // sadece kelime ve tekrar sayısını bilgilerini al ve
                // bunlardan basit kelime nesnesi oluştur.
                // Oluşturduğun nesneyi kelimeSayilari dizisinin i. elemanı olarak ata.
                kelimeSayilari[i] = new BasitKelime() {Kelime= kelimeYigiti[i].Metin,
                    Sayi= kelimeYigiti[i].Konumlar.Count
                };

                // İlerleme çubuğunu bir adım ilerlet.
                progressBar.PerformStep();
            }
            progressBar.Visible = false;
        }

        /// <summary>
        /// Stack'e Oku düğmesi tıklandığında çalıştırılacak metod.
        /// Metin kutusunda yolu yazılan dosyadan tüm satırları okur.
        /// Okuduğu satırları (cümleleri) bir yığıta atar.
        /// Detaylı kelime bilgisi için kelimeYigiti yığıtını oluşturur.
        /// Cümleleri kelimelere böler, kelimeYigiti yığıtına atar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStackOku_Click(object sender, EventArgs e)
        {
            // Dosyadan satır satır oku ve string dizisine aktar
            satirlar = File.ReadAllLines(txtDosyaYolu.Text, Encoding.UTF8);

            // Etikete cümle sayısını yaz.
            lblDosya.Text = "Cümle sayısı: " + satirlar.Length + "\r\n";

            int toplamKelime = 0;
            string kelime="", cumle="";
            
            // Cümleleri atacağımız yığıtı oluştur.
            Yigit<string> yigit = new Yigit<string>(satirlar.Length+1);
            
            // kelimeYigiti üye yığıtı oluştur.
            kelimeYigiti = new Yigit<Kelime>();
            
            // Cümlelerdeki kelime sayıları
            kelimeler = new int[satirlar.Length];

            int cumleNo = 0;

            // İlerleme çubuğunu sıfırla.
            progressBar.Value = 0;
            progressBar.Maximum=satirlar.Length;
            progressBar.Visible = true;
            
            // Her bir satır (cümle) için...
            foreach (string satir in satirlar)
            {

                // Cümlenin etrafındaki boşlukları temizle, tamamını küçük harfe dönüştür.
                cumle = satir.Trim().ToLower();

                // Temizlemiş cümleyi yığıta at.
                yigit.Push(cumle);

                // Cümleyi kelimelere ayır: Boşluk karakterine gör cümleyi böl,
                // Boşluklar arasındaki metinlerden (kelime) cumleninKelimeleri dizisini oluştur.
                string[] cumleninKelimeleri= cumle.Split(' ');

                kelimeler[cumleNo] = cumleninKelimeleri.Length;


                // Cümle numarasını 1 artır.
                cumleNo++;

                // Cümlenin her bir kelimesi için...
                for (int i=0;i<cumleninKelimeleri.Length;i++) 
                {
                    // Kolay kullanım için
                    kelime = cumleninKelimeleri[i];

                    // Kelime sınıfından bir nesne oluştur.
                    var klm = new Kelime(kelime);

                    // kelimenin uzunlu 0 karakter ise sonraki komutları atla
                    if (kelime.Length == 0) continue;


                    // Kelime sayısını 1 artır (etikete yazacağız).
                    toplamKelime++;

                    // Eğer bu kelime daha önceden yığıta eklenmemişse ...
                    if (!kelimeYigiti.UyeMi(klm))
                        kelimeYigiti.Push(klm); // ekle.
                    try
                    {
                        // Kelimenin yığıtta kaçıncı sırada oluğunu bul,
                        int ndx = kelimeYigiti.IndexOf(klm);

                        // o kelimenin konum bilgilerine ekleme yap.
                        kelimeYigiti[ndx].Konumlar.Push(new Konum(cumleNo, i + 1));
                    }
                    catch (Exception ex) // Yukarıdaki komutlar istisna oluşturursa
                    {
                        // Hatanın sebebini ileti kutusuyla bildir.
                        MessageBox.Show("Hata! " + kelime + "\r\n\r\n" + ex.Message);
                    }
                } // i. cümlenin kelimeleri için döngü sonu
                // İlerleme çubuğunu bir adım ilerlet.
                progressBar.PerformStep();
            } // i satır (cümle) için döngü sonu

            // İişlem bitti, ilerleme çubuğunu gizle.
            progressBar.Visible=false;

            // Bulduğumuz kelime sayısı bilgisini etikete ekle.
            lblDosya.Text += "Kelime sayısı: " + toplamKelime+"\r\n";

            // Formu tazele
            Refresh();

            // :)
            KelimeleriListeKutusunaAt();

            // düğmesini etkinleştir.
            btnHash.Enabled=true;

            btnBilgi.Enabled = true;
            btnAgac.Enabled = true;

        }

        /// <summary>
        /// Hash Tablo Oluştur düğmesi tıklandığında çalışacak metod.
        /// kelimeSayilari koleksiyonundan ikili ağaç oluşturur ve küçükten büyüğe sıralar.
        /// En fazla tekrar eden kelime başa gelsin diye ters çevirir.
        /// Liste kutusuna aktarır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHash_Click(object sender, EventArgs e)
        {
            Hashtable hashTablo = new Hashtable();

            foreach(BasitKelime basitKelime in kelimeSayilari)
            {
                hashTablo.Add(basitKelime.Kelime, basitKelime.Sayi);
            }
            
            HashTabloFormu hashTabloFormu = new HashTabloFormu();
            hashTabloFormu.hashTablo = hashTablo;
            hashTabloFormu.ShowDialog();
        }

        private void btnBilgi_Click(object sender, EventArgs e)
        {
            var bilgiFormu = new BilgiFormu();
            bilgiFormu.cumleler = new BagliListe();

            // İlerleme çubuğunu sıfırla.
            progressBar.Value = 0;
            progressBar.Maximum = satirlar.Length;
            progressBar.Visible = true;

            foreach (string cumle in satirlar)
            {
                bilgiFormu.cumleler.Add(cumle);
                progressBar.PerformStep();
            }

            progressBar.Visible = false;

            bilgiFormu.kelimeSayilari = kelimeler;
            bilgiFormu.ShowDialog();
        }

        private void btnAgac_Click(object sender, EventArgs e)
        {
            kelimeAgaci = new BagliListe();
            basitKelimeSayilari = new Yigit<BasitKelime>();

            // İlerleme çubuğunu sıfırla.
            progressBar.Value = 0;
            progressBar.Maximum = kelimeSayilari.Length;
            progressBar.Visible = true;

            foreach (BasitKelime kelime in kelimeSayilari) {
                basitKelimeSayilari.Push(kelime);
                progressBar.PerformStep();
            }

            // İlerleme çubuğunu sıfırla.
            progressBar.Value = 0;
            progressBar.Maximum = basitKelimeSayilari.Count;
            progressBar.Visible = true;

            while (basitKelimeSayilari.Count > 0)
            {
                kelimeAgaci.Add(basitKelimeSayilari.Pop());
                progressBar.PerformStep();
            }

            progressBar.Visible = false;
            btnKelimeler.Enabled = true;
        }

        private void btnKelimeler_Click(object sender, EventArgs e)
        {
            // kelimeSayilari boşsa ...
            if (kelimeAgaci is null || kelimeAgaci.Count <= 0)
            {
                // Prosedürü ileti kutusu ile kullanıcıya bildir.
                MessageBox.Show("1. Metin dosyasını okutun.\r\n2. Stack'e okutun.\r\n Sonra Hash Tablo oluşturun.");
            }

            // İkili ağaç oluştur ve küçükten büyüğe sırala
            HeapAgac.Sirala(kelimeAgaci);

            // Listeyi temizle.
            lstBasit.Items.Clear();

            // Listedeki her bir kelime ve tekrar sayısını liste kutusuna yaz.
            Node dugum = kelimeAgaci.Bas.SonrakiDugum;

            // İlerleme çubuğunu sıfırla.
            progressBar.Value = 0;
            progressBar.Maximum = kelimeAgaci.Count;
            progressBar.Visible = true;

            BasitKelime basitKelime = new BasitKelime();
            while(!(dugum.Veri is null))
            {
                basitKelime = dugum.Veri as BasitKelime;
                lstBasit.Items.Insert(0,basitKelime.ToString());
                dugum = dugum.SonrakiDugum;

                progressBar.PerformStep();
            }
            progressBar.Visible=false;
        }
    }
}
