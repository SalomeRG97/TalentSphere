using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}