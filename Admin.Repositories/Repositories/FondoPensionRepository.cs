using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class FondoPensionRepository : Repository<FondosPensione>, IFondoPensionRepository
    {
        public FondoPensionRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}