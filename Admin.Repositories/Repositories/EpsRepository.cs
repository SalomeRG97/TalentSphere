using Admin.Entities.Models;
using Admin.Interfaces;

namespace Admin.Repositories
{
    public class EpsRepository : Repository<Ep>, IEpsRepository
    {
        public EpsRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}