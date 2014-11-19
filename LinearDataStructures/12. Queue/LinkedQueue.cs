namespace Queue
{
    using System;
    using LinkedList;

    public class LinkedQueue<T> where T: IComparable<T>
    {
        public int Count
        {
            get
            {
                return this.InnerList.Count;
            }
        }

        private LinkedList<T> InnerList
        {
            get;
            set;
        }

        public LinkedQueue()
        {
            this.InnerList = new LinkedList<T>();
        }

        public void Enqueue (T item)
        {
            this.InnerList.AddLast(item);
        }

        public T Dequeue ()
        {
            return this.InnerList.RemoveFirst();
        }

        public T Peek ()
        {
            var itemToPeek = this.InnerList.RemoveFirst();
            this.InnerList.AddFirst(itemToPeek);

            return itemToPeek;
        }

        public void Clear ()
        {
            this.InnerList = new LinkedList<T>();
        }

        public bool Contains (T item)
        {
            foreach (var node in this.InnerList)
            {
                if (node.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
