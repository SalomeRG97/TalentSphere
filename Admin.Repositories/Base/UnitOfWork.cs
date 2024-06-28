using Admin.Entities.Models;
using Admin.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Admin.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TalentSphereAdminContext _context;
        private IArlRepository _arlRepository;

        public UnitOfWork(TalentSphereAdminContext context)
        {
            _context = context;
        }
        public IArlRepository ArlRepository => _arlRepository ??= new ArlRepository(_context);


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
