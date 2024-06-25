using Admin.Entities.Models;
using Admin.Interfaces;

namespace Admin.Repositories
{
    public class ArlRepository : Repository<Arl>, IArlRepository
    {
        public ArlRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}
