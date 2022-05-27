namespace MetinYazarBelirleme.Veritipi
{
    /// <summary>
    /// Kelimenin kaçıncı cümlede ve o cümlede kaçıncı kelime olduğu bilgisini tutacak sınıf
    /// </summary>
    public class Konum
    {
        #region Alanlar
        private int cumle;
        private int sira;
        #endregion
        #region Özellikler
        /// <summary>
        /// Kelimenin kaçıncı cümlede olduğu
        /// </summary>
        public int Cumle
        {
            get { return cumle; }
            set { cumle = value; }
        }
        /// <summary>
        /// Kelimenin cümlede kaçıncı kelime olduğu
        /// </summary>
        public int Sira
        {
            get { return sira; }
            set { sira = value; }
        }
        #endregion
        #region Kurucu
        /// <summary>
        /// Yeni bir konum bilgisi oluşturucu
        /// </summary>
        /// <param name="c">Eserde kaçıncı cümle olduğu</param>
        /// <param name="s">Cümlede kaçıncı kelime olduğu</param>
        public Konum(int c, int s)
        {
            Cumle = c;
            Sira= s;    
        }
        #endregion
        #region Metodlar
        public override string ToString()
        {
            return "("+Cumle+", "+Sira+")";
        }
        #endregion
    }
}
