public class SimpleStack<T> // T = generic class parameter = SimpleStack of T
{
    private readonly T[] _items;
    private int _currentIndex = -1;
    public SimpleStack() => _items = new T[10];
    public void Push(T item) => _items[++_currentIndex] = item;
    public int Count => _currentIndex+1;

    public T Pop() => _items[_currentIndex--];
}

// public class SimpleStackString
// {
//     private readonly string[] _items;
//     private int _currentIndex = -1;
//     public SimpleStackString() => _items = new string[10];
//     public void Push(string item) => _items[++_currentIndex] = item;
//     public int Count => _currentIndex+1;

//     public string Pop() => _items[_currentIndex--];
// }

