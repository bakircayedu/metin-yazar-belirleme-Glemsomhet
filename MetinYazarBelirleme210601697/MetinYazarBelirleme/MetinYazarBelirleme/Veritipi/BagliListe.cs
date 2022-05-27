/* 
 * Ba�l� Liste (LinkedList) s�n�f�
 *  
 * B��ra Melis G�lbe
 * 
 */

using System;
using System.Collections;

namespace MetinYazarBelirleme.Veritipi
{
	[Serializable]
	public class BagliListe : IList, ICloneable
	{
		#region �ye Alanlar
		private Node	ilkDugum;
		private int		sayi;
		private int		degisiklik;
		#endregion

		#region Kurucular ( Constructors )
		/// <summary>
		/// Yeni bo� bir ba�l� liste olu�turur.
		/// </summary>
		public BagliListe()
		{
			ilkDugum = new Node(null, null, null);

			ilkDugum.SonrakiDugum		= ilkDugum;
			ilkDugum.OncekiDugum	= ilkDugum;

			sayi = 0;
		}

		/// <summary>
		/// Ba�ka bir koleksiyondaki ��elerle yeni bir ba�l� liste olu�turur.
		/// </summary>
		/// <param name="koleksiyon">The ICollection whose elements are copied to the new list.</param>
		public BagliListe(ICollection koleksiyon) : this()
		{
			TumunuEkle(koleksiyon);
		}
		#endregion

		#region �ye �zellikler
		/// <summary>
		/// Ba�l� listedeki ��e say�s�n� getirir.
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
		/// <param name="index">��enin dizideki s�ra numaras�</param>
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
										 
		#region �ye Metodlar
		/// <summary>
		/// Listeye ��e ekler.
		/// </summary>
		/// <param name="value">eklenecek ��e</param>
		/// <returns>.Eklenen ��enin s�ra numaras�n� d�nd�r�r.</returns>
		public virtual int Add(object value)
		{
			Insert(sayi, value);
			
			return (sayi - 1);
		}

		/// <summary>
		/// Ba�ka bir koleksiyondan topluca ��eler ekler.
		/// </summary>
		/// <param name="collection">Eklenecek ��elerin oldu�u kolaksiyon</param>
		public virtual void TumunuEkle(ICollection collection)
		{
			InsertAll(sayi, collection);
		}

		/// <summary>
		/// T�m listeyi temizler. B�t�n liste ��elerini siler.
		/// </summary>
		public virtual void Clear()
		{
			degisiklik++;

			ilkDugum.SonrakiDugum		= ilkDugum;
			ilkDugum.OncekiDugum	= ilkDugum;

			sayi = 0;
		}

		/// <summary>
		/// Listenin kopyas�n� olu�turur.
		/// </summary>
		/// <returns>Konlanm�� yeni bir liste d�nd�r�r.</returns>
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
												  "] nesne tipi ICloneable ile klonlanabilir de�ildir. Derinlemesine klonlama yap�lam�yor.");
				}	
			}
			else
				listClone = (BagliListe)this.Clone();

			return listClone;
		}

		/// <summary>
		/// Listede ��enin olup olmad���na bakar.
		/// </summary>
		/// <param name="oge">Aranan de�er</param>
		/// <returns><B>true</B>: ��e listede var, <B>false</B>: ��e listede yok.</returns>
		public virtual bool Contains(object oge)
		{
			return (0 <= IndexOf(oge));
		}

		/// <summary>
		/// Ba�l� listeyi bir diziye kopyalar.
		/// </summary>
		/// <param name="dizi">Hedef dizi</param>
		/// <param name="indis">��elerin dizi i�inde kopyalanaca�� konum</param>
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
		/// Numaraland�rma
		/// </summary>
		/// <returns>IEnumerator uyumlu liste</returns>
		public virtual IEnumerator GetEnumerator()
		{
			return new LinkedListEnumerator(this);
		}

		/// <summary>
		/// Aranan ��enin listedeki yerini verir.
		/// </summary>
		/// <param name="oge">Aranan ��e</param>
		/// <returns>��enin s�ra numaras�</returns>
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
		/// Ba�l� listenin belirtilen konumuna ��e ekler.
		/// </summary>
		/// <param name="indis">��enin ba�l� listede eklenece�i s�ra numaras�</param>
		/// <param name="oge">Eklenecek ��e</param>
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
		/// Ba�l� listeye, belirtilen indisinden itibaren bir koleksiyonun b�t�n ��elerini ekler.
		/// </summary>
		/// <param name="indis">Koleksiyon ��elerinin, ba�l� listenin hangi s�ras�ndan itibaren eklenece�i</param>
		/// <param name="koleksiyon">Eklenecek ��eleri i�eren koleksiyon</param>
		/// <exception cref="ArgumentOutOfRangeException">Arg�man s�n�rlar� ta�t� istisnas�</exception>
		/// <exception cref="ArgumentNullException">Arg�man bo� istisnas�</exception>
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
					throw new ArgumentOutOfRangeException("�ndis ", indis, " s�f�rdan k���k.");
			}
			else
				throw new ArgumentNullException("Koleksiyon bo�.");
		}

		/// <summary>
		/// Belirtilen ��eyi siler.
		/// </summary>
		/// <param name="oge">Silinecenk ��e</param>
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
		/// Belirtilen s�radaki ��eyi siler.
		/// </summary>
		/// <param name="index">Silinecek ��enin s�ra numaras�</param>
		public virtual void RemoveAt(int index)
		{
			Remove(FindNodeAt(index));
		}
		#endregion

		#region �zel �ye Metodlar
		/// <summary>
		/// Belirtilen s�radaki ��eyi getirir.
		/// </summary>
		/// <param name="indis">Geitrilecek ��enin indisi</param>
		/// <returns>Belirtilen s�radaki ��e</returns>
		/// <exception cref="IndexOutOfRangeException">�ndis listenin aral���nda de�il istisnas�</exception>
		private Node FindNodeAt(int indis) 
		{
			if (indis < 0 || sayi <= indis)
				throw new IndexOutOfRangeException("�ndis " + indis + 
												   " denendi, fakat listenin toplam ��e say�s�: " + sayi + ".");

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
		/// Belirtilen ��eyi siler.
		/// </summary>
		/// <param name="oge">Silinecek ��e</param>
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

		#region �zel �ye S�n�f
		/// <summary>
		/// Ba�l� listeyi foreach d�nd�s� ile yazd�rabilemek i�in �zel s�n�f
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
