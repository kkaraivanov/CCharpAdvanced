namespace Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private List<int> data;

        public Lake(params int[] elements)
        {
            this.data = new List<int>(elements);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (i % 2 == 0)
                    yield return data[i];
            }

            for (int i = data.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                    yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
