namespace LinkedList
{
    using System;
    using System.Text;

    public class LinkedList<T>: System.Collections.Generic.IEnumerable<T> where T: IComparable<T>
    {
        public ListItem<T> FirstItem
        {
            get;
            private set;
        }

        public ListItem<T> LastItem
        {
            get;
            private set;
        }

        public int Count
        {
            get;
            set;
        }

        public LinkedList()
        {
            this.Count = 0;
        }

        public void AddFirst(T item)
        {
            var tempItem = new ListItem<T>();
            tempItem.Value = item;
            
            if (this.Count != 0)
            {
                tempItem.NextItem = this.FirstItem;
                this.FirstItem.PreviousItem = tempItem;
            }
            else
            {
                tempItem.NextItem = this.LastItem;
            }

            this.FirstItem = tempItem;
            this.Count++;
        }

        public void AddLast (T item)
        {
            var tempItem = new ListItem<T>();
            tempItem.Value = item;
            if (this.Count != 0)
            {
                if (this.LastItem != null)
                {
                    tempItem.PreviousItem = this.LastItem;
                    this.LastItem.NextItem = tempItem;
                    this.LastItem = tempItem;
                }
                else
                {
                    this.LastItem = tempItem;
                    this.LastItem.PreviousItem = this.FirstItem;
                    this.FirstItem.NextItem = this.LastItem;
                }

                this.Count++;
            }
            else
            {
                this.AddFirst(item);
                tempItem.PreviousItem = this.FirstItem;
            }


        }

        public void AddBefore(ListItem<T> beforeItem, T itemToAdd)
        {
            var tempPrev = beforeItem.PreviousItem;
            var tempItem = new ListItem<T>();

            tempItem.Value = itemToAdd;
            tempItem.NextItem = beforeItem;

            tempPrev.NextItem = tempItem;

            tempItem.PreviousItem = tempPrev;
            beforeItem.PreviousItem = tempItem;

            this.Count++;
        }

        public void AddAfter (ListItem<T> afterItem, T itemToAdd)
        {
            var tempNext = afterItem.NextItem;
            var tempItem = new ListItem<T>();

            tempItem.Value = itemToAdd;
            tempItem.PreviousItem = afterItem;

            tempNext.PreviousItem = tempItem;

            tempItem.NextItem = tempNext;
            afterItem.NextItem = tempItem;

            this.Count++;
        }

        public T RemoveLast()
        {
            var itemToBeRemoved = this.LastItem.Value;
            var tempPrev = this.LastItem.PreviousItem;
            tempPrev.NextItem = null;

            this.LastItem = tempPrev;

            this.Count--;

            return itemToBeRemoved;
        }

        public T RemoveFirst()
        {
            var itemToBeRemoved = this.FirstItem.Value;

            if (this.FirstItem.NextItem == null)
            {
                this.FirstItem = null;
            }
            else
            {
                var tempNext = this.FirstItem.NextItem;
                tempNext.PreviousItem = null;

                this.FirstItem = tempNext;
            }
            
            this.Count--;

            return itemToBeRemoved;
        }

        public override string ToString ()
        {
            var result = new StringBuilder();
            var node = this.FirstItem;
            while (node != null)
            {
                result.AppendLine(node.Value.ToString());
                node = node.NextItem;
            }

            return result.ToString();
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator ()
        {
            var node = this.FirstItem;
            while (node != null)
            {
                yield return node.Value;
                node = node.NextItem;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
        {
            return this.GetEnumerator();
        }
    }
}
