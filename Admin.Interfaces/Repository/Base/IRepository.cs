using System.Linq.Expressions;

namespace Admin.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> Add(T entity);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetOne(Expression<Func<T, bool>> funcion);
        Task SaveChanges();
        Task UpdateAsync(T entity);
    }
}