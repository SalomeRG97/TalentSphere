using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {
        public ServicioRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}
