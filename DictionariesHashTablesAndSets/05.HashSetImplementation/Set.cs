namespace HashSetImplementation
{
    using System;
    using System.Collections.Generic;

    using HashTableImplementation;

    public class Set<T>
    {
        private HashTable<int, T> elements;

        public Set()
        {
            this.elements = new HashTable<int, T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(T element)
        {
            this.elements.Add(element.GetHashCode(), element);
        }

        public void Remove(T element)
        {
            this.elements.Remove(element.GetHashCode());
        }

        public T Find(T element)
        {
            T returnedElement = this.elements.Find(element.GetHashCode());
            
            return returnedElement;            
        }
        public void Clear()
        {
            this.elements.Clear();
        }
    }
}
