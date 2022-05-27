/*
 * Detaylı Kelime Sınıfı
 */

using System;

namespace MetinYazarBelirleme.Veritipi
{
    /// <summary>
    /// Yığıtta kullanılmak üzere detalı kelime bilgileri için
    /// </summary>
    public class Kelime : IEquatable<Kelime>
    {
        /// <summary>
        /// Eklerinden arındırılmış kelime
        /// </summary>
        private string metin;

        public string Metin
        {
            get { return metin; }
            set
            {
                if (value.Length == 0) return; 
                string punc = "“”‘’\":',,;-";
                string mtn = value.Trim();
                if(Char.IsPunctuation(mtn[mtn.Length-1]))
                    mtn=mtn.Substring(0,mtn.Length-1);
                if(Char.IsPunctuation(mtn[0]))
                    mtn= mtn.Substring(1, mtn.Length-1);
                foreach(char c in punc)
                {
                    string[] kesimler = mtn.Split(c);
                    mtn = kesimler[0];
                }
                metin = mtn;
            }
        }
        /// <summary>
        /// Kurucu metod
        /// </summary>
        /// <param name="metin">İncelenecek kelime</param>
        public Kelime(string metin)
        {
            Metin = metin;
        }

        /// <summary>
        /// Eşitlik kontrolü için
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Kelime other)
        {
            return (metin == other.metin);
        }

        /// <summary>
        /// Kelienin hangi cümlede, kaçıncı kelime olduğu bilgisi/bilgileri
        /// </summary>
        public Yigit<Konum> Konumlar = new Yigit<Konum>();
        public override string ToString()
        {
           string str = metin+" "+Konumlar.Count+" [";
           for(int i=0; i < Konumlar.Count; i++)
           {
               str += "(" + Konumlar.Peek(i).Cumle + ", " + Konumlar.Peek(i).Sira + ") ";
           }
           str += "]";
           return str;
        }
    }
}
