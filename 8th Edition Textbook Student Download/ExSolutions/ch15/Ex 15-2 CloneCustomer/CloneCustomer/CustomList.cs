using System.Collections;

namespace CloneCustomer
{
    public class CustomList<T> : IEnumerable<T>
    {
        private List<T> list = new();

        public int Count => list.Count;

        public T this[int i] => list[i];

        public void Add(T item) => list.Add(item);

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in list) 
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
