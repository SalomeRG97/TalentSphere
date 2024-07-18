using Auth.Entities.Models;
using Auth.Interfaces.Repositories.Repositories;
using Auth.Interfaces.Repositories.Base;
using Auth.Repositories.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Auth.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TalentSphereAuthContext _context;
        private IUsuarioRepository _usuarioRepository;

        public UnitOfWork(TalentSphereAuthContext context)
        {
            _context = context;
        }
        public IUsuarioRepository UsuarioRepository => _usuarioRepository ??= new UsuarioRepository(_context);

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
