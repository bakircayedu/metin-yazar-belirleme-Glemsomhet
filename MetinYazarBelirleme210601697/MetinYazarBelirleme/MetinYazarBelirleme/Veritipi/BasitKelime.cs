using System;

namespace MetinYazarBelirleme.Veritipi
{
    /// <summary>
    /// Kelime ve metinde kaç kez geçtiği bilgisini tutacak sınıf
    /// Heap sort için
    /// </summary>
    public class BasitKelime : IComparable
    {
        /// <summary>
        /// İşlenmiş, sadeleştirilmiş kelime 
        /// </summary>
        public string Kelime { get; set; }

        /// <summary>
        /// Kelimenin metinde kaç kez geçtiği bilgisi
        /// </summary>
        public int Sayi { get; set; }

        /// <summary>
        /// Bu nesne ile bu sınıftan türetilen başka nesneyi karşılaştırmak için
        /// </summary>
        /// <param name="obj">Karşılaştırılacak nesne</param>
        /// <returns><B><0</B>: bu nesne daha küçük, <B>0</B>: nesneler aynı, <B>>0</B>: Bu nesne daha büyük</returns>
        public int CompareTo(object obj)
        {
            return Sayi.CompareTo((obj as BasitKelime).Sayi);
        }
        public override string ToString()
        {
            return Kelime + ": " + Sayi;
        }
    }
}
