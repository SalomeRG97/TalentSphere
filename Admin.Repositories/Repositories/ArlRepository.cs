using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class ArlRepository : Repository<Arl>, IArlRepository
    {
        public ArlRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}
