using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetinYazarBelirleme.Veritipi
{
    internal class HeapAgac
    {
        private static int heapBoyutu;

        private static void HeapOlustur(BagliListe dizi)
        {
            heapBoyutu = dizi.Count - 1;
            for (int i = heapBoyutu / 2; i >= 0; i--)
            {
                Heapify(dizi, i);
            }
        }

        private static void Takas(BagliListe dizi, int x, int y)//function to swap elements
        {
            BasitKelime gecici = (BasitKelime) dizi[x];
            dizi[x] = dizi[y];
            dizi[y] = gecici;
        }
        private static void Heapify(BagliListe dizi, int indis)
        {
            int sol = 2 * indis;
            int sag = 2 * indis + 1;
            int enBuyuk = indis;

            if (sol <= heapBoyutu && ((BasitKelime)dizi[sol]).Sayi > ((BasitKelime)dizi[indis]).Sayi)
            {
                enBuyuk = sol;
            }

            if (sag <= heapBoyutu && ((BasitKelime)dizi[sag]).Sayi > ((BasitKelime)dizi[enBuyuk]).Sayi)
            {
                enBuyuk = sag;
            }

            if (enBuyuk != indis)
            {
                Takas(dizi, indis, enBuyuk);
                Heapify(dizi, enBuyuk);
            }
        }
        public static void Sirala(BagliListe dizi)
        {
            HeapOlustur(dizi);
            for (int i = dizi.Count - 1; i >= 0; i--)
            {
                Takas(dizi, 0, i);
                heapBoyutu--;
                Heapify(dizi, 0);
            }
        }
        private string ToString(BagliListe dizi)
        {
            string str = "";
            for (int i = 0; i < dizi.Count; i++)
            { str += dizi[i].ToString() + "\r\n"; }
            return str;
        }
    }
}

