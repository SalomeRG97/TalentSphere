using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class EpsRepository : Repository<Ep>, IEpsRepository
    {
        public EpsRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}