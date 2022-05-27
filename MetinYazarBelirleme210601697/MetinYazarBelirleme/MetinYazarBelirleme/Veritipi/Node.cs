/*
 * Düğüm (Node) sınıfı, Bağlı listede vs. kullanılmak üzere
 */

using System;

namespace MetinYazarBelirleme.Veritipi
{
    [Serializable]
	public class Node:IComparable, IEquatable<Node>
    {
		#region Private Member Variables
		private object veri;
		private Node sonrakiDugum;
		private Node oncekiDugum;
		#endregion

		#region Public Constructor
		public Node(object currentNode, Node nextNode, Node previousNode)
		{
			this.veri = currentNode;
			this.sonrakiDugum = nextNode;
			this.oncekiDugum = previousNode;
		}

        public Node()
        {
			veri = null;
			sonrakiDugum = null;
			OncekiDugum = null;
        }
		#endregion

		#region Public Member Properties
		public object Veri
		{
			get{return veri;}
			set{veri = value;}
		}

		public Node SonrakiDugum
		{
			get{return sonrakiDugum;}
			set{sonrakiDugum = value;}
		}

		public Node OncekiDugum
		{
			get{return oncekiDugum;}
			set{oncekiDugum = value;}
		}

        public int CompareTo(object obj)
        {
			return Veri.GetHashCode() - obj.GetHashCode();
        }

        public bool Equals(Node other)
        {
			if (other.Veri == this.Veri)
				return true;
			return false;
        }
        #endregion
    }
}
