using Admin.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Admin.Interfaces
{
    public interface IUnitOfWork
    {
        IArlRepository ArlRepository { get; }

        IDbContextTransaction BeginTransaction();
        void Commit();
        void Dispose();
    }
}