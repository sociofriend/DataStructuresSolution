using System.Collections;

namespace SetCollectionLibrary;

//class shall have contract with IEnumerable interface, and the T type should have contract with IComparable interface
public class CustomSetCollection<T> : IEnumerable<T>
    where T : IComparable<T>
{
    //create local list to store vaues
    private readonly List<T> _items = new List<T>();

    //default constructor
    public CustomSetCollection()
    {

    }

    /// <summary>
    /// Invokes <see cref="AddRange(IEnumerable{T})"/> method.
    /// </summary>
    /// <param name="items">IEnumerable collection of generic type items.</param>
    public CustomSetCollection(IEnumerable<T> items)
    {
        AddRange(items);
    }

    /// <summary>
    /// Adds given item to local list of values.
    /// </summary>
    /// <param name="item">Generic type item.</param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Add(T item)
    {
        //check if local list does not contain the gievn item
        if (!_items.Contains(item))
            //add the item to the list
            _items.Add(item);
    }

    /// <summary>
    /// Adds given collection's items to 
    /// </summary>
    /// <param name="items"></param>
    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }
    }

    private void AddSkipDuplicates(List<T> items)
    {
        foreach (var item in items)
            if (!Contains(item))
                Add(item);
    }

    public bool Remove(T item)
    {
        if (!_items.Remove(item))
            return false;
        return true;
    }
    public int Count
    {
        get
        {
            return _items.Count;
        }
    }

    public void Clear()
    {
        _items.Clear();
    }

    public bool Contains(T item)
    {
        if (!_items.Contains(item))
            return false;
        return true;
    }


    public CustomSetCollection<T> Union(CustomSetCollection<T> other)
    {
        CustomSetCollection<T> result = new CustomSetCollection<T>();
        result.AddRange(other._items);
        result.AddSkipDuplicates(_items);
        return result;
    }

    public CustomSetCollection<T> Intersection(CustomSetCollection<T> other)
    {
        CustomSetCollection<T> result = new CustomSetCollection<T>();
        
        foreach (var item in other)
        {
            if (_items.Contains(item))
            { 
                result.Add(item); 
            }
        }

        return result;
    }

    public CustomSetCollection<T> Difference(CustomSetCollection<T> other)
    {
        CustomSetCollection<T> result = new CustomSetCollection<T>();
        
        foreach (var item in _items)
        {
            if (!other.Contains(item))
                result.Add(item);
        }
        return result;
    }

    public CustomSetCollection<T> SymmetricDifference(CustomSetCollection<T> other)
    {
        CustomSetCollection<T> intersection = Intersection(other);
        CustomSetCollection<T> union = Union(other);

        return union.Difference(intersection);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}