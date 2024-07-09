using Admin.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Admin.Interfaces.Base
{
    public interface IUnitOfWork
    {
        IArlRepository ArlRepository { get; }
        ICargoRepository CargoRepository { get; }
        ICecoRepository CecoRepository { get; }
        IEmpleadoRepository EmpleadoRepository { get; }
        IEpsRepository EpsRepository { get; }
        IFondoPensionRepository FondoPensionRepository { get; }
        IServicioRepository ServicioRepository { get; }
        ITipoContratoRepository TipoContratoRepository { get; }
        IDbContextTransaction BeginTransaction();
        Task Commit();
        void Dispose();
    }
}