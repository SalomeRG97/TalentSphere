using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;
using Admin.DTO.Maestros;

namespace Admin.Repositories.Repositories
{
    public class ContratoLaboralRepository : Repository<ContratosLaborale>, IContratoLaboralRepository
    {
        private readonly TalentSphereAdminContext _context;

        public ContratoLaboralRepository(TalentSphereAdminContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ContratosLaborale> GetByDocument(string numeroDocumento)
        {
            return _context.ContratosLaborales
               .Join(_context.Empleados,
                     contrato => contrato.EmpleadoId,
                     empleado => empleado.Id,
                     (contrato, empleado) => new { contrato, empleado })
               .Where(joinResult => joinResult.empleado.NumeroDocumento.StartsWith(numeroDocumento))
               .Select(joinResult => joinResult.contrato)
               .FirstOrDefault();

        }
    } 
}