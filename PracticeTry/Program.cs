using System.Linq.Expressions;

public class QueryBuilder<T>
{
    private IQueryable<T> _data;
    private readonly List<Func<T, bool>> _queries;

    public QueryBuilder(IQueryable<T> data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data), "Data cannot be null.");

        _data = data;
        _queries = new List<Func<T, bool>>();
    }

    /// <summary>
    /// Adds a filter condition to the query.
    /// </summary>
    /// <param name="condition">A lambda expression that returns true for items to keep.</param>
    /// <returns>The current QueryBuilder instance (for chaining).</returns>
    public QueryBuilder<T> Filter(Func<T, bool> condition)
    {
        if (condition == null)
            throw new ArgumentNullException(nameof(condition), "Filter condition cannot be null.");

        _queries.Add(condition);
        return this;
    }

    public QueryBuilder<T> Sortby<Tkey>(Func<T,Tkey> expression)
    {
        this._data = (IQueryable<T>)this._data.OrderBy(expression);
        return this;

    }

    public QueryBuilder<T> Thenby<Tkey>(Func<T,Tkey> expression)
    {
        if (expression is IOrderedQueryable<T>)
        {
            this._data = (IOrderedQueryable<T>)this._data.ThenBy(expression);
        }
        return this;
    }
    public IQueryable<T> Execute()
    {
        List<T> result = new List<T>(_data);

        foreach (var filter in _queries)
        {
            List<T> temp = new List<T>();

            foreach (var item in result)
            {
                try
                {
                    if (filter(item))
                        temp.Add(item);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error applying filter.", ex);
                }
            }

            result = temp;
        }

        return result.AsQueryable();
    }
}

public class Program
{
    public static void Main()
    {
        var dataset = new List<Person>
        {
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 30 },
            new Person { Name = "Charlie", Age = 35 },
            new Person { Name = "Diana", Age = 28 }
        };

        var query = new QueryBuilder<Person>(dataset.AsQueryable())
            .Filter(p => p.Age > 25)
            .Filter(p => p.Name.StartsWith("C"))
            .Execute();

        Console.WriteLine("Filtered results:");
        foreach (var person in query)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
