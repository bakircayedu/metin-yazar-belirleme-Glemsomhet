using System;
using System.Collections.Generic;

namespace MetinYazarBelirleme.Veritipi
{
    public class Hashtable
    {
        public List<object> keys;
        public List<object> values;

        private int count;

        public int Count
        {
            get { return count; }
        }

        public Hashtable()
        {
            keys = new List<object>();
            values = new List<object>();
            count = 0;
        }

        public void Add(object key, object value)
        {

            if (!keys.Contains(key))
            {
                keys.Add(key);
                values.Add(value);
                count++;
            }
            else throw new Exception("Anahtar zaten mevcut.");
        }

        public bool ContainsKey(object key)
        {
            return keys.Contains(key);  
        }


        public virtual object this[int index]
        {
            get 
            {
                var oge = new KeyValuePair<object, object>(
                    keys[index], values[index]);
                return oge; 
            }
        }
        public virtual object this[object key]
        {
            get 
            { 
                int index=keys.IndexOf(key);
                return values[index];
            }
            set 
            {
                if (!keys.Contains(key))
                {
                    keys.Add(key);
                    values.Add(value);
                    count++;
                }
                else
                {
                    int index = keys.IndexOf(key);
                    values[index]=value;
                }
            }
        }

        private class HashtableEnumerator : System.Collections.IEnumerator
        {
            private int index;
            private Hashtable hashtable;
            private KeyValuePair<object, object> current;
            public HashtableEnumerator(Hashtable hashtable)
            {
                index = 0;
                this.hashtable = hashtable;
            }
            public object Current
            {
                get
                {
                    return hashtable[index++];
                }
            }

            public bool MoveNext()
            {
                return index < hashtable.Count;
            }

            public void Reset()
            {
                current = new KeyValuePair<object, object>(
                    hashtable.keys[0], hashtable.values[0]);
            }
        }  
    }
}
