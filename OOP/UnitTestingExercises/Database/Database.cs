using System;

namespace Database
{
    public class Database
    {
        private int[] data;

        private int count = 0;
        private int index;

        public Database() { }

        public Database(params int[] data)
            //: this()
        {
            if (data.Length > 16)
                throw new InvalidOperationException();

            this.data = new int[16];

            for (int i = 0; i < data.Length; i++)
            {
                this.Add(data[i]);
            }

            this.count = data.Length;
        }

        public int Count => count;

        public void Add(int element)
        {
            if (this.count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            this.data[this.count] = element;
            this.count++;
        }

        public void Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            this.data[--this.count] = 0;
        }

        public int[] Fetch()
        {
            int[] coppyArray = new int[this.count];

            for (int i = 0; i < this.count; i++)
            {
                coppyArray[i] = this.data[i];
            }

            return coppyArray;
        }
    }
}
