using System.Collections.Generic;
using System.Security.Cryptography;

namespace TrainingWork
{
    internal class CustomList<T>
        where T : class, IDisposable
    {
        private List<T> values = new List<T>();
        public bool Add(T item)
        {
            values.Add(item);
            return true;
        }
    }
    public class ListExtensions
    {
        public int Count<T>(List<T> list)
        {
            return list.Count;
        }
        public int Add<T>(List<T> list, T item)
        {
            return list.Add();
        }
    }
}