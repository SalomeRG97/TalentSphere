using System.Linq.Expressions;

namespace Admin.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task AddRange(List<T> entity);
        void DeleteAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true);
        void SaveChangesAsync();
        void UpdateAsync(T entity);
        Task<T?> GetOne(Expression<Func<T, bool>> funcion);
    }
}