/*
 * Yığıt (Stack) sınıfı
 * Yığıt öğesi olarak Generic tip kullanır.
 * Büşra Melis Gülbe
 */

using System;
using System.Collections.Generic;

namespace MetinYazarBelirleme.Veritipi
{
    /// <summary>
    /// Yığıt sınıfı
    /// </summary>
    /// <typeparam name="T">Yığıt öğeleri tipi</typeparam>
    public class Yigit<T>
    {
        #region Üye Özellikler
        /// <summary>
        /// Yığıtın alabileceği öğe sayısı
        /// </summary>
        int kapasite;

        /// <summary>
        /// Generic tanımlanmış yığıt öğeleri dizisi
        /// </summary>
        List<T> yigit;

        /// <summary>
        /// En üstteki yığıt öğesinin indisi
        /// </summary>
        int ust;
        public int Count { get { return ust+1; } }
        #endregion
        #region Üye Metodlar
        /// <summary>
        /// Kurucu (constructor) metod
        /// </summary>
        /// <param name="UstSinir">Yığıtın kapasitesi; alabileceği azami öğe sayısı</param>
        public Yigit(int UstSinir)
        {
            kapasite = UstSinir;
            yigit = new List<T>();
            ust = -1;
        }

        /// <summary>
        /// Varsayılan kurucu
        /// </summary>
        public Yigit()
        {
            kapasite = int.MaxValue;
            yigit = new List<T>();
            ust = -1;
        }
        /// <summary>
        /// Yığıta öğe ekleme
        /// </summary>
        /// <param name="Oge">Yığıta eklenecek öüe</param>
        public void Push(T Oge)
        {
            //Taşma var mı? 
            if (ust == kapasite - 1)
                throw new StackOverflowException("Yığıta belirlediğinizden daha fazla öğe yüklediniz.");
            // Yığıta öğe ekle ve ust'ü bir artır
            ust++;
            yigit.Add(Oge);
        }

        /// <summary>
        /// Yığıttan öğe silme
        /// </summary>
        /// <returns>Silinen öğe</returns>
        public T Pop()
        {
            T SilinenOge;
            T gecici = default(T);
            //Taşma var mı? 
            if (ust >= 0)
            {
                // En üstteki öğeyi al, ust'ü bir azalt
                SilinenOge = yigit[ust];
                yigit.RemoveAt(ust--);
                return SilinenOge;
            }
            return gecici;
        }

        /// <summary>
        /// Yığıtta, en üstteki öğe
        /// </summary>
        /// <returns>Sıradaki öğe</returns>
        public T Peek()
        {
            //Öğe var mı?
            if (ust >= 0)
                return yigit[ust];
            return default(T);
        }

        /// <summary>
        /// Yığıttaki bir öğeyi silmeden görme
        /// </summary>
        /// <param name="konum">İstenen öğenin indisi</param>
        /// <returns><b>Konum</b> ile belirlenen sıradaki öğe</returns>
        public T Peek(int konum)
        {
            //Konum geçerli mi?
            if (konum < kapasite && konum >= 0)
                return yigit[konum];
            return default(T);
        }

        /// <summary>
        /// Yığıtaki tüm öğeleri bir diziye aktaran metod
        /// </summary>
        /// <returns>Öğe dizisi</returns>
        public T[] OgeleriGetir()
        {
            return yigit.ToArray();
        }

        /// <summary>
        /// Bir nesne acaba yığıtta var mı?
        /// </summary>
        /// <param name="nesne">Aranan değer</param>
        /// <returns><B>true</B>: nesne yığıtta bulunuyor, <B>false</B>: nesne yığıtta yok</returns>
        public bool UyeMi(T nesne)
        {
            return yigit.Contains(nesne);
        }

        /// <summary>
        /// Nesnenin yığıttaki indisini döndüren metod
        /// </summary>
        /// <param name="nesne">Aranan nesne</param>
        /// <returns>Nesnenin yığıttaki yeri</returns>
        public int IndexOf(T nesne)
        {
            return yigit.IndexOf(nesne);
        }

        /// <summary>
        /// Endeksleyici, indis ile yığıta erişmek için
        /// </summary>
        /// <param name="i">Öğenin yığıttaki sıra numarası</param>
        /// <returns>Yığıtta, <B>i</B>. sıradaki öğe</returns>
        public T this[int i]
        {
            get => yigit[i];
            set => yigit[i] = value;    
        }
        #endregion
    }
}
