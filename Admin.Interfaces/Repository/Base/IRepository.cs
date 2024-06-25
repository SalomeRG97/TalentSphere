
namespace Admin.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void AddAsync(T entity);
        void DeleteAsync(T entity);
        IEnumerable<T> GetAllAsync();
        void SaveChanges();
        void UpdateAsync(T entity);
    }
}