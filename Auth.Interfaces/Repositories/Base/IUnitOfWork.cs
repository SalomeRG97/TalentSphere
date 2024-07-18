using Auth.Interfaces.Repositories.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Auth.Interfaces.Repositories.Base
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }

        IDbContextTransaction BeginTransaction();
        Task Commit();
        void Dispose();
    }
}