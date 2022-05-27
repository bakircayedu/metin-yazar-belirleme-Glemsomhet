/* 
 * Baðlý Liste (LinkedList) sýnýfý
 *  
 * Büþra Melis Gülbe
 * 
 */

using System;
using System.Collections;

namespace MetinYazarBelirleme.Veritipi
{
	[Serializable]
	public class BagliListe : IList, ICloneable
	{
		#region Üye Alanlar
		private Node	ilkDugum;
		private int		sayi;
		private int		degisiklik;
		#endregion

		#region Kurucular ( Constructors )
		/// <summary>
		/// Yeni boþ bir baðlý liste oluþturur.
		/// </summary>
		public BagliListe()
		{
			ilkDugum = new Node(null, null, null);

			ilkDugum.SonrakiDugum		= ilkDugum;
			ilkDugum.OncekiDugum	= ilkDugum;

			sayi = 0;
		}

		/// <summary>
		/// Baþka bir koleksiyondaki öðelerle yeni bir baðlý liste oluþturur.
		/// </summary>
		/// <param name="koleksiyon">The ICollection whose elements are copied to the new list.</param>
		public BagliListe(ICollection koleksiyon) : this()
		{
			TumunuEkle(koleksiyon);
		}
		#endregion

		#region Üye Özellikler
		/// <summary>
		/// Baðlý listedeki öðe sayýsýný getirir.
		/// </summary>
		public virtual int		Count			{get {return sayi;}}

		public Node Bas { get {return ilkDugum;} }
		public virtual bool		IsSynchronized	{get {return false;}}
		public virtual object	SyncRoot		{get {return this; }}		
		public virtual bool		IsFixedSize		{get {return false;}}
		public virtual bool		IsReadOnly		{get {return false;}}
		
		/// <summary>
		/// Endeksleyici
		/// </summary>
		/// <param name="index">Öðenin dizideki sýra numarasý</param>
		/// <returns></returns>
		public virtual object this[int index] 
		{
			get 
			{
				return FindNodeAt(index).Veri;
			} 
			
			set
			{
				FindNodeAt(index).Veri = value;
			}
		}
		#endregion
										 
		#region Üye Metodlar
		/// <summary>
		/// Listeye öðe ekler.
		/// </summary>
		/// <param name="value">eklenecek öðe</param>
		/// <returns>.Eklenen öðenin sýra numarasýný döndürür.</returns>
		public virtual int Add(object value)
		{
			Insert(sayi, value);
			
			return (sayi - 1);
		}

		/// <summary>
		/// Baþka bir koleksiyondan topluca öðeler ekler.
		/// </summary>
		/// <param name="collection">Eklenecek öðelerin olduðu kolaksiyon</param>
		public virtual void TumunuEkle(ICollection collection)
		{
			InsertAll(sayi, collection);
		}

		/// <summary>
		/// Tüm listeyi temizler. Bütün liste öðelerini siler.
		/// </summary>
		public virtual void Clear()
		{
			degisiklik++;

			ilkDugum.SonrakiDugum		= ilkDugum;
			ilkDugum.OncekiDugum	= ilkDugum;

			sayi = 0;
		}

		/// <summary>
		/// Listenin kopyasýný oluþturur.
		/// </summary>
		/// <returns>Konlanmýþ yeni bir liste döndürür.</returns>
		public virtual object Clone()
		{
			BagliListe	listClone = new BagliListe();
			
			for (Node node = ilkDugum.SonrakiDugum; node != ilkDugum; node = node.SonrakiDugum)
				listClone.Add(node.Veri);
			
			return listClone;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="derinKopya"></param>
		/// <returns></returns>
		/// <exception cref="SystemException"></exception>
		public virtual BagliListe Clone(bool derinKopya)
		{
			BagliListe listClone;

			if (derinKopya)
			{
				listClone = new BagliListe();

				object nesne;

				for (Node dugum = ilkDugum.SonrakiDugum; dugum != ilkDugum; dugum = dugum.SonrakiDugum)
				{
					nesne = dugum.Veri;

					if (nesne == null)
						listClone.Add(null);
					else if (nesne is ICloneable)
						listClone.Add(((ICloneable)nesne).Clone());
					else
						throw new SystemException("Listedeki [" + nesne.GetType() + 
												  "] nesne tipi ICloneable ile klonlanabilir deðildir. Derinlemesine klonlama yapýlamýyor.");
				}	
			}
			else
				listClone = (BagliListe)this.Clone();

			return listClone;
		}

		/// <summary>
		/// Listede öðenin olup olmadýðýna bakar.
		/// </summary>
		/// <param name="oge">Aranan deðer</param>
		/// <returns><B>true</B>: öðe listede var, <B>false</B>: öðe listede yok.</returns>
		public virtual bool Contains(object oge)
		{
			return (0 <= IndexOf(oge));
		}

		/// <summary>
		/// Baðlý listeyi bir diziye kopyalar.
		/// </summary>
		/// <param name="dizi">Hedef dizi</param>
		/// <param name="indis">Öðelerin dizi içinde kopyalanacaðý konum</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		public virtual void CopyTo(Array dizi, int indis)
		{	
			if (dizi != null)
			{	
				if (0 <= indis)
				{	
					if (dizi.Rank == 1)
					{	
						if (sayi <= (dizi.Length - indis))
						{
							if (indis < dizi.Length)
							{	
								for (int i = indis, j = 0;j < sayi; i++, j++)
									dizi.SetValue(FindNodeAt(j).Veri, i);
							}
							else
								throw new ArgumentException("index is equal to or greater than the length of array.", "index");
						}
						else
							throw new ArgumentException("The number of elements is greater than the available space from index in the destination array.", "array");
					}
					else
						throw new ArgumentException("Multidimensional array", "array");
				}
				else
					throw new ArgumentOutOfRangeException("index", indis, "less than zero");
			}
			else
				throw new ArgumentNullException("array");
		}

		/// <summary>
		/// Numaralandýrma
		/// </summary>
		/// <returns>IEnumerator uyumlu liste</returns>
		public virtual IEnumerator GetEnumerator()
		{
			return new LinkedListEnumerator(this);
		}

		/// <summary>
		/// Aranan öðenin listedeki yerini verir.
		/// </summary>
		/// <param name="oge">Aranan öðe</param>
		/// <returns>Öðenin sýra numarasý</returns>
		public virtual int IndexOf(object oge)
		{
			int indis = 0;

			if (oge == null) 
			{
				for (Node dugum = ilkDugum.SonrakiDugum; dugum != ilkDugum; dugum = dugum.SonrakiDugum)
				{
					if (dugum.Veri == null)
						break;

					indis++;
				}
			} 
			else 
			{
				for (Node dugum = ilkDugum.SonrakiDugum; dugum != ilkDugum; dugum = dugum.SonrakiDugum)
				{
					if (oge.Equals(dugum.Veri))
						break;

					indis++;
				}
			}

			if (sayi <= indis)
				indis = -1;

			return indis;
		}

		/// <summary>
		/// Baðlý listenin belirtilen konumuna öðe ekler.
		/// </summary>
		/// <param name="indis">Öðenin baðlý listede ekleneceði sýra numarasý</param>
		/// <param name="oge">Eklenecek öðe</param>
		public virtual void Insert(int indis, object oge)
		{
			Node dugum;

			if (indis == sayi)
				dugum = new Node(oge, ilkDugum, ilkDugum.OncekiDugum);
			else
			{
				Node gecici = FindNodeAt(indis);

				dugum = new Node(oge, gecici, gecici.OncekiDugum);
			}

			dugum.OncekiDugum.SonrakiDugum = dugum;
			dugum.SonrakiDugum.OncekiDugum = dugum;
			
			sayi++;
			degisiklik++;
		}

		/// <summary>
		/// Baðlý listeye, belirtilen indisinden itibaren bir koleksiyonun bütün öðelerini ekler.
		/// </summary>
		/// <param name="indis">Koleksiyon öðelerinin, baðlý listenin hangi sýrasýndan itibaren ekleneceði</param>
		/// <param name="koleksiyon">Eklenecek öðeleri içeren koleksiyon</param>
		/// <exception cref="ArgumentOutOfRangeException">Argüman sýnýrlarý taþtý istisnasý</exception>
		/// <exception cref="ArgumentNullException">Argüman boþ istisnasý</exception>
		public virtual void InsertAll(int indis, ICollection koleksiyon)
		{
			if (koleksiyon != null)
			{
				if (0 < koleksiyon.Count)
				{
					degisiklik++;

					Node startingNode = (indis == sayi ? ilkDugum : FindNodeAt(indis));
					Node previousNode = startingNode.OncekiDugum;
				
					foreach (object obj in koleksiyon)
					{
						Node node				= new Node(obj, startingNode, previousNode);
						previousNode.SonrakiDugum	= node;
						previousNode			= node;
					}
				
					startingNode.OncekiDugum = previousNode;

					sayi += koleksiyon.Count;						
				}
				else
					throw new ArgumentOutOfRangeException("Ýndis ", indis, " sýfýrdan küçük.");
			}
			else
				throw new ArgumentNullException("Koleksiyon boþ.");
		}

		/// <summary>
		/// Belirtilen öðeyi siler.
		/// </summary>
		/// <param name="oge">Silinecenk öðe</param>
		public virtual void Remove(object oge)
		{	
			if (oge == null) 
			{	
				for (Node dugum = ilkDugum.SonrakiDugum; dugum != ilkDugum; dugum = dugum.SonrakiDugum)
					if (dugum.Veri == null) 
						Remove(dugum);
			} 
			else 
			{
				for (Node dugum = ilkDugum.SonrakiDugum; dugum != ilkDugum; dugum = dugum.SonrakiDugum)
					if (oge.Equals(dugum.Veri)) 
						Remove(dugum);
			}
		}

		/// <summary>
		/// Belirtilen sýradaki öðeyi siler.
		/// </summary>
		/// <param name="index">Silinecek öðenin sýra numarasý</param>
		public virtual void RemoveAt(int index)
		{
			Remove(FindNodeAt(index));
		}
		#endregion

		#region Özel Üye Metodlar
		/// <summary>
		/// Belirtilen sýradaki öðeyi getirir.
		/// </summary>
		/// <param name="indis">Geitrilecek öðenin indisi</param>
		/// <returns>Belirtilen sýradaki öðe</returns>
		/// <exception cref="IndexOutOfRangeException">Ýndis listenin aralýðýnda deðil istisnasý</exception>
		private Node FindNodeAt(int indis) 
		{
			if (indis < 0 || sayi <= indis)
				throw new IndexOutOfRangeException("Ýndis " + indis + 
												   " denendi, fakat listenin toplam öðe sayýsý: " + sayi + ".");

			Node dugum = ilkDugum;

			if (indis < (sayi / 2)) 
			{
				for (int i = 0; i <= indis; i++)
					dugum = dugum.SonrakiDugum;
			} 
			else 
			{
				for (int i = sayi; i > indis; i--)
					dugum = dugum.OncekiDugum;
			}
			return dugum;
		}

		/// <summary>
		/// Belirtilen öðeyi siler.
		/// </summary>
		/// <param name="oge">Silinecek öðe</param>
		private void Remove(Node oge)
		{
			if (oge != ilkDugum)
			{				
				oge.OncekiDugum.SonrakiDugum = oge.SonrakiDugum;
				oge.SonrakiDugum.OncekiDugum = oge.OncekiDugum;
			
				sayi--;
				degisiklik++;
			}
		}
		#endregion

		#region Özel Üye Sýnýf
		/// <summary>
		/// Baðlý listeyi foreach döndüsü ile yazdýrabilemek için özel sýnýf
		/// </summary>
		[Serializable]
		private class LinkedListEnumerator : IEnumerator
		{
			#region Private Member Variables
			private BagliListe	linkedList;
			private int			validModificationCount;
			private Node		currentNode;
			#endregion

			#region Public Constructor
			public LinkedListEnumerator(BagliListe linkedList)
			{
				this.linkedList			= linkedList;
				validModificationCount	= linkedList.degisiklik;
				currentNode				= linkedList.ilkDugum;
			}
			#endregion

			#region Public Member Properties
			public object Current
			{
				get
				{
					return currentNode.Veri;
				}
			}
			#endregion

			#region Public Member Methods
			public void Reset()
			{
				currentNode				= linkedList.ilkDugum;
			}

			public bool MoveNext()
			{
				bool moveSuccessful = false;

				if (validModificationCount != linkedList.degisiklik)
					throw new SystemException("A concurrent modification occured to the LinkedList while accessing it through it's enumerator.");

				currentNode = currentNode.SonrakiDugum;

				if (currentNode != linkedList.ilkDugum)
					moveSuccessful = true;

				return moveSuccessful;
			}
			#endregion
		}
		#endregion
	}
}
