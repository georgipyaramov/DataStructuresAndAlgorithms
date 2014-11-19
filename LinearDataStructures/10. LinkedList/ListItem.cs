namespace LinkedList
{
    using System;

    public class ListItem<T> where T: IComparable<T>
    {
        public T Value
        {
            get;
            set;
        }

        public ListItem<T> NextItem
        {
            get;
            set;
        }

        public ListItem<T> PreviousItem
        {
            get;
            set;
        }

        public override string ToString ()
        {
            return this.Value.ToString();
        }
    }
}
