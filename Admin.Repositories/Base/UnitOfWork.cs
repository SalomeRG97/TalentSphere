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


        public void Commit()
        {
            _context.SaveChanges();
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
