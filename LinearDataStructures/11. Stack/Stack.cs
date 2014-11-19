namespace Stack
{
    using System;

    public class Stack<T> where T: IComparable<T>
    {
        private const int InitialArraySize = 4;

        public int Length
        {
            get
            {
                return this.InnerArray.Length;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        private T[] InnerArray
        {
            get;
            set;
        }

        public Stack()
        {
            this.InnerArray = new T[InitialArraySize];
            this.Count = 0;
        }

        public void Push(T item)
        {
            if (this.Count > 0.75 * this.InnerArray.Length)
            {
                this.ResizeInnerArray(this.InnerArray.Length * 2);
            }

            this.InnerArray[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            this.Count--;
            if (this.Count < 0)
            {
                throw new ArgumentNullException("The stack is empty.");
            }

            var item = this.InnerArray[this.Count];
            this.InnerArray[this.Count] = default(T);
            return item;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("There are no elements in the stack.");
            }

            var item = this.InnerArray[this.Count - 1];
            return item;
        }

        public void Clear ()
        {
            this.InnerArray = new T[this.InnerArray.Length];
            this.Count = 0;
        }

        public bool Contains (T item)
        {
            foreach (var element in this.InnerArray)
            {
                if (element.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public T[] ToArray ()
        {
            return this.InnerArray;
        }

        public void TrimExcess()
        {
            this.ResizeInnerArray(this.Count);
        }

        private void ResizeInnerArray (int sizeOfArray)
        {
            var newArray = new T[sizeOfArray];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.InnerArray[i];
            }

            this.InnerArray = newArray;
        }
    }
}
