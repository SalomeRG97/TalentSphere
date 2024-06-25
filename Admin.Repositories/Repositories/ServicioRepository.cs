using Admin.Entities.Models;
using Admin.Interfaces;

namespace Admin.Repositories
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {
        public ServicioRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}
