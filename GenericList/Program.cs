using System.ComponentModel;

namespace DelegatesEvents
{
    public delegate void ListChangedEventHandler<T>(string action, T? item);
    internal class Program
    {
        public static void Main(string[] args)
        {
            ListChangedEventHandler l = (action, item) => Console.WriteLine($"[ADD1] {action}: {item} ");
            l += (action, item) => Console.WriteLine($"[ADD2] {action}: {item} ");
            l.Invoke("Hello", default);
            var list = new MyList<String>();
            int a = 0;
            MyList<String> e = new MyList<string>();
            list.ItemAdded += e.SendMessage;
            list.ItemRemoved += SendMessage;
            a++;
            list.ItemAdded += (action, item) => Console.WriteLine($"[ADD2] {action}: {item} {a}");
            int addCount = 0;
            list.ItemAdded += (action, item) =>
            {
                Console.WriteLine($"[ADD3] {addCount++}: {item}");
            };
            list.ItemRemoved += (action, item) => Console.WriteLine($"[REMOVE] {addCount}:{action}: {item}");
            list.ListCleared += (action, item) => Console.WriteLine($"[CLEAR] {action}");
            list.Add("Prod1");
            list.Add("Prod2");
            list.Add("Prod3");
            list.Remove("Prod1");
            Console.WriteLine("Add count: " + addCount);
            /*foreach (var l in list)
            {
                Console.WriteLine($"Remaining : {l}");
            }
            */
            list.Clear();
            Console.WriteLine($"Count after clearing the list:{list.Count}");
            Console.ReadKey();
        }

        private static void SendMessage(string action, string? item)
        {
            Console.WriteLine($"{action} : {item}");
        }
    }
    public class MyList<T> : List<T>
    {
        public event ListChangedEventHandler<T>? ItemAdded;
        public event ListChangedEventHandler<T>? ItemRemoved;
        public event ListChangedEventHandler<T>? ListCleared;
        public new void Add(T item)
        {
            base.Add(item);
            ItemAdded?.Invoke("Added", item);
        }
        public new bool Remove(T item)
        {
            bool removed = base.Remove(item);
            if (removed)
            {
                ItemRemoved?.Invoke("Removed", item);
            }
            return removed;
        }
        public new void Clear()
        {
            base.Clear();
            ListCleared?.Invoke("Cleared", default);
        }
        public void SendMessage(string message, T? item)
        {
            Console.WriteLine($"{message} : {item}");
        }
    }
}