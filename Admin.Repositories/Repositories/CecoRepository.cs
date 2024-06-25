using Admin.Entities.Models;
using Admin.Interfaces;

namespace Admin.Repositories
{
    public class CecoRepository : Repository<Ceco>, ICecoRepository
    {
        public CecoRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}
