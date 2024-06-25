using Admin.Entities.Models;
using Admin.Interfaces;

namespace Admin.Repositories
{
    public class FondoPensionRepository : Repository<FondosPensione>, IFondoPensionRepository
    {
        public FondoPensionRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}