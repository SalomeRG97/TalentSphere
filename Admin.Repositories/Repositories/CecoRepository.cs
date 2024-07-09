using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class CecoRepository : Repository<Ceco>, ICecoRepository
    {
        public CecoRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}
