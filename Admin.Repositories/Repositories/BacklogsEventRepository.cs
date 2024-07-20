using Admin.Entities.Models;
using Admin.Repositories.Base;
using Admin.Interfaces.Repositories;

namespace Admin.Repositories.Repositories
{
    public class BacklogsEventRepository : Repository<BacklogsEvent>, IBacklogsEventRepository
    {
        public BacklogsEventRepository(TalentSphereAdminContext context) : base(context)
        {
        }
    }
}