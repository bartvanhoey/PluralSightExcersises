using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{

    public class ListRepository<T> : IRepository<T> where T : IEntity
    {
        public ListRepository(Action<T>? itemAddedCallback = null)
        {
            _itemAddedCallback = itemAddedCallback;
        }


        private readonly List<T> _items = new();
        private readonly Action<T>? _itemAddedCallback;

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            _itemAddedCallback?.Invoke(item);
        }

        public void Save()
        {
        // Everything is already saved
        //     foreach (T item in _items)
        //     {
        //         Console.WriteLine(item);
        //     }
        }

        public void Remove(T item) => _items.Remove(item);

        public IEnumerable<T> GetAll() => _items.ToList();

    }


}
