using System;

namespace HashTableImplementation
{
    using System;

    public struct KeyValuePair<Tkey, Tvalue> : IEquatable<KeyValuePair<Tkey, Tvalue>>
    {
        private Tkey key;

        private Tvalue value;

        static KeyValuePair()
        {
        }

        public KeyValuePair(Tkey initialKey, Tvalue initialValue)
        {
            this.key = initialKey;
            this.value = initialValue;
        }

        public Tkey Key 
        {
            get { return this.key; }
            set { this.key = value; }
        }

        public Tvalue Value 
        {
            get { return this.value; }
            set { this.value = value; } 
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.key.GetHashCode();
                result = result * 23 + this.value.GetHashCode();
                return result;
            }
        }

        public bool Equals(KeyValuePair<Tkey, Tvalue> other)
        {
            return Equals(this.key, other.key) &&
                   Equals(this.value, other.value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is KeyValuePair<Tkey, Tvalue>))
            {
                return false;
            }
            return this.Equals((KeyValuePair<Tkey, Tvalue>)obj);
        }
    }
}