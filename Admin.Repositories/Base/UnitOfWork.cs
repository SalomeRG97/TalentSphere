using Admin.Entities.Models;
using Admin.Interfaces.Base;
using Microsoft.EntityFrameworkCore.Storage;
using Admin.Interfaces.Repositories;
using Admin.Repositories.Repositories;


namespace Admin.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TalentSphereAdminContext _context;
        private IArlRepository _arlRepository;
        private ICargoRepository _cargoRepository;
        private ICecoRepository _cecoRepository;
        private IEmpleadoRepository _empleadoRepository;
        private IEpsRepository _epsRepository;
        private IFondoPensionRepository _fondoPensionRepository;
        private IServicioRepository _servicioRepository;
        private ITipoContratoRepository _tipoContratoRepository;
        private IFilesRecordRepository _filesRecordRepository;
        public UnitOfWork(TalentSphereAdminContext context)
        {
            _context = context;
        }
        public IArlRepository ArlRepository => _arlRepository ??= new ArlRepository(_context);
        public ICargoRepository CargoRepository => _cargoRepository ??= new CargoRepository(_context);
        public ICecoRepository CecoRepository => _cecoRepository ??= new CecoRepository(_context);
        public IEmpleadoRepository EmpleadoRepository => _empleadoRepository ??= new EmpleadoRepository(_context);
        public IEpsRepository EpsRepository => _epsRepository ??= new EpsRepository(_context);
        public IFondoPensionRepository FondoPensionRepository => _fondoPensionRepository ??= new FondoPensionRepository(_context);
        public IServicioRepository ServicioRepository => _servicioRepository ??= new ServicioRepository(_context);
        public ITipoContratoRepository TipoContratoRepository => _tipoContratoRepository ??= new TipoContratoRepository(_context);
        public IFilesRecordRepository FilesRecordRepository => _filesRecordRepository ??= new FilesRecordRepository(_context);

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
