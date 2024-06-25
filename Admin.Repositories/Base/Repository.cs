using Microsoft.EntityFrameworkCore;
using Admin.Entities.Models;
using Admin.Interfaces;

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

        public void AddAsync(T entity)
        {
            _dbSet.Add(entity);
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAllAsync()
        {
            return _dbSet.ToList();
        }
    }
}