namespace FileTree
{
    using System;

    public class File
    {
        private string name;
        private long size;

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("File name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public long Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Size cannot be less than zero");
                }

                this.size = value;
            }
        }
    }
}