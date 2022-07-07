using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{

    // public delegate void ItemAdded<in T>(T item);

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly StorageAppDbContext _dbContext;
        public event EventHandler<T>? ItemAdded;
        private readonly DbSet<T> _dbSet;


        public SqlRepository(StorageAppDbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T? GetById(int id) => _dbSet.Find(id);

        public void Add(T item) {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        } 

        public void Save() => _dbContext.SaveChanges();

        public void Remove(T item) => _dbSet.Remove(item);

        public IEnumerable<T> GetAll() => _dbSet.OrderBy(x => x.Id).ToList();
    }


}
