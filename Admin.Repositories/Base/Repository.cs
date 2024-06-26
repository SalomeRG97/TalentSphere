using Microsoft.EntityFrameworkCore;
using Admin.Entities.Models;
using Admin.Interfaces;
using System.Linq.Expressions;

namespace Admin.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TalentSphereAdminContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(TalentSphereAdminContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
             _dbSet.Add(entity);
        }
        public async Task<int> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<T?> GetOne(Expression<Func<T, bool>> funcion)
        {
            return await _context.Set<T>().AsNoTracking().Where(funcion).FirstOrDefaultAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public async Task SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToList();
        }
    }
}