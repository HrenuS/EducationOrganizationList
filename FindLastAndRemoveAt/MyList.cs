namespace FindLastAndRemoveAt;

public class MyList<T>
{
    private readonly T[] _items;

    private readonly int _size;
    private int _currentSize;

    public MyList(int size)
    {
        _items = new T[size + 10];
        _size = size;
    }

    public void Add(T item)
    {
        if (_currentSize < _size)
        {
            _items[_currentSize] = item;
            _currentSize++;
        }
    }

    public void RemoveAt(int index)
    {
        if (_currentSize == 0)
        {
            return;
        }

        _currentSize--;

        if (index < _currentSize)
        {
            Array.Copy(_items, index + 1, _items, index, _currentSize - index);
        }

        _items[_currentSize] = default!;
    }

    public int FindLastAt(Predicate<T> match)
    {
        if (_currentSize == 0)
        {
            return -1;
        }

        for (var i = _currentSize - 1; i > 0; i--)
        {
            if (match(_items[i]))
            {
                return i;
            }
        }

        return -1;
    }
}