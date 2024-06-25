using Admin.Entities.Models;
using Admin.Interfaces;

namespace Admin.Repositories
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}