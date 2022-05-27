/*
 * Kelimeleri ikili ağaca atayıp, heap sort ile sıralama
 */

namespace MetinYazarBelirleme.Veritipi
{
    /// <summary>
    /// İkili ağaç oluşturam ve dizi elemanlarını heap sort ile sıralamak için
    /// </summary>
    public class Heap
    {
        private static int heapBoyutu;

        private static void HeapOlustur(BasitKelime[] dizi)
        {
            heapBoyutu = dizi.Length - 1;
            for (int i = heapBoyutu / 2; i >= 0; i--)
            {
                Heapify(dizi, i);
            }
        }

        private static void Takas(BasitKelime[] dizi, int x, int y)//function to swap elements
        {
            BasitKelime gecici = dizi[x];
            dizi[x] = dizi[y];
            dizi[y] = gecici;
        }
        private static void Heapify(BasitKelime[] dizi, int indis)
        {
            int sol = 2 * indis;
            int sag = 2 * indis + 1;
            int enBuyuk = indis;

            if (sol <= heapBoyutu && dizi[sol].Sayi > dizi[indis].Sayi)
            {
                enBuyuk = sol;
            }

            if (sag <= heapBoyutu && dizi[sag].Sayi > dizi[enBuyuk].Sayi)
            {
                enBuyuk = sag;
            }

            if (enBuyuk != indis)
            {
                Takas(dizi, indis, enBuyuk);
                Heapify(dizi, enBuyuk);
            }
        }
        public static void Sirala(BasitKelime[] dizi)
        {
            HeapOlustur(dizi);
            for (int i = dizi.Length - 1; i >= 0; i--)
            {
                Takas(dizi, 0, i);
                heapBoyutu--;
                Heapify(dizi, 0);
            }
        }
        private string ToString(BasitKelime[] dizi)
        {
            string str = "";
            for (int i = 0; i < dizi.Length; i++)
            { str += dizi[i].ToString() + "\r\n"; }
            return str;
        }
    }
}
