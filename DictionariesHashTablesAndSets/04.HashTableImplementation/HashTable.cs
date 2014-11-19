namespace HashTableImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<Tkey, Tvalue>
    {
        private const int INITIAL_SIZE = 16;
        private const double FILL_FACTOR = 0.75d;

        private int maxItemsAtCurrentSize;

        private LinkedList<KeyValuePair<Tkey, Tvalue>>[] container;

        public HashTable()
        {
            this.container = new LinkedList<KeyValuePair<Tkey, Tvalue>>[INITIAL_SIZE];
            maxItemsAtCurrentSize = (int)(INITIAL_SIZE * FILL_FACTOR) + 1;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public List<Tkey> Keys 
        {
            get 
            {
                var listOfKeys = new List<Tkey>();
                foreach (var list in this.container)
                {
                    if (list != null)
                    {
                        foreach (var listItem in list)
                        {
                            listOfKeys.Add(listItem.Key);
                        }
                    }
                }

                return listOfKeys;
            } 
        }

        public Tvalue this[Tkey i] 
        {
            get
            {
                return this.Find(i);
            }
            set //Couldn't get it to work. Sorry.
            {
                var index = this.GetHashIndex(i);
                var pairToBeChanged = this.container[index].Where(p => p.Key.Equals(i)).FirstOrDefault();
                if (!(pairToBeChanged.Equals(null)))
                {                   
                    pairToBeChanged.Value = value;
                }
                else
                {
                    this.Add(i, value);
                }
            }
        }

        public void Add(Tkey key, Tvalue value)
        {
            if (this.Count >= maxItemsAtCurrentSize)
            {
                GrowArray();
            }

            var index = this.GetHashIndex(key);
            var pair = new KeyValuePair<Tkey, Tvalue>(key, value);
            if (this.container[index] == null)
            {
                this.container[index] = new LinkedList<KeyValuePair<Tkey, Tvalue>>();
            }

            this.container[index].AddLast(pair);
            this.Count++;
        }

        public Tvalue Find(Tkey key)
        {
            var index = this.GetHashIndex(key);
            if (this.container[index].Count > 1)
            {
                return this.container[index].Where(p => p.Key.Equals(key)).FirstOrDefault().Value;
            }
            else
            {
                return this.container[index].First.Value.Value;
            }
        }
        public void Remove(Tkey key)
        {
            var index = this.GetHashIndex(key);
            var pairToRemove = this.container[index].Where(p => p.Key.Equals(key)).FirstOrDefault();
            this.container[index].Remove(pairToRemove);
        }

        public void Clear()
        {
            this.container = new LinkedList<KeyValuePair<Tkey, Tvalue>>[INITIAL_SIZE];
        }

        private int GetHashIndex(Tkey key)
        {
            return Math.Abs(key.GetHashCode() % container.Length);
        }

        private void GrowArray()
        {
            Array.Resize<LinkedList<KeyValuePair<Tkey, Tvalue>>>(ref this.container, this.container.Length * 2);
            maxItemsAtCurrentSize = (int)(container.Length * FILL_FACTOR) + 1;
            Console.WriteLine(this.container.Length);
        }
    }
}
